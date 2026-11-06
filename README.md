# Oil Simulator

A Unity-based concept project for the design brief you provided. This starter repo lays down the core systems and project structure for a 3D driving + oil business simulator prototype, including:

- Drivable truck controller
- Job system with starter deliveries
- Oil site production and sales flow
- In-game market and economic pricing
- Phone UI / HUD for business management
- Business progression and region-ready architecture

## Recommended setup

- Unity 2022.3 LTS or newer
- Built on the standard URP/3D template
- No external packages beyond Unity built-ins

## Project structure

- `Assets/Scripts/Bootstrap` — runtime bootstrap for world creation
- `Assets/Scripts/Driving` — vehicle controller
- `Assets/Scripts/Jobs` — starter jobs and delivery logic
- `Assets/Scripts/Business` — oil sites, market, business state
- `Assets/Scripts/UI` — phone HUD and dashboard

## Core loop implemented here

1. Spawn a drivable truck
2. Generate a simple local delivery job
3. Toggle a phone HUD showing cash and market price
4. Spawn a starter oil site and simulate production
5. Sell oil back into a local buyer market
6. Track cash and progression readiness

## How to run

1. Open this folder in Unity.
2. Create a new empty scene or use a blank scene.
3. Press Play.
4. The runtime bootstrap automatically spawns the starter world and systems.

## Notes

This is a solid technical foundation for the design doc, not a final commercial product. It prioritizes a playable architecture, readable systems, and extensibility for future regions, contracts, workers, and co-op layering.
