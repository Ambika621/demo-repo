# Time Loop Duel 3D - Setup Instructions

This guide will walk you through setting up the Time Loop Duel 3D project in the Unity Editor. Since this project only contains scripts, you will need to create the necessary Unity assets (scenes, prefabs, materials, etc.) from scratch.

### 1. Project Setup

1.  **Create a new Unity Project:**
    *   Open Unity Hub and create a new 3D project.
    *   Name it "Time Loop Duel 3D".
2.  **Import Scripts:**
    *   Copy the `Assets` folder from this project into your new Unity project's root directory, merging it with the existing `Assets` folder.

### 2. Scene Setup

1.  **Create a new Scene:**
    *   In the Project window, right-click and go to `Create > Scene`.
    *   Name the scene `MainScene` and open it.
2.  **Create the Arena:**
    *   Create a simple ground plane: `GameObject > 3D Object > Plane`.
    *   Scale it up to a suitable size.
    *   **Important:** Select the ground plane, and in the Inspector, click the "Tag" dropdown and select "Add Tag...". Create a new tag named "Ground" and assign it to the ground plane.
    *   Create a few obstacles like cubes and ramps.

### 3. Player Setup

1.  **Create the Player:**
    *   Create a `Capsule` (`GameObject > 3D Object > Capsule`) and name it `Player`.
    *   Add a `Rigidbody` component to the `Player`.
    *   Attach the following scripts to the `Player` object:
        *   `PlayerController3D`
        *   `CombatController`
        *   `GhostRecorder`
        *   `HealthSystem`
2.  **Create a Fire Point:**
    *   Create an empty `GameObject` as a child of the `Player` and name it `FirePoint`.
    *   Position it in front of the player where projectiles should spawn.
3.  **Configure Player Scripts:**
    *   In the `PlayerController3D` component, drag the `Main Camera` to the `Camera Transform` field.
    *   In the `CombatController`, drag the `FirePoint` to the `Fire Point` field. We will create the projectile prefab in the next step.
    *   In the `HealthSystem`, create a spawn point (an empty `GameObject`) and drag it to the `Spawn Point` field.

### 4. Projectile Setup

1.  **Create a Projectile Prefab:**
    *   Create a `Sphere` (`GameObject > 3D Object > Sphere`) and name it `Projectile`.
    *   Add a `Rigidbody` component.
    *   Add the `Projectile` script.
    *   Drag the `Projectile` from the Hierarchy to the `Assets/Prefabs` folder to create a prefab, then delete it from the scene.
2.  **Create an Object Pool:**
    *   Create an empty `GameObject` and name it `ProjectilePool`.
    *   Add the `ObjectPool` script.
    *   Drag the `Projectile` prefab to the `Object To Pool` field.
    *   Set `Amount To Pool` to a reasonable number, like 20.
3.  **Link the Pool to the Player:**
    *   Select the `Player` and in the `CombatController` component, drag the `ProjectilePool` to the `Projectile Pool` field.

### 5. Ghost Setup

1.  **Create a Ghost Prefab:**
    *   Create another `Capsule` and name it `Ghost`.
    *   Attach the `GhostPlaybackController` and `CombatController` scripts.
    *   Set up a `FirePoint` for the ghost, just like you did for the player.
    *   Drag the `Ghost` into the `Assets/Prefabs` folder and delete it from the scene.
2.  **Create a Ghost Object Pool:**
    *   Create an empty `GameObject` and name it `GhostPool`.
    *   Add the `ObjectPool` script.
    *   Drag the `Ghost` prefab to the `Object To Pool` field.
    *   Set `Amount To Pool` to a reasonable number, like 10.
3.  **Link the Projectile Pool to the Ghost:**
    *   Select the `Ghost` prefab and in the `CombatController` component, drag the `ProjectilePool` to the `Projectile Pool` field.

### 6. Loop Manager Setup

1.  **Create the Loop Manager:**
    *   Create an empty `GameObject` and name it `LoopManager`.
    *   Attach the `LoopManager` script.
2.  **Configure the Loop Manager:**
    *   Drag the `Player` to the `Player Recorder` field.
    *   Drag the `Player` to the `Player Health` field.
    *   Drag your spawn point `GameObject` to the `Player Spawn Point` field.
    *   Drag the `ProjectilePool` to the `Projectile Pool` field.
    *   Drag the `GhostPool` to the `Ghost Pool` field.

### 7. Camera and UI Setup

1.  **Camera:**
    *   Select the `Main Camera` and attach the `CameraController` script.
    *   Drag the `Player` to the `Target` field.
2.  **UI (Optional but Recommended):**
    *   Create a `Canvas` (`GameObject > UI > Canvas`).
    *   Add a UI `Image` for the health bar.
    *   Select the `Player` and in the `HealthSystem` component, drag the health bar `Image` to the `Health Bar` field.

### 8. Final Steps

*   Save your scene.
*   Press Play to run the game!
