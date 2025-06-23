# 🗓️ Day 1 – Setup + Dodge Game Prototype

## ✅ What I Did
- Installed Unity Hub and Unity 2022.3 LTS
- Set up a new 2D project in Unity
- Learned Unity Editor basics: Scene, Hierarchy, Inspector, Console
- Created a player square and added movement using C#
- Learned to use Rigidbody2D and BoxCollider2D
- Built a prefab system for falling blocks
- Spawner spawns random falling blocks at regular intervals
- Added basic collision detection with Game Over logic

## 🎮 Gameplay Summary
> A simple prototype where the player moves horizontally to dodge falling blocks.  
If a block hits the player, the game pauses and logs "Game Over!"

## 🧠 What I Learned
- Unity’s core workflow (GameObjects, Components, Prefabs)
- C# scripting in Unity: Transform, Input, Instantiate, Collisions
- Prefab system and dynamic object spawning
- Basic physics in 2D: Rigidbody and Colliders
- Player-controlled logic vs physics-based simulation

## 🐞 Issues Faced
- Confusion about Rigidbody2D types (Dynamic vs Kinematic)
- First collision didn’t trigger → fixed by adding colliders correctly

## 🔮 Planned Feature
- 🎯 Roguelike movement system:  
  Player starts with **10f movement**, and every successful dodge increases it by **5f**

