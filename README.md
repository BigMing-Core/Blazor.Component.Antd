
<div align="center" >
  <img src="https://resource.luanniao.club/commonres/icon.png">
  <h3>LuanNiao Blazor Component-- ANTD</h3>
  <h3>鸾鸟Blazor组件库--基于ANTDV4 风格</h3>
  <span>A Blazor Component Library based on Ant V4 style</span>
  <span>A Blazor Component Library based on Ant V4 style</span>
  <br/>
  <br/>
</div>

我们的库目标在于借助现有的体系来制作稳定的,高可用性的Blazor组件库.<br/>
我们不会与其他实现一样去同步官方的CSS以及对应的实现,我们目前锁定于antd v4.0.4.
<br/>
Our library goal is to use the existing system to make a stable, high-availability Blazor component library.<br/>
We will not synchronize the official CSS and corresponding implementations like other implementations.<br/>
We are currently locked in antd v4.0.4.
<Br/>

## About LuanNiao
鸾鸟是中国一家小型的软件公司的前端团队,我们公司方向为:OA,ERP,IOT,FPGA定制,MCU开发,机器人,视觉识别,图形绘制,GIS等,以及对外外包业务.<br/>
我们同样也会存在对应的WEBGL,CANVAS 2D部分的业务内容,我司目前技术栈保持在:C, C++, QT, .NET CORE, Golang, H5, OPENGL, React, Vue.<br/>
LuanNiao Blazor 组件库是我们团队对于落地实际网站业务时的组件库,我们的仓库并不受限于实现ANTD的功能,而是为了做到实际在开发网站场景中能够实际使用为目标进行开发.<br/>
具体细节内容详见我们的文档网站首页描述,那里我们编写了很多我们做出妥协的原因与当前仓库的设计架构与业务流转图.<p></p>
LuanNiao is the front-end team of a small software company in China.We are committed to developing and developing internal OA, ERP and other projects of the company, as well as outsourcing business.<br/>
We will also have corresponding business content of WEBGL and CANVAS 2D parts.Our current technology stack remains at: C, C ++, QT, .NET CORE, Golang, React, Vue.<br/>
The LuanNiao Blazor component library is the component library of our team for landing on the actual website business.Our warehouse is not limited to the realization of the function of ANTD, but for the purpose of actual use in the development website scenario.<br/>
For specific details, please see the description on the front page of our documentation website, where we have written a lot of reasons for our compromise and the current warehouse design architecture and business flow diagram.

## Announcement 公告
经过我们公司与团队进行一天的商讨,同时经过可实施性分析与成本分析后,我们未来将不会对文档演示网站进行美化.<br/>
这里指的美化,仅仅是指:我们会维护,但并不会编写标准级别的阅读文档,您可以在文档网站看到我们的所有组件功能,但我们不会对此进行排版布局.
After a day of discussion between our company and the team, as well as after implementability analysis and cost analysis, we will not beautify the document demonstration website in the future.<br/>
The beautification here refers only to: we will maintain, but we will not write standard-level reading documents.You can see all of our component functions on the documentation website, but we will not typographically layout this.
<br/>
我们目前的开发速度大约是每天大约一个新组件,在正常项目中使用的组件完成后,会有测试测试部门介入,届时更新速度将会降低,但所有目标全部指向兼容性与组件组合的测试.<br/>
与此同时,我们的性能优化是处于整个组件的开发生命周期中的.但我们保证:我们对外的接口保持一致.<br/>
Our current development speed is about one new component per day.After the components used in normal projects are completed, there will be a test and testing department to intervene.The update speed will be reduced by then, but all the goals are directed to the testing of compatibility and component combinations.<br/>
At the same time, our performance optimization is in the development life cycle of the entire component. But we guarantee: our external interface remains consistent.<br/>

# Pay Attention 注意

