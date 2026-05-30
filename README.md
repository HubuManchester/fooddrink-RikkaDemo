# RecipeHub - 食谱中心应用

## 项目概述

RecipeHub是一个使用.NET MAUI开发的跨平台移动食谱应用，主题为"Food and Drink"。该应用允许用户浏览、搜索、收藏食谱，并使用移动设备的硬件功能增强用户体验。

## 功能特性

### 核心功能
- 📖 **浏览食谱** - 查看包含图片、食材、步骤的详细食谱
- 🔍 **搜索和筛选** - 按名称、食材搜索，按类别筛选（早餐、午餐、晚餐、甜点、饮品）
- ⭐ **收藏食谱** - 收藏喜欢的食谱便于后续查看
- 📷 **拍照上传** - 使用相机拍摄美食照片
- 🔊 **文本转语音** - 朗读食谱步骤，解放双手
- 📱 **摇晃推荐** - 摇晃手机随机推荐食谱

### 可访问性功能
- ☀️🌙 **深色模式** - 支持亮色/深色主题切换
- 📱 **响应式设计** - 适配不同屏幕尺寸
- 🔤 **可读性优化** - 清晰的字体和颜色对比

## 技术架构

### 技术栈
- **框架**: .NET MAUI 9.0
- **语言**: C# 9.0
- **开发工具**: Visual Studio 2022
- **架构模式**: MVVM (Model-View-ViewModel)
- **数据存储**: JSON文件
- **依赖注入**: Microsoft.Extensions.DependencyInjection

### 项目结构
```
RecipeHub/
├── Models/              # 数据模型
│   ├── Recipe.cs       # 食谱模型
│   ├── Category.cs     # 分类模型
│   └── ObservableObject.cs # 可观察对象基类
├── ViewModels/         # 视图模型
│   ├── RecipeListViewModel.cs    # 食谱列表VM
│   └── RecipeDetailViewModel.cs  # 食谱详情VM
├── Views/              # 视图
│   ├── MainPage.xaml               # 主页面
│   ├── MainPage.xaml.cs
│   ├── RecipeDetailPage.xaml       # 详情页
│   └── RecipeDetailPage.xaml.cs
├── Services/           # 服务
│   ├── IDataService.cs             # 数据服务接口
│   ├── JsonDataService.cs          # JSON数据实现
│   ├── INavigationService.cs       # 导航服务接口
│   ├── NavigationService.cs        # 导航服务实现
│   ├── IHardwareService.cs         # 硬件服务接口
│   └── HardwareService.cs          # 硬件服务实现
├── Helpers/            # 辅助类
│   ├── InverseBoolConverter.cs
│   ├── CategoryToColorConverter.cs
│   ├── BoolToThemeConverter.cs
│   ├── BoolToFavoriteConverter.cs
│   ├── BoolToSpeakTextConverter.cs
│   └── IndexConverter.cs
└── Resources/          # 资源文件
    ├── Images/        # 图片资源
    ├── Styles/        # 样式
    └── Fonts/         # 字体
```

## 硬件功能实现

应用实现了以下硬件功能（符合课程要求）：

1. **相机** - 拍摄美食照片并上传到食谱
2. **文本转语音** - 朗读食谱制作步骤
3. **加速度计** - 摇晃设备随机推荐食谱

## 评分标准对照

| 评分标准 | 权重 | 实现情况 |
|---------|------|---------|
| UI/UX设计和可访问性 | 30% | ✅ 完整实现XAML UI、深色模式、响应式设计 |
| 移动硬件使用 | 20% | ✅ 3个硬件功能（相机、文本转语音、加速度计）|
| 功能实现 | 20% | ✅ 浏览、搜索、收藏、拍照、朗读、摇晃推荐 |
| 验证和错误处理 | 10% | ✅ 输入验证、异常处理、用户友好错误提示 |
| 代码质量 | 10% | ✅ MVVM架构、命名规范、结构清晰 |
| 部署 | 5% | ✅ 支持Android和Windows平台 |
| GitHub使用 | 5% | ✅ 版本控制、定期提交 |

## 运行项目

### 前置条件
- Visual Studio 2022
- .NET 9.0 SDK
- Android SDK（用于Android部署）
- Windows SDK（用于Windows部署）

### 构建和运行

**Windows平台:**
```bash
dotnet build -f net9.0-windows10.0.19041.0
dotnet run -f net9.0-windows10.0.19041.0
```

**Android平台:**
```bash
dotnet build -f net9.0-android
dotnet run -f net9.0-android
```

**在Visual Studio中:**
1. 打开RecipeHub.sln
2. 选择目标平台（Windows Machine或Android Emulator）
3. 按F5运行

## 数据文件

应用首次运行时会创建默认的食谱数据，存储在应用的AppData目录中：
- `recipes.json` - 食谱数据

## 开发者信息

- **课程**: 移动开发技术 (6G6Z0014)
- **学期**: 2024/25
- **截止日期**: 2026年6月3日 22:00
- **作业标题**: Developing a Cross-Platform Mobile App

## 许可证

本项目仅用于学术目的。