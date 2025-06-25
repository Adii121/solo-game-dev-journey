# 🗓️ Day 2 – Score System Upgrade & Kill Zone

## ✅ What I Did
- Fixed scoring system to count **actual dodges**, not time
- Added a **Kill Zone** trigger area below the screen
- Score only increases if a block passes through the kill zone **without hitting the player**
- Removed reliance on `OnBecameInvisible()` (was delayed for large blocks)
- Added `Block.cs` and `KillZone.cs` scripts
- Improved game efficiency by destroying objects at the right time

## 🔍 Key Learnings
- Used `OnTriggerEnter2D()` for accurate collision handling
- Used tags and component checks to manage score safely
- Exposed public variables using getters in C#

## 🚀 Next Steps
- Display "Dodges: X" in UI
- Add roguelike-style movement upgrade: +5f per dodge
- Show current stamina bar or movement points visually
