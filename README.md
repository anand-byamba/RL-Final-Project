# Final Project - Reinforcement Learning

## Training Configurations

The goal of this training is to ensure **the drone will dodge the spawning bird**. I utilize three distinct configurations to test different learning behaviors.

| Run ID | Config File | Personality | Description |
| :--- | :--- | :--- | :--- |
| **Run3** | `DodgeTheBird1.yaml` | **The Balanced Baseline** | The control group using standard defaults. It acts on very short snippets of gameplay (short time horizon) but keeps a large memory buffer. |
| **Run4** | `DodgeTheBird2.yaml` | **The Reactive Sprinter** | Designed for speed and quick iterations. It uses a lightweight network and learns aggressively, focusing on immediate survival rather than long-term planning. |
| **Run5** | `DodgeTheBird3.yaml` | **The Deep Strategist** | A heavyweight model for complex solving. It uses a massive network and large batch sizes to form precise gradients, focusing on long-term survival. |

## Project Setup

Unity Version: **[2022.3.62f1 (LTS)](https://unity.com/releases/editor/whats-new/2022.3.62f1)**  

## ⚠️ Important Note on Assets & Licensing

This project utilizes 3D assets and environments that are subject to the **Unity Asset Store End User License Agreement (EULA)**. To respect the intellectual property of the creators and adhere to legal distribution rights, these specific files have been **excluded** from this repository.

### Missing Assets?
If you clone this repository and see missing models or empty prefabs, it is because you need to import the required assets locally.

**Required Assets:**
* **[Simple Drone](https://assetstore.unity.com/packages/3d/vehicles/air/simple-drone-190684)**

* **[3D Birds Prototype Pack](https://assetstore.unity.com/packages/3d/props/3d-birds-prototype-pack-150502)**

* **[Low-Poly Simple Nature Pack](https://assetstore.unity.com/packages/3d/environments/landscapes/low-poly-simple-nature-pack-162153)**


### How to Run This Project
1.  Clone this repository.
2.  Purchase/Download the assets listed above from the Unity Asset Store.
3.  Open the project in Unity.
4.  Import the assets via the **Package Manager** (Window > Package Manager > My Assets).
5.  The project references should automatically re-link.

> **Note:** The trained AI models (`.onnx` files) and the custom training configuration (`.yaml` files) included in this repo are original works and are free to use.
