📖 Day 7 Progress – Taxi Dodger
✅ Date: July 7, 2025

🚀 What we did today:
🔥 Rebuilt the stamina system from scratch:

Player now starts with 5 stamina.

Moving drains stamina by 1 point.

Dodging taxis replenishes stamina by 1 point (up to max).

When stamina reaches 0, the player can’t move.

✅ Fixed stamina bar UI:

Bar now increases and decreases smoothly.

Removed numbers for a cleaner look.

Added rounded corners for a modern, minimal style.

🛠 Cleaned up Movement.cs and PlayerStamina.cs:

Prevent null reference errors.

Integrated onDodge() call into dodge detection logic.

🟩 Verified that movement, stamina, and dodge mechanics work seamlessly together.

📂 Folder structure improvements:
Organized scripts into Player, Managers, and Spawners folders.

Placed all UI elements (stamina bar, buttons) in a UI folder.

📌 Next Steps (Day 7):
🎨 Improve art assets for buildings and sidewalks.

🚀 Add placeholders for power-ups:

Permanent speed reduction.

Temporary infinite stamina.

🛠 Balance rickshaw spawn timing at higher speeds.