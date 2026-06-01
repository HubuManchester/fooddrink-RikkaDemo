# RecipeHub - Food & Drink Mobile Application

## Project Overview

RecipeHub is a cross-platform mobile recipe application developed using .NET MAUI with the theme "Food and Drink". The application allows users to browse, search, and save recipes, while leveraging mobile device hardware features to enhance user experience.

## Course Assignment Details

- **Course**: Mobile Application Development (6G6Z0014)
- **Academic Year**: 2024/25
- **Assignment**: Developing a Cross-Platform Mobile App
- **Deadline**: June 3, 2026, 22:00
- **Theme**: Food and Drink

## Features

### Core Functionality
- 📖 **Browse Recipes** - View detailed recipes with images, ingredients, and cooking instructions
- 🔍 **Search and Filter** - Search by name or ingredients, filter by category (Breakfast, Lunch, Dinner, Dessert, Drink)
- ⭐ **Favorite Recipes** - Save favorite recipes for quick access
- ➕ **Add Recipes** - Create new recipes with all details including photos
- ✏️ **Edit Recipes** - Modify existing recipes
- 🗑️ **Delete Recipes** - Remove unwanted recipes
- 📷 **Camera Integration** - Take photos of dishes using device camera
- 🔊 **Text-to-Speech** - Read recipe instructions aloud for hands-free cooking
- 📱 **Shake-to-Recommend** - Shake device to get random recipe suggestions

### Accessibility Features
- ☀️🌙 **Dark Mode** - Support for light/dark theme switching
- 📱 **Responsive Design** - Adapts to different screen sizes and orientations
- 🔤 **Readability Optimization** - Clear typography and color contrast for better accessibility
- ♿ **Accessible UI** - Proper color contrast ratios and touch target sizes

## Technical Architecture

### Technology Stack
- **Framework**: .NET MAUI 9.0
- **Language**: C# 9.0
- **IDE**: Visual Studio 2022
- **Architecture Pattern**: MVVM (Model-View-ViewModel)
- **Data Storage**: JSON file-based persistence
- **Dependency Injection**: Microsoft.Extensions.DependencyInjection

### Project Structure
```
RecipeHub/
├── Models/              # Data Models
│   ├── Recipe.cs       # Recipe data model
│   ├── Category.cs     # Category data model
│   └── ObservableObject.cs # Base class for observable objects
├── ViewModels/         # View Models
│   ├── RecipeListViewModel.cs      # Recipe list view model
│   ├── RecipeDetailViewModel.cs    # Recipe detail view model
│   ├── AddRecipeViewModel.cs       # Add recipe view model
│   └── EditRecipeViewModel.cs      # Edit recipe view model
├── Views/              # Views
│   ├── MainPage.xaml                  # Main page
│   ├── MainPage.xaml.cs
│   ├── RecipeDetailPage.xaml          # Recipe detail page
│   ├── RecipeDetailPage.xaml.cs
│   ├── AddRecipePage.xaml             # Add recipe page
│   ├── AddRecipePage.xaml.cs
│   ├── EditRecipePage.xaml            # Edit recipe page
│   └── EditRecipePage.xaml.cs
├── Services/           # Services
│   ├── IDataService.cs             # Data service interface
│   ├── JsonDataService.cs          # JSON data implementation
│   ├── INavigationService.cs       # Navigation service interface
│   ├── NavigationService.cs        # Navigation service implementation
│   ├── IHardwareService.cs         # Hardware service interface
│   └── HardwareService.cs          # Hardware service implementation
├── Helpers/            # Helper Classes
│   ├── InverseBoolConverter.cs     # Boolean inversion converter
│   ├── CategoryToColorConverter.cs # Category color converter
│   ├── BoolToThemeConverter.cs     # Theme boolean converter
│   ├── BoolToFavoriteConverter.cs  # Favorite boolean converter
│   ├── BoolToSpeakTextConverter.cs # TTS button text converter
│   └── IndexConverter.cs           # Index display converter
└── Resources/          # Resources
    ├── Images/        # Image resources
    ├── Styles/        # Styles
    └── Fonts/         # Fonts
```

## Hardware Features Implementation

The application implements the following hardware features as required by the assignment:

1. **Camera** 📷
   - Take photos of dishes using the device camera
   - Attach photos to recipes
   - Proper permission handling for Android and iOS

2. **Text-to-Speech (TTS)** 🔊
   - Read recipe cooking instructions aloud
   - Support for stopping and resuming playback
   - Useful for hands-free cooking experience

3. **Accelerometer** 📱
   - Detect device shake gesture
   - Recommend random recipes on shake
   - Background sensor management

## Assignment Grading Criteria Alignment

| Grading Criteria | Weight | Implementation Status |
|------------------|--------|---------------------|
| UI/UX Design and Accessibility | 30% | ✅ Complete XAML UI, dark mode, responsive design, color contrast compliance |
| Mobile Hardware Usage | 20% | ✅ 3 hardware features (Camera, Text-to-Speech, Accelerometer) with proper error handling |
| Functionality | 20% | ✅ Browse, search, filter, favorite, add, edit, delete recipes, TTS, shake recommendation |
| Validation and Error Handling | 10% | ✅ Input validation, exception handling, user-friendly error messages, data migration |
| Code Quality | 10% | ✅ MVVM architecture, proper naming conventions, clear structure, DI pattern |
| Deployment | 5% | ✅ Tested on Android and Windows platforms |
| GitHub Usage | 5% | ✅ Version control with regular commits, clear commit messages |

