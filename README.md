# COMP3000-Project-Procedural-Dungeoun

The final year project repository.

*Concept: *
  The initial concept was to create a rogue like game, inspired by [WolfenStein3D](https://store.steampowered.com/app/2270/Wolfenstein_3D/). Afterwards I decided to make the Procedurally Generated first-person shooter.
  
*First Updates: *
Made a simple prototype without looping and rooms:
![Alt Text](https://github.com/Tourist805/COMP3000Proj/blob/main/media/2021-12-20%2018-48-03.gif)
Itch.io : https://zhanuchuk.itch.io/dungeon-shooter-3d
Questionnare: https://forms.gle/93PjpgvFBF9XB28P7

<div id="top"></div>
<!--
*** Thanks for checking out the Best-README-Template. If you have a suggestion
*** that would make this better, please fork the repo and create a pull request
*** or simply open an issue with the tag "enhancement".
*** Don't forget to give the project a star!
*** Thanks again! Now go create something AMAZING! :D
-->



<!-- PROJECT SHIELDS -->
<!--
*** I'm using markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]


![Logo](https://github.com/Tourist805/COMP3000-MazeGame/blob/main/media/screenshots/logo.png)

<!-- TABLE OF CONTENTS -->
<details>
  <summary>Table of Contents</summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
      <ul>
        <li><a href="#built-with">Built With</a></li>
      </ul>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li><a href="#usage">Unique Selling Points</a></li>
    <li><a href="#contact">Contact</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

[![Product Name Screen Shot][product-screenshot]](https://example.com)

For casual gamers (desktop-oriented), who would like to spend time in labyrinths, searching for adventures, encountering various impediments, including monsters, goblins, stalkers, and other creatures. The Labyrinth shooter is a 3D first-person shooter, an adventure game that aims to keep players entertained for hours with the one-of-kind concept. It takes the idea of classic dungeon games, such as Wolfenstein 3D, and expands it with its features, by having procedurally generated levels.



<p align="right">(<a href="#top">back to top</a>)</p>



### Built With

* [Unity](https://unity.com/)
* [Visual Studio](https://visualstudio.microsoft.com/)

<p align="right">(<a href="#top">back to top</a>)</p>



<!-- GETTING STARTED -->
## Details of implemnentation:
The idea is to randomnly retrieve the rooms from the maze and cut the passages in the room area.
The initial "perfect maze":
![Without rooms](https://github.com/Tourist805/COMP3000-MazeGame/blob/main/media/screenshots/Screenshot%202022-02-08%20213749.png)

Create imperfection by defining rooms:
![Rooms](https://github.com/Tourist805/COMP3000-MazeGame/blob/main/media/screenshots/MazeHidedRooms.png)

So the final result for the maze will be:
![Maze 40 x 40](https://github.com/Tourist805/COMP3000-MazeGame/blob/main/media/screenshots/maze40x40.png)


As far as for the FPS shooting, I have used standard raycast system.
![Final Shoot](https://github.com/Tourist805/COMP3000-MazeGame/blob/main/media/screenshots/Screenshot%202022-03-30%20220500.png)


### Installation

Clone the project if you would like
   ```sh
   git clone https://github.com/github_username/repo_name.git
   ```

Or download the project from either itch.io or the last release
Itch.io: https://zhanuchuk.itch.io/dungeon-shooter-3d
<p align="right">(<a href="#top">back to top</a>)</p>



<!-- USAGE EXAMPLES -->
## Unique Selling Points

- [ ] Procedural level generation(uses rooms defining approach)
- [ ] FPS mechanics
- [ ] Variety of weapons
    - [ ]  including revolver, assault riffle, axe, shotgun
- [ ] AI pathfinding (buili in Unity NavMesh system)
- [ ] Low-poly style for models and UIS


<p align="right">(<a href="#top">back to top</a>)</p>

<!-- CONTACT -->
## Contact

Zhanybek Dauletov - [LinkedIn](https://www.linkedin.com/in/zdauletov/) - dauletovzhanybek@gmail.com

Project Link: [Dungeon Shooter 3d](https://github.com/Tourist805/COMP3000-MazeGame)

<p align="right">(<a href="#top">back to top</a>)</p>






<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/github_username/repo_name.svg?style=for-the-badge
[contributors-url]: https://github.com/github_username/repo_name/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/github_username/repo_name.svg?style=for-the-badge
[forks-url]: https://github.com/github_username/repo_name/network/members
[stars-shield]: https://img.shields.io/github/stars/github_username/repo_name.svg?style=for-the-badge
[stars-url]: https://github.com/github_username/repo_name/stargazers
[issues-shield]: https://img.shields.io/github/issues/github_username/repo_name.svg?style=for-the-badge
[issues-url]: https://github.com/github_username/repo_name/issues
[license-shield]: https://img.shields.io/github/license/github_username/repo_name.svg?style=for-the-badge
[license-url]: https://github.com/github_username/repo_name/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/linkedin_username
[product-screenshot]: images/screenshot.png
