`Date last modified: 2023 02 2023`
# Hack or Die

[Hack or Die Demo](http://w3bbie.xyz/hackordie/), courtesy of [W3BBIE](https://twitter.com/w3bbie_xyz). Built for [ThirdWeb's Ready Player 3 hackathon](https://thirdweb.com/hackathon/readyplayer3).

*Welcome to the Hack or Die README. Here, you will find a guide to context, gameplay, design, and development.* 

---

## General Context
### Why we Created Hack or Die

### Bounties We are After!
| Bounty Name   | Description | Eligibilty |
|---------------|-------------|------------|
| The Future of Gaming |leverage thirdweb’s front-end, back-end, and blockchain SDKs and components (e.g. GamingKit, UI Kit, Gasless Relayers, React SDK, etc.) to create an innovative and user-friendly web3 gaming experience.|leveraged thirdweb's ERC1155 (edition drop) contract for token-gated characters, utilized Contract kit, Gaming Kit (Unity SDK) & UI Kit|
| The Coolest Concept| Awarded for the most creative gaming concept utilizing the ERC-Cool™ Sustainable Smart Contract coupled with thirdweb’s Unity SDK to positively impact the planet while you play| ERC-Cool Sustainable Smart Contract for in game reward NFTs|
| Ship Your First Game| Best use of thirdweb’s UnitySDK in an innovative web3 gaming build or use of threeJS (or another browser based language) with thirdweb’s SDKs. | Utilized thirdweb's UnitySDK to build Hack Or Die. Used threeJS with thirdweb's UI components in the marketplace |
| HardMore| Leverage both ContractKit and GamingKit in a browser-based web3 game build.| Used ContractKit for our in game NFTs. Utlizied GamingKit to provide web3 wallet intergration interacting with our deployed smart contracts so players can access character and reward NFTs. |
| Under The Hood | Leverage thirdweb and Coinbase infrastructure in a web3 gaming build to further highlight the GamingKit collaboration.|------------|


### Reasons to play?
* The initial up-front to play? Zero.
* Massively multiplayer (bring your friends, or make new ones).
* Web3 beginner friendly
* W3BBIE built it.. duh.

---

## Inside Hack or Die

### Story
#### Origin and plot

### Mechanics
#### Gameplay Physics
* Projectiles
* Enemy Respawning
* Double Jump

### Aesthetics
#### Environment Design
Hack or Die features an array of sectors within a level, each with its own unique aesthetic and gameplay relative purpose. The idea is to provide players the reason to explore.  

#### Character Design

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

## Future Plans for Hack or Die
* Build easter eggs into level one.
* Build environmental-based hacks into level one.
* Build time-based hacks into level one.
* Build time-based multipliers into level one.
* Build server-based multipliers into level one.
* Establish leaderboard system.
* Complete the interface from design system prototype (HUDs, pause/play states). 
* Enable adjustable physics to influence and create play styles.

---

## Team W3BBIE

| Name                                                                  | Role(s)                                   |
|-----------------------------------------------------------------------|-------------------------------------------|
| [Kyn Adams](link)                                                     | Server, Tester                            |
| [Tabari Humphries](link)                                              | Environmental Design, Level Design        |
| [Jack Lester](https://www.linkedin.com/in/jacklester/)                | UI, Technical Documentation, Music & SFX  |
| [Travis Rice](link)                                                   | Project Manager, Character Design         |
| [Sailesh Sivakumar](link)                                             | Marketplace, Smart Contracts              |
| [Chris Smith](link)                                                   | Gameplay Physics, Level Design            |

---
