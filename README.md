# Shot!

![Unity](https://img.shields.io/badge/Unity-6.3_LTS-black?logo=unity)
![Platform](https://img.shields.io/badge/Platform-Mobile-blue)
![Status](https://img.shields.io/badge/Status-In_Development-yellow)

**Shot!** is a fast-paced arcade game where catching and drinking shots requires sharp reflexes, precision, and perfect timing. Easy to learn, hard to master.

This repository contains the full Unity project, structured to be modular, scalable, and easy to maintain.

---

## Gameplay Overview

Shot! is built around a repeating gameplay loop composed of two main minigames:

### Shot Grab
- The table is divided into three lanes.
- The bartender throws shots through randomized lanes.
- The player drags their finger across the lanes to move the character’s hand.
- If input is released, the hand remains on the last selected lane.

### Skillbar
- Triggered shortly after grabbing a shot.
- A selector moves back and forth across a bar.
- The player slides up to stop the selector.
- Hitting the green zone results in a Perfect.
- Failing reduces the player’s lives.

Difficulty scales dynamically based on the player’s current score.

---

## Requirements

- Unity Version: 6.3 LTS  
- Target Platform: Mobile (Android / iOS)  
- Input System: Unity Input System  
- Rendering Pipeline: URP  

---

## How to Open the Project

1. Install Unity Hub.
2. Make sure Unity 6.3 LTS is installed.
3. Clone or download this repository.
4. Open Unity Hub.
5. Click Add project from disk.
6. Select the root folder of the repository.
7. Open the project using Unity 6.3 LTS.

---

## Controls

- Drag left / right: Move hand between lanes  
- Slide up: Execute Skillbar action  

---

## Development Status

This project is currently in active development.  
Features, structure, and balance values are subject to change.

---

## Developed by

**[Triky Team](https://triky-team.itch.io/)**
