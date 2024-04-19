# TEngine
<p align="center">
    <img src="Books/src/TEngine512.png" alt="logo" width="384" height="384">
</p>

<h3 align="center"><strong>TEngine<strong></h3>

<p align="center">
  <strong>Unity框架解决方案<strong>
    <br>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/badge/Unity%20Ver-2021.3.20++-blue.svg?style=flat-square" alt="status" />
  </a>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/github/license/ALEXTANGXIAO/TEngine" alt="license" />
  </a>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/github/last-commit/ALEXTANGXIAO/TEngine" alt="last" />
  </a>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/github/issues/ALEXTANGXIAO/TEngine" alt="issue" />
  </a>
  <a style="text-decoration:none">
    <img src="https://img.shields.io/github/languages/top/ALEXTANGXIAO/TEngine" alt="topLanguage" />
  </a>
  <br>
  
  <br>
</p>


# <strong>TEngine

#### TEngine是一个简单(新手友好开箱即用)且强大的Unity框架全平台解决方案,对于需要一套上手快、文档清晰、高性能且可拓展性极强的商业级解决方案的开发者或者团队来说是一个很好的选择。


## <a href="http://1.12.241.46:5000/"><strong>文档快速入门 »</strong></a>

## 文档快速预览 - 5分钟
* [全平台跑通示意](Books/99-各平台运行RunAble.md): 全平台跑通示意。
* [01_介绍](Books/0-介绍.md): 简单介绍。
* [02_框架概览](Books/2-框架概览.md): 展示框架概览。
* [03_资源模块](Books/3-1-资源模块.md): 展示资源模块概览。
* [04_事件模块](Books/3-2-事件模块.md): 展示事件模块概览。
* [05_内存池模块](Books/3-3-%E5%86%85%E5%AD%98%E6%B1%A0%E6%A8%A1%E5%9D%97.md): 展示内存池模块概览。
* [06_对象池模块](Books/3-4-%E5%AF%B9%E8%B1%A1%E6%B1%A0%E6%A8%A1%E5%9D%97.md): 展示对象池模块概览。
* [07_配置表模块](Books/3-6-%E9%85%8D%E7%BD%AE%E8%A1%A8%E6%A8%A1%E5%9D%97.md): 展示配置表模块概览。
* [08_流程模块](Books/3-7-%E6%B5%81%E7%A8%8B%E6%A8%A1%E5%9D%97.md): 展示商业化流程模块。
* [09_UI模块](Books/3-5-UI模块.md): 展示商业化UI模块。


## <strong>为什么要使用TEngine
0. 开箱即用5分钟即可上手整套开发流程，代码整洁，思路清晰，功能强大。高内聚低耦合。您可以很轻易的把您不需要的模块进行移除替换。
1. 严格按照商业要求使用次世代的HybridClr进行热更新、最佳的Luban配置表(TEngine支持懒加载、异步加载、同步加载配置。)、百万DAU游戏验证过的YooAsset资源框架（框架管理资源引用与释放。），全平台热更新流程已跑通。
2. 严格按照商业化流程执行的热更新、商业化的UI开发流程、以及资源管理等等，设计并实现了YooAsset资源自动释放、支持LRU、ARC严格管理资源内存。
3. C#双端解决方案，服务器使用Fantasy，是一套源于ETServer，但极为简洁，性能更强，更好上手的一套商业级服务器框架。
4. 支持全平台，已有项目使用TEngine上架Steam、Wechat-minigame、AppStore。

## <strong>资源重要拓展概念
* AssetReference (资源引用标识) 通用加载资源的时候绑定一个引用标识使你无需关心手动Dispose资源句柄。

* AssetGroup（资源组数据）进行资源分组绑定管理内存中的生命周期资源生命周期托管给资源组的根节点进行Dispose。

* LruCacheTable (Least Recently Used Cache缓存表)

* ArcCacheTable (Adaptive Replacement Cache缓存表)

## <strong>为什么服务器使用C#
Net Core现在已经更新到了8.0的版本，在性能和设计上其实是远超JAVA和GO。在JAVAER还在为JVM更新和添加更多功能时，其实他们已经被国内大环境所包围了，看不到.Net Core的性能之强，组件化的结构。国内大环境是JAVA和GO的天下这个不可否认，但是国外C#也确实很多。其实.Net Core最大的问题是大多数自己人都不知道他的优点(AOT、JIT混合编译、热重载等等)，甚至很多守旧派抵制core。GO喜欢吹性能，但其实目前来看，除了协程的轻量级，大多数性能测试其实不如JAVA和.Net。简单可以说出了C++的性能以外，Net Core其实都打得过。
<strong>当然作为商业级解决方案服务器的耦合度也极低，如果不喜欢您也可以很轻松直接移除替换成你的服务器。</strong>

## <strong>项目结构概览
```
Assets
├── AssetRaw            // 热更资源目录
├── Atlas               // 自动生成图集目录
├── HybridCLRData       // hybridclr相关目录
├── TEngine             // 框架核心目录
└── GameScripts         // 程序集目录
    ├── Editor          // 编辑器程序集
    ├── Main            // 主程序程序集(启动器与流程)
    └── HotFix          // 游戏热更程序集目录 [Folder]
        ├── GameBase    // 游戏基础框架程序集 [Dll]
        ├── GameProto   // 游戏配置协议程序集 [Dll]  
        ├── BattleCore  // 游戏核心战斗程序集 [Dll] 
        └── GameLogic   // 游戏业务逻辑程序集 [Dll]
            ├── GameApp.cs                  // 热更主入口
            └── GameApp_RegisterSystem.cs   // 热更主入口注册系统   


TEngine
├── Editor              // TEngine编辑器核心代码
└── Runtime             // TEngine运行时核心代码
```

 - 必要：项目使用了以下第三方插件，请自行购买导入：
   - /Unity/Assets/Plugins/Sirenix

---
## <strong>优质开源项目推荐

#### <a href="https://github.com/tuyoogame/YooAsset"><strong>YooAsset</strong></a> - YooAsset是一套商业级经历百万DAU游戏验证的资源管理系统。

#### <a href="https://github.com/JasonXuDeveloper/JEngine"><strong>JEngine</strong></a> - 使Unity开发的游戏支持热更新的解决方案。

#### <a href="https://github.com/focus-creative-games/hybridclr"><strong>HybridCLR</strong></a> - 特性完整、零成本、高性能、低内存的近乎完美的Unity全平台原生c#热更方案

#### <a href="https://github.com/qq362946/Fantasy"><strong>Fantasy</strong></a> - Fantasy是一套源于ETServer但极为简洁，性能更强，更好上手的一套商业级服务器框架。

## <strong>交流群
### <a href="http://qm.qq.com/cgi-bin/qm/qr?_wv=1027&k=MzOcQIzGVLQ5AC5LHaqqA3h_F6lZ_DX4&authKey=LctqAWGHkJ7voQvuj1oaSe5tsGrc1XmQG3U4QniieGUlxY3lC7FtDIpEvPOX0vT8&noverify=0&group_code=862987645">群   号：862987645 </strong></a>


## <strong>Buy me a coffee.

[您的赞助会让我们做得更快更好，如果觉得TEngine对您有帮助，不妨赞助我买杯咖啡吧~](Books/Donate.md)
