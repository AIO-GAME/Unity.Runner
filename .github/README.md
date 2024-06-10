<p align="center"> 
<img src="RES/Logo.svg" width="256" height="256" alt="https://github.com/AIO-GAME"> 
</p>
<p align="center" style="font-size: 24px;"> 
<b>Unity Runner</b>
</p>
<p align="center"><a href="README_EN.md">English</a> | 简体中文</p>
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

## ⚙ 安装

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

> open upm *中国版*

~~~
Name: package.openupm.cn
URL: https://package.openupm.cn
Scope(s): com.aio.runner
~~~

> open upm *国际版*

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

- **这是一个 Unity 协程 线程池 任务执行扩展包**
- ✅ **支持 快速执行协程** `Runner.StartCoroutine`
- ✅ **支持 快速执行线程** `Runner.StartTask`
- ✅ **支持 在Editor执行协程**

## 📚 使用

<h4>开启协程</h4>

```csharp 
Runner.StartCoroutine(T);
Runner.StartCoroutine(T());
Runner.StartCoroutine(T, T1, T2);
Runner.StartCoroutine(T(), T1(), T2());
Runner.StartCoroutine(mono, T1, T2);
Runner.StartCoroutine(mono, T1(), T2());
``` 

<h4>关闭协程</h4>

```csharp
Runner.StopCoroutine(Test);
Runner.StopCoroutine(mono);```
Runner.StopCoroutine(mono, Test);
Runner.StopCoroutine(Test());
``` 

<h4>开启协程</h4>

```csharp
Runner.StartTask(() => { });
```  

## ✨ 贡献者

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
            <td align="center">
                <a href="https://github.com/Starkappa">
                    <img src="https://avatars.githubusercontent.com/u/155533864?v=4" width="64;" alt="Starkappa"/>
                    <br />
                    <sub><b>Starkappa</b></sub>
                </a>
            </td>
		</tr>
	<tbody>
</table>
<!-- readme: collaborators,contributors -end -->

## 📢 致谢

- **谢谢您选择我们的扩展包。**
- **如果此软件包对您有所帮助。**
- **请考虑通过添加⭐来表示支持。**