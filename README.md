# CardMagic

A Windows Forms application that demonstrates mathematical card magic tricks using C# and .NET Framework 4.8.

## Overview

CardMagic is an interactive desktop application that showcases two classic card magic tricks through an engaging graphical user interface. The application uses mathematical principles and card shuffling algorithms to predict user-selected cards, creating the illusion of magic.

## Features

- **Two Interactive Magic Tricks**
  - **Trick 1**: A classic card selection and prediction trick using a 3x7 card distribution system
  - **Trick 2**: A pair-based prediction trick with 10 card pairs

- **Dynamic Card Shuffling**: Implements random shuffling algorithms to distribute and reorganize cards while maintaining mathematical predictability

- **User-Friendly GUI**: Built with Windows Forms, featuring an intuitive navigation system with:
  - Main menu with options to select tricks
  - Per-trick instructions and step-by-step guidance
  - About dialog with trick explanations
  - Card visualization with image resources

- **Card Resources**: Complete deck of 52 playing cards plus joker, embedded in the CardMagic.Logic library and consumed by the UI via the ResourceProvider class.

## Technical Details

### Architecture

The application follows a multi-form Windows Forms architecture:

- **First.cs**: Main entry point and menu screen
  - Displays welcome screen with options to play tricks or exit
  - Provides navigation to Trick 1, Trick 2, and About information

- **Trick1.cs**: First magic trick implementation
  - Creates 53 PictureBox controls for card display
  - Implements card shuffling using Random class
  - Distributes cards into three 7-card rows
  - Guides user through selection process
  - Predicts selected card through mathematical elimination

- **Trick2F.cs**: Second magic trick implementation
  - Uses a jagged array structure for 10 card pairs
  - Implements pair selection and shuffling
  - Predicts selected pair through algorithm
  - Provides visual feedback throughout the trick

- **About.cs**: Information and navigation form
  - Displays trick explanations and rules
  - Manages navigation back to parent forms

- **Final.cs**: Result/prediction display form
  - Shows the predicted card to the user

### Technology Stack

- **Language**: C#
- **Framework**: .NET Framework 4.8
- **UI Framework**: Windows Forms
- **IDE**: Visual Studio Community 2026

### Project Structure

```
CardMagic.sln                         # Solution file

CardMagic/                            # Windows Forms UI project
├── CardMagic.csproj                  # Project file
├── Program.cs                        # Application entry point
├── First.cs                          # Main menu form
├── Trick1.cs                         # First magic trick (UI)
├── Trick1.Designer.cs                # Designer auto-generated
├── Trick2.cs                         # Second magic trick (UI)
├── Trick2.Designer.cs                # Designer auto-generated
├── Final.cs                          # Result display form
├── Final.Designer.cs                 # Designer auto-generated
├── About.cs                          # Information form
├── About.Designer.cs                 # Designer auto-generated
├── App.config                        # Application configuration
├── Properties/                       # Assembly info and resources
│   ├── AssemblyInfo.cs               # Version and metadata
│   ├── Resources.resx                # Embedded resources (forms)
│   ├── Resources.Designer.cs         # Auto-generated resources
│   ├── Settings.settings             # Application settings
│   └── Settings.Designer.cs          # Auto-generated settings
├── Game.ico                          # Application icon
└── *.resx                            # Form-specific resources

CardMagic.Logic/                      # Class library (core logic & resources)
├── CardMagic.Logic.csproj            # Logic project file
├── CardShuffler.cs                   # Shuffling utilities
├── Trick1Engine.cs                   # Encapsulated logic for Trick 1
├── Trick2Engine.cs                   # Encapsulated logic for Trick 2
├── ResourceProvider.cs               # Resource loader for embedded images
├── Properties/
│   └── AssemblyInfo.cs               # Version and metadata
└── Resources/                        # Embedded card and background images
    ├── 1.png to 53.png               # Playing cards (52 + joker)
    ├── 4865.jpg                      # Background image
    └── q02th.jpg                     # Background image
```

### Logic Layer (CardMagic.Logic)

A dedicated class library project, CardMagic.Logic, separates core trick algorithms and resource management from the UI. It contains:

- **CardShuffler**: Generic shuffling utilities for card distribution and reorganization (used by both tricks)
- **Trick1Engine**: Encapsulates the 3×7 distribution, row selection, deck reorganization, and prediction logic
- **Trick2Engine**: Encapsulates pair creation, pair selection tracking, and pair prediction logic
- **ResourceProvider**: Static class that loads embedded card images from the assembly using reflection. It supports multiple fallback strategies:
  1. Direct loading from embedded resources using `Assembly.GetManifestResourceStream()`
  2. Fallback to UI project's Properties.Resources if available
  3. Fallback to file system locations during development

