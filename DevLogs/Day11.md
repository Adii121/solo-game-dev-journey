📝 Day 11 Devlog – Taxi Dodger
📅 Date: 11th Development Day

✅ What We Did Today:
🎶 Background Audio System
Added background music to both Main Menu and Game Scene.

Used two separate tracks:

Calm & catchy music for Main Menu.

Fast-paced looping music for Game Scene.

Fixed an issue where background music would stop playing between scenes.

✅ Solved by using dedicated AudioSources in each scene.

🛡️ New Power-Up: Shield
Implemented a Shield Power-Up:

Player becomes invincible for 5 seconds after picking up.

Visual feedback: Blue circular shield appears around the player.

Added shield icon UI when active.

Fixed edge cases:

If a taxi hits the player while the shield is active, no Game Over is triggered.

Shield disappears after the duration ends.

🎨 Voxel Art Icon for Shield
Designed and added a voxel-style shield icon for the UI.

📝 Other Improvements
Fixed minor spawn logic bugs for Rickshaw and Power-Ups.

Cleaned up unused scripts and components from GameObjects.

🗓️ Next Steps for Day 12:
🎧 Add shield activation & deactivation sound effects.

🛠 Final gameplay polish:

Slightly adjust Rickshaw spawn gaps for better flow.

Tweak power-up appearance rate.

🕹️ Test mobile controls thoroughly.