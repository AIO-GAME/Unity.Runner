<p align="center"> 
<img src="RES/Logo.svg" width="256" height="256" alt="https://github.com/AIO-GAME"> 
</p>
<p align="center" style="font-size: 24px;"> 
<b>Unity Runner</b>
</p>
<p align="center"><a href="README_EN.md">简体中文</a> | English</p>
<p align="center">
<a href="https://github.com/AIO-GAME/Runner/security/policy"> 
<img alt="" src="https://img.shields.io/github/package-json/unity/AIO-GAME/Unity.Runner"> 
</a>
<a href="https://github.com/AIO-Game/Runner">
<img src="https://img.shields.io/github/license/AIO-Game/Unity.Runner" alt=""/>
</a>
<a href="https://github.com/AIO-Game/Runner">
<img src="https://img.shields.io/github/languages/code-size/AIO-Game/Unity.Runner?label=size" alt=""/>
</a>
<a href="https://openupm.com/packages/com.aio.runner/">
<img src="https://img.shields.io/npm/v/com.aio.runner?label=openupm&amp;registry_uri=https://package.openupm.com" alt=""/>
</a>
</p>

## ⚙ Install

<details>
<summary>
<span style="color: deepskyblue; "><b>Packages Manifest</b></span>
</summary>

````json
{
  "dependencies": {
    "com.aio.runner": "latest"
  },
  "scopedRegistries": [
    {
      "name": "package.openupm.com",
      "url": "https://package.openupm.com",
      "scopes": [
        "com.aio.runner"
      ]
    }
  ]
}
````

</details>

<details>
<summary>
<span style="color: deepskyblue; "><b>Unity PackageManager</b></span>
</summary>

> open upm *Chinese Version*

~~~
Name: package.openupm.cn
URL: https://package.openupm.cn
Scope(s): com.aio.runner
~~~

> open upm *International Version*

~~~
Name: package.openupm.com
URL: https://package.openupm.com
Scope(s): com.aio.runner
~~~

</details>

<details>
<summary>
<span style="color: deepskyblue; "><b>Command Line</b></span>
</summary>

> open *upm-cli*

~~~
openupm add com.aio.runner
~~~

</details>

## ⭐ About

- **This is a Unity Coroutine Thread Pool Task Execution Extension Package**
- ✅ **Support fast execution of coroutine** `Runner.StartCoroutine`
- ✅ **Support fast execution of thread** `Runner.StartTask`
- ✅ **Support coroutine execution in Editor**

## 📚 使用

<h4>Start Coroutine</h4>

```csharp 
Runner.StartCoroutine(T);
Runner.StartCoroutine(T());
Runner.StartCoroutine(T, T1, T2);
Runner.StartCoroutine(T(), T1(), T2());
Runner.StartCoroutine(mono, T1, T2);
Runner.StartCoroutine(mono, T1(), T2());
``` 

<h4>Stop Coroutine</h4>

```csharp
Runner.StopCoroutine(Test);
Runner.StopCoroutine(mono);```
Runner.StopCoroutine(mono, Test);
Runner.StopCoroutine(Test());<h4>Task</h4>      
``` 

<h4>Start Task</h4>

```csharp
Runner.StartTask(() => { });
```  

## ✨ Contributors

<!-- readme: collaborators,contributors -start -->
<table>
	<tbody>
		<tr>
            <td align="center">
                <a href="https://github.com/xinansky">
                    <img src="https://avatars.githubusercontent.com/u/45371089?v=4" width="64;" alt="xinansky"/>
                    <br />
                    <sub><b>xinansky</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators,contributors -end -->

## 📢 Thanks

- **Thank you for choosing our extension package.**
- **If you have any questions, please feel free to ask.**
- **Please consider supporting us by adding a ⭐.**