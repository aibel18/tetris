# Console Tetris

A console tetris written in C#

## File Structure

In this project you'll find the following directories and files:

```
tetris/

├── Assets
├── Properties
├── src
│   ├── controller
│   │   ├── Action.cs
│   │   ├── CollisionController.cs
│   │   ├── ConsoleInputHandler.cs
│   │   ├── FigureController.cs
│   │   ├── FigureType.cs
│   │   ├── Game.cs
│   │   └── IInputHandler.cs
│   ├── model
│   │   ├── Figure.cs
│   │   ├── Grid.cs
│   │   └── Vector2Int.cs
│   ├── util
│   │   ├── File.cs
│   │   └── Letter.cs
│   └── view
│       ├── ConsoleRender.cs
│       └── IRender.cs
├── .gitignore
├── LICENCE.md
├── Program.cs
├── README.cs
└── tetris.csproj

```

## Run

```
cd tetris
dotnet build
dotnet run
```
### how to use

| key    | action          |
|--------|-----------------|
| Esc    | Exit            |
| S      | Save            |
| Y      | Load saved game |
| R      | Restart         |
| ←      | Move left       |
| →      | Move right      |
| ↑      | Rotation        |
| ↓      | Rotation inv    |
| anyone | Empty action    |

- Interface
```
 ==== My Tetris score: 0 ====
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+               Q               +
+   L         Q Q   H           +
+ L L L L L L L Q H H H         +
```

- saved game (S)
```
 ==== My Tetris score: 1 ====
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                         M S S +
+       A       Q   I     M M S +
+   L   A A A Q Q I I H   T M S +
sgame saved!!
```

- load game (Y)
```
load the game? (y/n)
y==== My Tetris score: 1 ====
+                               +
+             O O               +
+               O               +
+               O               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                               +
+                         M     +
+       A       Q   I     M M   +
+   L   A A A Q Q I I H   T M   +
```
## Resources
- .NET core 3.1

## Licensing

- Copyright 2021 Abel Ticona (https://aibel18.github.io)
- Abel Ticona [license](LICENSE.md)

## Useful Links
