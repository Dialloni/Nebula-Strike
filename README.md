# Nebula Strike

A top-down 2.5D space shooter built in **Unity 6** during the **AI Game Dev Bootcamp** (Days 1–5).
Pilot a starfighter, blast incoming asteroids and enemy ships, rack up a score, and restart when you fall.

## Demo

▶️ **[Watch the gameplay demo](https://www.loom.com/share/c20cf4eaf8b447bea2a2e29e1a87964f)**

## Gameplay

- Fly your ship inside the play area and fire a triple-spread shot.
- Dodge waves of asteroids and enemy ships that spawn from the top.
- Enemy ships shoot back automatically and weave side-to-side to dodge your fire.
- Destroy hazards to raise your score. Get hit and it's **Game Over** — press **R** to restart.

## Controls

| Action | Input |
|--------|-------|
| Move | WASD / Arrow keys |
| Shoot | Left Mouse Button |
| Restart (after Game Over) | R |

## Features

- Player movement with boundary clamping and ship tilt
- Triple-spread player shooting
- Wave-based hazard spawning (asteroids + enemy ships)
- Enemy AI: automatic shooting (`WeaponController`) and evasive dodging (`EvasiveManeuver`)
- Collision, explosions, and player/enemy destruction
- On-screen UI (TextMeshPro): live score, red **Game Over!**, restart prompt
- Scene restart on key press

## Scripts (`Assets/Script/`)

| Script | Role |
|--------|------|
| `PlayerController.cs` | Player movement + triple-spread shooting |
| `Mover.cs` | Constant forward velocity for bullets, asteroids, enemies |
| `RandomRotator.cs` | Random tumble on asteroids |
| `DestroyByContact.cs` | Collision handling, explosions, score, Game Over |
| `DestroyByBounder.cs` | Cleans up objects leaving the play area |
| `DestroyByTime.cs` | Removes explosion effects after a delay |
| `WeaponController.cs` | Enemy automatic fire |
| `EvasiveManeuver.cs` | Enemy dodging movement |
| `BGScroller.cs` | Scrolling background loop |
| `GameController.cs` | Wave spawning, score, Game Over, restart, UI |

## Built With

- Unity 6
- C#
- TextMeshPro for UI
- AI assistance for writing/explaining scripts, debugging, and UI guidance

## Author

Abubakar Diallo — AI Game Dev Bootcamp
