# The Masked Regime

<p>
  <img alt="Unity" src="https://img.shields.io/badge/Unity-6000.2.10f1-black?logo=unity">
  <img alt="Language" src="https://img.shields.io/badge/C%23-scripts-239120?logo=csharp&logoColor=white">
  <img alt="Players" src="https://img.shields.io/badge/Players-2%20local%20co--op-purple">
  <img alt="Platform" src="https://img.shields.io/badge/Platform-Windows-0078D6?logo=windows&logoColor=white">
  <img alt="Made for" src="https://img.shields.io/badge/Made%20for-Game%20Jam-orange">
</p>

**A two-player local co-op race, made for a game jam with the theme "masks".**
Two runners share one keyboard, race through an obstacle course in a mask-themed world, and only win if **both**
of them reach the end point.

## How to play

- Two players run the same course on one keyboard, each with their own camera view.
- Obstacles and barriers cost a **life** (shown as hearts on screen). Lose all your lives and the run is lost
  for both of you.
- Some hazards, like the pebbles, also **rewind** you: you are thrown back to where you were a few seconds ago, so you
  lose time as well as health.
- Pick up a **mask** and the hurdles are temporarily disabled for about **6 seconds**.
- The level is only completed when **both players reach the end point**. Help each other, because one finisher alone
  does not win.

## Controls

| Action | Player 1 | Player 2 |
| --- | --- | --- |
| Move | Arrow keys | `W` `A` `S` `D` |
| Jump | `Right Ctrl` | `Space` |
| Sprint | `Right Shift` | `Left Shift` |
| Crouch | `Numpad 0` | `C` |

## Game flow

```
Main Menu -> LEVEL (the race)
                 ├─ any player runs out of lives -> LostGame -> restart LEVEL
                 └─ both players reach the end   -> EscapeScene -> GameOver -> Main Menu / Quit
```

## Play it

Download **The Masked Regime.zip** from the repository's **Releases** page, extract it, and run **`bismillah.exe`**
(the executable keeps the project's original name). Windows only.

## Open the project in Unity

1. Install **Unity 6000.2.10f1** (Unity Hub -> Installs).
2. Clone this repository and add the folder in Unity Hub.
3. This repository contains the game's own code, scenes and settings. Third-party art, audio and the Unity Starter
   Assets package are **not** redistributed here (see [Credits](#credits-and-third-party-assets)). Import them into
   `Assets/`, then open `Assets/Scenes/MainMenu.unity`. Until they are imported, scenes will show missing references.
4. Build order: `MainMenu` -> `LEVEL` -> `LostGame` -> `EscapeScene` -> `GameOver`.

## Project structure

```
The-Masked-Regime/
├── Assets/
│   ├── Scripts/                 GameManager, PlayerLives, PlayerRewind, ObstacleDamage, Pebble, LoadGameOver, LostGameUI
│   ├── DualInputManager.cs      Two-player keyboard input
│   ├── HurdlesHandler.cs        Switches the hurdles' physics layer (used by masks)
│   ├── PowerHandler.cs          Mask pickups and the timed hurdle bypass
│   ├── EndPoint.cs              Finish line trigger for each player
│   ├── GameOverUI.cs            Main menu / quit buttons
│   ├── Scenes/                  MainMenu, EscapeScene, GameOver
│   ├── StarterAssets/.../Scenes LEVEL (the race) and LostGame
│   ├── black_mask.fbx           The mask pickup model
│   └── *.jpeg                   Start, lost and game-over screens
├── Packages/                    Unity package manifest
└── ProjectSettings/
```

### How the main systems work

| System | Script | What it does |
| --- | --- | --- |
| Two-player input | `DualInputManager` | Feeds keyboard input to two separate Starter Assets controllers |
| Lives | `PlayerLives` | Heart UI; colliding with an `Obstacle` costs one life, and zero lives ends the run |
| Obstacle damage | `ObstacleDamage` | Trigger hazards: life loss, sound and a red screen flash |
| Rewind | `PlayerRewind`, `Pebble` | Records the player's recent positions and, when a pebble hits, sends them back to the oldest one (`rewindTime`, 5 seconds in the level), with a yellow flash |
| Masks | `PowerHandler`, `HurdlesHandler` | Picking up the black mask moves the hurdles to a pass-through layer for 6 seconds, then restores them |
| Win condition | `EndPoint`, `GameManager` | Both `Player1` and `Player2` must trigger the end point before the win scene loads |

## Built with

- **Unity 6** (6000.2.10f1), C#
- Unity **Starter Assets: Third Person Controller** and the **Input System**
- **TextMesh Pro**

## Status and known limitations

A game jam prototype. Things that are unfinished:

- Only the **black mask** is implemented. The white mask has a placeholder in `PowerHandler` but no effect yet.
- Rewind currently comes from the **pebble** hazard and applies to Player 2; the barrier hazard (`ObstacleDamage`) only
  takes a life and responds to Player 1.
- Some scripts still contain debug logging.

## Credits and third-party assets

The game uses assets made by other people. None of them are included in this repository, and each one stays under its
publisher's own license:

- Unity Starter Assets (Third Person Controller)
- Abandoned World environment pack, Stylized Stone, Rolling Balls Sci-fi Pack, BTM Assets
- Hovl Studio and Vefects visual effects, VolumetricLines, YughuesFreeMetalMaterials, RSG, Brackeys assets
- Character models and animations
- Sound effects and music tracks
- TextMesh Pro (Unity)

If you are the publisher of one of these and would like the credit changed, please open an issue.

---

Repository maintained by [@zubiajunaid954-bot](https://github.com/zubiajunaid954-bot).
