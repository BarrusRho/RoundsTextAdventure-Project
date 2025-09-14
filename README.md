# RoundsTextAdventure — Escape the Island

A text-based adventure game built in Unity.  
Objective: **Escape the Island** by exploring, examining items, and solving a simple puzzle.

---

## 🎮 How to Play

1. Launch the project in Unity and open the **Bootstrap** scene.
2. Set game aspect to 9:16 or use the Device Simulator (I use the Asus ROG Phone) 
3. Enter **Play Mode**.
4. The game begins with the player trapped on an island.

### Commands
Type commands into the input field and press the **Submit** button.

- `look` — describe the current room, exits, and visible items.
- `examine <item>` — inspect an item (e.g. `examine note`).
- `get <item>` — take an item if possible (e.g. `get key`).
- `use <item>` — use an item (e.g. `use door`).
- `open <item>` — synonym for `use` (e.g. `open door`).
- `go <direction>` — move through a connection if unlocked (e.g. `go north`).
- `inventory` — list items you are carrying.
- `help` — show available commands.

### Example Playthrough
- go north
- go north
- examine well
- use staff
- get goldencoins
- go north
- talkto ferryman
- say merlin
- say albion
- give goldencoins

## 🗝️ Example Game Content

- **Island (start location)**
- **Bridge**
- **Chapel**
- **Dock**
- **The End (exit)**

---

## ⚙️ Implementation Details

- **Framework**:
    - Event-driven architecture with a central `EventBus`.
    - `ServiceLocator` pattern for dependency access.
    - **Services** for game state, audio, UI, and controllers.
    - **Actions** (`Go`, `Examine`, `Get`, `Use`, `Inventory`, `TalkTo`, `Say`, `Help`, `Look`) implemented as **ScriptableObjects**.

- **World Model**:
    - `Location` → holds description, connections, and items.
    - `Connection` → links between locations, lockable.
    - `Item` → interactive objects with configurable `Interaction`s.
    - `Interaction` → defines responses, enables/disables objects, teleports player, etc.

- **UI**:
    - `MainMenuUIView` + controller for the start menu.
    - `GameHUDUIView` + controller for gameplay input and output.

- **Player Flow**:
    - Game starts in `MainMenu`.
    - Starting the game shows the HUD and intro text.
    - Player enters commands → parsed by `GameplayCoordinator` → delegated to `ActionSO` verbs.
    - Actions affect the world state (`Item`s, `Connection`s, inventory).

---

## ✅ Assignment Requirements

- **Text-based interface** — implemented via Unity UI and command parser.
- **Short narrative (escape the island)** — authored in scene content.
- **At least two interactable items** — `Staff`, `Well` and others.
- **Clean C# scripts with SOLID principles** — modular services, controllers, and actions.
- **ScriptableObjects** — used for actions, audio, and config.

---

## 🚀 How to Run

1. Open the project in Unity (version 2022.3.62f1).
2. Open the **Bootstrap** scene.
3. Set game aspect to 9:16 or use the Device Simulator (I use the Asus ROG Phone)
4. Press **Play**.
5. Type commands into the input field and press the **Submit** button.

---

## 📝 Notes

- The framework is extensible:
    - Add new verbs by creating `ActionSO` assets.
    - Add new rooms by creating `Location`s and `Connection`s in the scene.
    - Add puzzles by wiring `Interaction`s on `Item`s.

- Audio is supported via `AudioClipsSO` and `AudioService`.
 