**Embedded Resources**: All card images (1-53.png) and background images (JPGs) are embedded in CardMagic.Logic using MSBuild wildcards for automatic inclusion:
```xml
<EmbeddedResource Include="Resources\*.png">
  <LogicalName>CardMagic.Logic.Resources.%(Filename)%(Extension)</LogicalName>
</EmbeddedResource>
```

This separation improves testability, maintainability, and makes resource management centralized and decoupled from the UI layer.

### Card Representation and Resources

- **Card Images**: 52 standard playing cards (4 suits × 13 ranks) + 1 joker = 53 total images
  - Images 1-52: Standard playing cards numbered by suit and rank
  - Image 53: Joker card
- **Dimensions**: All card images are 75×90 pixels for consistent UI display
- **Embedding**: All imagery is embedded in CardMagic.Logic assembly at build time for distribution without external dependencies
- **Access**: UI layer accesses resources through CardMagic.Logic.ResourceProvider.GetCardImage(index)

## How It Works

### Trick 1: 3x7 Distribution Method

1. User is presented with 21 cards arranged in three rows of seven cards each
2. User selects a card and identifies which row it belongs to
3. Application shuffles and redistributes cards based on user's row selection
4. Process repeats for two more rounds with mathematical elimination
5. Final row is displayed with only one card visible - the predicted card

### Trick 2: Pair-Based Prediction

1. User selects one of 10 card pairs to remember
2. Application shuffles and reorganizes the pairs
3. Through strategic card distribution, application tracks the selected pair
4. Final display reveals the predicted pair

## How to Use

1. **Launch Application**: Run CardMagic.exe
2. **Main Menu**: Choose between:
   - Play Trick 1
   - Play Trick 2
   - About (view trick instructions)
   - Exit

3. **Playing a Trick**: 
   - Read on-screen instructions carefully
   - Follow prompts to select cards or pairs
   - Click shuffle/continue buttons as directed
   - View the predicted result

4. **Navigation**: Use Back buttons to return to previous screens

## Code Highlights

### Loading Card Images via ResourceProvider (Trick1.cs)
```csharp
private PictureBox SizeImage(PictureBox Pb, int i)
{
    // Loads card image from CardMagic.Logic embedded resources
    Image img = ResourceProvider.GetCardImage(i);
    if (img == null)
    {
        // Fallback to UI project's resources if available
        ResourceManager rm = Properties.Resources.ResourceManager;
        img = (Bitmap)rm.GetObject(string.Format("{0}", i));
    }

    Pb.Image = img;
    Pb.SizeMode = PictureBoxSizeMode.StretchImage;
    return Pb;
}
```

### Card Shuffling Algorithm (Trick1.cs)
```csharp
public void PickDeck()
{
    Random rnd = new Random();
    for (var i = 0; i < 100; i++)
    {
        int firstCard = rnd.Next(0, 53);
        int secondCard = rnd.Next(0, 53);
        if (firstCard != secondCard)
        {
            var t = pictures[firstCard];
            pictures[firstCard] = pictures[secondCard];
            pictures[secondCard] = t;
        }
    }
}
```

### Dynamic PictureBox Creation
```csharp
var newPicBox = new PictureBox()
{
    Width = 75,
    Height = 90,
    BorderStyle = BorderStyle.Fixed3D
};
```

## Author

- **Original Developer**: Akshay Shekade
- **Date**: October 9, 2017
- **Language**: C#

## Version Information

- **Version**: 1.0.0.0
- **Assembly Name**: CardMagic
- **Target Framework**: .NET Framework 4.8
- **Platform**: AnyCPU (Windows only)

## License

Copyright © 2023

## Repository

- **Repository**: https://github.com/keystrikes/CardMagic
- **Branch**: master

## Building and Running

### Requirements
- Windows OS
- .NET Framework 4.8 or later
- Visual Studio Community 2026 (or compatible IDE)

### Build Instructions
1. Open CardMagic.sln in Visual Studio
2. Build Solution (Ctrl+Shift+B)
3. Run (F5 or Ctrl+F5)

### Output
- Debug build: `bin/Debug/CardMagic.exe`
- Release build: `bin/Release/CardMagic.exe`

## Mathematical Principle

The tricks rely on the mathematical principle of **elimination and tracking**:
- In Trick 1, eliminating cards based on user selection reduces possibilities
- By the third round, the algorithm knows which card must be selected
- Trick 2 uses similar pair-tracking methodology to narrow down to the correct pair

## Future Enhancement Possibilities

- Add more card tricks
- Implement difficulty levels
- Add sound effects and animations
- Cross-platform support using WPF or .NET Core
- Replay functionality
- Score/statistics tracking
- Customizable card designs