作为公司维护的项目,在此刻2020年4月27日,我们仍旧不推荐您将我们完成的组件使用在生产环境.<br/>
您可以持续关注此仓库,我们会随时更新我们的实际项目应用进展,您可以以此作为参考来确定是否使用本仓库.<br/>
As a project maintained by the company, at this moment on April 27, 2020, we still do not recommend that you use our completed components in a production environment.<br/>
You can continue to pay attention to this warehouse, and we will update our actual project application progress at any time.You can use this as a reference to determine whether to use this warehouse.<br/>

同样的,您如果发现在Nuget仓库出现我们的Release版本(>1.0.0),则您可以使用其作为企业门户级别的网站使用.<br/>
Similarly, if you find that our Release version (> 1.0.0) appears in the Nuget warehouse, you can use it as an enterprise portal level website.<br/>

## Environment Support 环境支持

- .NET Core 3.1
- Components version:5.0.0-preview.3.20215.14
- 支持服务端渲染 Support for server-side environments. 
- 支持Webassembly静态文件部署 Support for WebAssembly static file deployments.
- 支持4种主流浏览器引擎. Support for 4 major browsers engines, and Internet Explorer 11+ ([Blazor server-side](https://docs.microsoft.com/en-us/aspnet/core/blazor/supported-platforms?view=aspnetcore-3.1) only).
- 可以运行在Electron上. Runs directly on [Electron](http://electron.atom.io/) and other Web standard-based environments like [Web Window](https://github.com/SteveSandersonMS/WebWindow).

| [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/edge/edge_48x48.png" alt="IE / Edge" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br> Edge / IE | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/firefox/firefox_48x48.png" alt="Firefox" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Firefox | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/chrome/chrome_48x48.png" alt="Chrome" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Chrome | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/safari/safari_48x48.png" alt="Safari" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Safari | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/opera/opera_48x48.png" alt="Opera" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Opera | [<img src="https://raw.githubusercontent.com/alrra/browser-logos/master/src/electron/electron_48x48.png" alt="Electron" width="24px" height="24px" />](http://godban.github.io/browsers-support-badges/)</br>Electron |
| :---------: | :---------: | :---------: | :---------: | :---------: | :---------: |
| Edge 16 / IE 11† | 522 | 57 | 11 | 44 | Chromium 57



## Examples

我们拥有全球级别的CDN静态部署网站.

Building.....还没写完哈哈哈哈哈(•́⌄•́๑)૭✧

## Installation

LuanNiao Blazor  ***No release plan*** <br/>
>我们暂时不推荐你使用Blazor进行开发.Blazor目前的渲染能力以及对应的细节把控能力在我们看来是无法基于客户可交付的项目的.
 
>We don't recommend you to use Blazor for development for the time being. Blazor's current rendering capabilities and corresponding detail control capabilities are not in our opinion based on customer deliverables.

如果您不介意,您可以关注当前仓库,关注我们公司在实际项目中的使用情况,我们公司的项目可能会偏向于性能要求苛刻一些.<br/>
If you don't mind, you can pay attention to the current warehouse and pay attention to the use of our company in actual projects.Our company's projects may be biased toward demanding performance.


## Local Development

- 您先需要安装.NET Core SDK Install [.NET Core SDK](https://dotnet.microsoft.com/download) 3.1.102 or later.
- 克隆当前仓库 Clone to local development


  ```bash
  $ git clone https://github.com/luanniao/Blazor.Component.Antd.git
  ```
- 运行项目 Run the `DevelopmentCode`
- 访问 Visit http://localhost:5000 in your supported browser. 
- 我们去掉了HTTPS的local支持,没有意义,他的存在只是为了给你弹出一个提示框.We removed the local support of HTTPS, it doesn't make sense, its existence is just to pop up a prompt box for you.
- 您需要输入要查看的页面URL。 这个项目是我们的开发项目 You need to put the page URL in which you want to have a look. This project is our development project.
- 如果你想看到实际的内容,请跳转至对应目录 If you want to see ***demo*** pls move to [doc](https://github.com/luanniao/luanniao.club)
  
 


