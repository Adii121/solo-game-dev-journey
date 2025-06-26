# 🗓️ Day 4 – Movement, Stamina System & Score-Based Difficulty

## ✅ What I Did

### 🎮 Player Movement System
- Integrated movement with stamina consumption (roguelike style).
- Movement only allowed if the player has enough stamina.

### 🔋 Roguelike Stamina System
- Player starts with 10f stamina (`currentStamina`).
- Dodging a block (avoiding collision) rewards +5f stamina.
- Capped maximum stamina at 20f to prevent infinite stacking.
- Subtracted stamina based on actual distance moved (`-= Mathf.Abs(movement)`).

### 🧠 Clean Architecture
- Replaced confusing `moveLimit`/`moveUsed` with `maxStamina` and `currentStamina`.
- Stamina usage and rewards are now clean, readable, and scalable.

### 💥 Dodge Detection Logic
- Updated `KillZone.cs` to:
  - Detect if a block was dodged (using `HasHitPlayer`)
  - Call `GainMovement(5f)` on successful dodge
- Encourages reactive and smart play to earn more movement.

### 🧱 Score-Based Difficulty
- In `GameManager.cs`, block fall speed increases with score:
  ```csharp
  blockFallSpeed = 2f + (score / 5f);

🐞 Fixed Bugs
    -Resolved UnassignedReferenceException by assigning block prefab in BlockSpawner.
    -Fixed stamina increasing incorrectly during movement (was +=, now correctly -=).
    -Fixed HUD logic by accessing stamina values from the Movement script (player.currentStamina).