## UI/UX Design Highlights

### Visual Design
- Modern, clean interface with card-based recipe display
- Intuitive navigation with clear visual hierarchy
- Consistent color scheme with proper color contrast for accessibility
- Fire emoji 🔥 for popular/high-calorie recipes
- Heart emoji ❤️ for favorite indication
- Smooth animations and transitions

### Accessibility Features
- **Dark Mode**: Toggle between light and dark themes for visual comfort
- **High Contrast**: WCAG AA compliant color ratios (4.5:1 minimum)
- **Touch Targets**: Minimum 44x44 dp tap targets for better usability
- **Responsive Layout**: Adapts to phone, tablet, and desktop screen sizes
- **Font Scaling**: Respects system font size preferences
- **Screen Reader Support**: Proper semantic labeling for screen readers

### User Experience
- **Shake-to-Discover**: Fun and intuitive way to find new recipes
- **Hands-Free Cooking**: TTS allows following instructions while cooking
- **Quick Actions**: Favorite and view recipe details with minimal taps
- **Search & Filter**: Fast recipe discovery with real-time search
- **Photo Integration**: Personal recipe collection with food photos

## Data Management

### Data Structure
- **Recipes**: List of recipe objects with full metadata
- **Persistence**: JSON file storage in application data directory
- **Default Data**: 6 pre-loaded recipes (Breakfast, Lunch, Dinner, Dessert, Drink categories)
- **Data Migration**: Automatic detection and migration from old Chinese data to English

### CRUD Operations
- **Create**: Add new recipes with validation
- **Read**: Browse, search, and filter recipes
- **Update**: Edit existing recipe details and photos
- **Delete**: Remove recipes with confirmation dialog

## Validation and Error Handling

### Input Validation
- Required field validation (name, description, ingredients, instructions)
- Numeric range validation (prep time, cook time, servings, calories)
- Category and difficulty selection validation
- Image path validation

### Error Handling
- Camera permission errors with clear messages
- File I/O error handling for data persistence
- TTS error handling
- Accelerometer availability checking
- Network error handling (if applicable)
- User-friendly error dialogs with actionable information

## Installation and Running

### Prerequisites
- Visual Studio 2022 (Community, Professional, or Enterprise)
- .NET 9.0 SDK
- Android SDK (for Android deployment)
- Windows SDK (for Windows deployment)
- Physical Android device or emulator for testing

### Build and Run

**Windows Platform:**
```bash
dotnet build -f net9.0-windows10.0.19041.0
dotnet run -f net9.0-windows10.0.19041.0
```

**Android Platform:**
```bash
dotnet build -f net9.0-android
dotnet run -f net9.0-android
```

**In Visual Studio:**
1. Open `RecipeHub.sln`
2. Select target platform (Windows Machine or Android Emulator/Device)
3. Press F5 to run

### Deployment to Android Device

1. Enable Developer Options and USB Debugging on your Android device
2. Connect device via USB
3. Ensure device is recognized by ADB: `adb devices`
4. In Visual Studio, select your device from the deployment target dropdown
5. Press F5 to build and deploy

## Data Files

The application creates default recipe data on first run, stored in the application's data directory:
- `recipes.json` - Recipe data file with all recipes

### Default Recipes
The app includes 6 sample recipes:
1. Classic Tomato Scrambled Eggs (Breakfast)
2. Caesar Salad (Lunch)
3. Grilled Salmon with Lemon (Dinner)
4. Chocolate Lava Cake (Dessert)
5. Mango Smoothie (Drink)
6. Kung Pao Chicken (Lunch)

## Screenshots and Demo

### Application Screens
- **Main Page**: Recipe list with search, filter, and category tabs
- **Recipe Detail**: Full recipe with photo, ingredients, and instructions
- **Add Recipe**: Form to create new recipes
- **Edit Recipe**: Form to modify existing recipes
- **Dark Mode**: Alternate theme for visual comfort

### Screencast
A 12-15 minute screencast demonstrates:
- Application overview and features
- Recipe browsing and search
- Category filtering
- Adding a new recipe
- Editing an existing recipe
- Deleting a recipe
- Favorite management
- Camera integration
- Text-to-Speech functionality
- Shake-to-recommend feature
- Dark mode toggle
- Accessibility features

## Screenshots
*(Add screenshots when ready)*

## Future Enhancements

Potential improvements for future versions:
- Online recipe sharing
- Recipe comments and ratings
- Nutritional analysis
- Meal planning calendar
- Shopping list generation
- Cloud sync across devices
- Multi-language support

## License

This project is created for academic purposes only.

## Acknowledgments

- .NET MAUI Team
- University of Greenwich
- Mobile Development Course (6G6Z0014)