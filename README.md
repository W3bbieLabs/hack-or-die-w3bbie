`Date last modified: 2023 02 2023`
# Hack or Die

[Hack or Die Demo](http://w3bbie.xyz/hod), courtesy of [W3BBIE](https://twitter.com/w3bbie_xyz). Built for [ThirdWeb's Ready Player 3 hackathon](https://thirdweb.com/hackathon/readyplayer3).

*Welcome to the Hack or Die README. Here, you will find a guide to context, gameplay, design, and development.* 

---

## General Context
In our multiplayer co-op game, players band together to fend off endless waves of enemies in a bid for survival. With each wave presenting a new challenge and a new opportunity to prove their mettle, our game will keep players on the edge of their seats as they fight to survive for as long as possible.

### 💡 Why we Created Hack or Die
We wanted to challenge ourselves to use tools we were not familiar with to build something fun people could play together.

### 🤠 Bounties We are After!
| Bounty Name   | Description | Eligibility |
|---------------|-------------|------------|
| The Future of Gaming | Leverage thirdweb’s front-end, back-end, and blockchain SDKs and components (e.g. GamingKit, UI Kit, Gasless Relayers, React SDK, etc.) to create an innovative and user-friendly web3 gaming experience.| Leveraged thirdweb's ERC1155 (edition drop) contract for token-gated characters, utilized Contract kit, Gaming Kit (Unity SDK) & UI Kit|
| Ship Your First Game| Best use of thirdweb’s UnitySDK in an innovative web3 gaming build or use of threeJS (or another browser based language) with thirdweb’s SDKs. | Utilized thirdweb's UnitySDK to build Hack Or Die. Used threeJS with thirdweb's UI components in the marketplace |
| HardMode| Leverage both ContractKit and GamingKit in a browser-based web3 game build.| Used ContractKit for our in game NFTs. Utlizied GamingKit to provide web3 wallet intergration interacting with our deployed smart contracts so players can access character and reward NFTs. |
| Under The Hood | Leverage thirdweb and Coinbase infrastructure in a web3 gaming build to further highlight the GamingKit collaboration.| Wallet Connect button is built from thirdweb's UI components that allow users to connect to Coinbase Wallet. |


### 👾 Reasons to play?
* The initial up-front to play? Zero.
* Massively multiplayer (bring your friends, or make new ones).
* Web3 beginner friendly
* W3BBIE built it.. duh.

---

## 👘 Inside Hack or Die

### ⚙️ Mechanics
#### Gameplay Physics
* Movement
    - Standard left, right, up, down. 
    - Bound to keys, WASD.
    - Can be used in conjuntion with space bar, triggering a jump-move.
* Auto-lock 
    - Player's weapon auto-locks onto the position of the nearest enemy.
    - Player (when auto-locked) is rotated to nearest enemy during auto-lock. 
* Projectile Firing
    - Firing happens via velocity, in direction of target.
* Enemy Awareness
    - Enimies are position-aware, locking onto the player's position, then navigating to that defined point. 
* Enemy Respawning
    - Enemies respawn in waves, per duration (and targets eliminated).  
    - The nuber of enmies in a respawn is game-defined. 
* Jumping
    - Spacebar vaults the character upwards. 
    - A double can be triggered with timely taps of the spacebar.

### 🎨 Aesthetics
#### Environment Design
Hack or Die features an array of sectors within a level, each with its own unique aesthetic and gameplay relative purpose. The idea is to provide players the reason to explore.  

#### Character Design
The first set of characters for Hack or Die were designed with the intention of being unique, familiar, and recognizable. Concepts for both BLK and BLU were created using Midjourney and hand modeled in virtual reality.   

#### Interface Design
The interface was designed to be simple, well-organized, and verbose. The key challenge in designing the interace was arriving at a design system which could expand with the game. Also important?Having the interface feel like an element of the game, and not a "default" and / or  "design afterthought." 

#### Sound Design
The sounds of Hack or Die aim to round out gameplay on a macro and micro scale; Hack or Die's entirey was taken into account when the soundboard was created. Also, a theme of journey and exploration are relayed via Hack or Die's core soundtrack.  

### 🛠 Technology
* Unity 
* Figma
* NextJS
* TailwindCSS
* Thirdweb UI Components
* Thirdweb React SDK
* Three JS
* Framer Motion
* Midjourney
* ChatGPT
* Ableton
* Gravity Sketch
---

## 🚧 Development

### Areas Of Development
* Hack or Die Game Server
* Gameplay Environment
* Gameplay Physics
* Wallet Connect
* Smart Contracts
* User Experience
* ThirdWeb Character Assets
* Off-chain Marketplace

### 🏁 Milestones
| Milestone Name                                                 | Date Reached   |
|----------------------------------------------------------------|----------------|
| Two players on seperate devices in an environment in browser.  | 2023 / 01 / 27 |
| All 3d assets for game created (environment, characters, etc). | 2023 / 01 / 30 |
| Built easter eggs into level one.                              | 2023 / 02 / 12 |

### 🐞 Known Bugs

| Bug Name             | Description                                                | Date of Recognition  | Severity (1-5) | Fixed        |
|----------------------|------------------------------------------------------------|----------------------|----------------|--------------|
| Respawn bug          | Enemies respawning outside of environment.                 | 2023 / 01 /30        | 3              | Yes.         |
| Projectile Trigger   | Unable to shoot; player takes stance but never fires.      | 2023 / 02 / 13       | 5              | In Progress. |
| Wallet Connect       | Guest-only forced even if wallet connected.                | 2023 / 02 / 13       | 5              | In Progress. |
| Marketplace          | MetaMask skips login, asks to create/import account.       | 2023 / 02 / 13       | 3              | In Progress. |
| Unlockable Character | "Blue" is claimable, yet error message displays otherwise. | 2023 / 02 / 13       | 2              | In Progress. |

*Note: Submit future bugs via Issues. This is only a temporary bug tracker.*

---

## 👽 Future Plans for Hack or Die
* Build environmental-based hacks into level one.
* Build time-based hacks into level one.
* Build time-based multipliers into level one.
* Build server-based multipliers into level one.
* Establish leaderboard system.
* Complete the interface from design system prototype (HUDs, pause/play states). 
* Enable adjustable physics to influence and create play styles.
* Refine gameplay loop
* Add more playable characters and weapons
* Intergrate social features (text and voice chat)
---

## 🦾 Team W3BBIE

| Name                                                                  | Role(s)                                   |
|-----------------------------------------------------------------------|-------------------------------------------|
| [Kyn Adams](https://twitter.com/Tek_Gawd)                                                     | Server, Tester                            |
| [Tabari Humphries](https://www.instagram.com/gyasi.eth/)              | Environmental Design, Level Design        |
| [Jack Lester](https://www.linkedin.com/in/jacklester/)                | UI, Technical Documentation, Music & SFX  |
| [Travis Rice](https://www.linkedin.com/in/travislrice/)               | Project Manager, Character Design         |
| [Sailesh Sivakumar](https://www.linkedin.com/in/sailesh-sivakumar-453061141)| Marketplace, Smart Contracts        |
| [Chris Smith](https://twitter.com/last_gigabyte)                      | Gameplay Physics, Level Design            |

---
