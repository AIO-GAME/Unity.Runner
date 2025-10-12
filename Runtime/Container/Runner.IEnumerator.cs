#region namespace

using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Scripting;
#if SUPPORT_UNITASK
using Cysharp.Threading.Tasks;
#endif

#endregion

namespace AIO
{
    partial class Runner
    {
        [Preserve]
        private class CoroutineData
        {
            /// <c>0:未开始</c><c>1:开始</c><c>2:结束</c>
            public int State { get; private set; }

            [Preserve]
            private CancellationTokenSource Source { get; set; }

            [Preserve]
            private CoroutineData() { State = 0; }

            [Preserve]
            public void Cancel() { Source.Cancel(); }

            [Preserve]
            private IEnumerator current;

            [Preserve]
            private void Finish()
            {
                QueuesCoroutine.TryRemove(current, out _);
                Behaviour = null;
                State     = 2;
                Source?.Dispose();
                Free.Enqueue(this);
            }

            [Preserve]
            public MonoBehaviour Behaviour { get; private set; }

            [Preserve]
            public void Start(IEnumerator enumerator)
            {
                State   = 1;
                current = enumerator;
                if (Behaviour != null) Behaviour.StartCoroutine(RunCoroutine());
                else instance.StartCoroutine(RunCoroutine());
            }

            [Preserve]
            private IEnumerator RunCoroutine()
            {
                while (!Source.IsCancellationRequested)
                {
                    if (!current.MoveNext()) break;
                    yield return current.Current;
                }

                Finish();
            }

            [Preserve]
            private static ConcurrentQueue<CoroutineData> Free { get; } = new ConcurrentQueue<CoroutineData>();

            [Preserve]
            public static CoroutineData Create(MonoBehaviour behaviour)
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.Behaviour = behaviour;
                item.State     = 0;
#if SUPPORT_UNITASK
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(behaviour.GetCancellationTokenOnDestroy());
#else
                item.Source = new CancellationTokenSource();
#endif
                return item;
            }

            [Preserve]
            public static CoroutineData Create(MonoBehaviour behaviour, CancellationTokenSource sources)
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.State     = 0;
                item.Behaviour = behaviour;
#if SUPPORT_UNITASK
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(new[] { sources.Token, behaviour.GetCancellationTokenOnDestroy() });
#else
                item.Source = sources;
#endif
                return item;
            }

            [Preserve]
            public static CoroutineData Create(MonoBehaviour behaviour, params CancellationToken[] sources)
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.State     = 0;
                item.Behaviour = behaviour;
#if SUPPORT_UNITASK
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(sources.Add(behaviour.GetCancellationTokenOnDestroy()));
#else
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(sources);
#endif
                return item;
            }

            [Preserve]
            public static CoroutineData Create()
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.Behaviour = null;
                item.State     = 0;
#if SUPPORT_UNITASK && UNITY_2020_1_OR_NEWER
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(GetCancellationTokenOnDestroy);
#else
                item.Source = new CancellationTokenSource();
#endif
                return item;
            }

            [Preserve]
            public static CoroutineData Create(params CancellationToken[] sources)
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.State     = 0;
                item.Behaviour = null;
#if SUPPORT_UNITASK && UNITY_2020_1_OR_NEWER
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(sources.Add(GetCancellationTokenOnDestroy));
#else
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(sources);
#endif
                return item;
            }

            [Preserve]
            public static CoroutineData Create(CancellationTokenSource sources)
            {
                if (!Free.TryDequeue(out var item)) item = new CoroutineData();
                item.State     = 0;
                item.Behaviour = null;
#if SUPPORT_UNITASK && UNITY_2020_1_OR_NEWER
                item.Source = CancellationTokenSource.CreateLinkedTokenSource(new[] { sources.Token, GetCancellationTokenOnDestroy });
#else
                item.Source = sources;
#endif
                return item;
            }
        }

        #region 协程

        [ContextStatic] [Preserve]
        private static readonly ConcurrentDictionary<IEnumerator, CoroutineData> QueuesCoroutine = new ConcurrentDictionary<IEnumerator, CoroutineData>();

        [ContextStatic] [Preserve]
        private static bool QueuesCoroutineState;

        [Preserve]
        private static void UpdateCoroutine()
        {
            QueuesCoroutineState = true;

            foreach (var current in QueuesCoroutine.Where(current => current.Value.State == 0))
            {
                current.Value.Start(current.Key);
            }

            QueuesCoroutineState = false;
        }

        /// <summary>
        /// 执行协程
        /// </summary>
        [Preserve]
        public static bool PushUpdate(IEnumerator coroutine) => QueuesCoroutine.TryAdd(coroutine, CoroutineData.Create());

        /// <summary>
        /// 执行协程
        /// </summary>
        [Preserve]
        public static bool PushUpdate(IEnumerator coroutine, params CancellationToken[] sources) =>
            QueuesCoroutine.TryAdd(coroutine, CoroutineData.Create(sources));

        #endregion
    }
}