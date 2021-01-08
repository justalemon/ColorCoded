# ColorCoded<br>[![AppVeyor][appveyor-img]][appveyor-url] [![Discord][discord-img]][discord-url]

ColorCoded is a mod for Grand Theft Auto V that allows you to use the DualShock 4 and DualSense light bar in GTA V PC, just like the PS4 edition.

My idea in the future is to add support for other Lighting software like Asus Aura Sync and Corsair iCUE via their SDKs.

## Download

* [GitHub](https://github.com/justalemon/ColorCoded/releases)
* [5mods](https://www.gta5-mods.com/scripts/colorcoded)
* [AppVeyor](https://ci.appveyor.com/project/justalemon/colorcoded) (experimental)

## Installation

*Please note that you need to install [PlayerCompanion](https://www.gta5-mods.com/scripts/playercompanion) for ColorCoded to work.*

First, drag and drop all of the files inside of the 7zip into your **scripts** directory. Then, download [JoyShockLibrary](https://github.com/JibbSmart/JoyShockLibrary/releases) and extract **JSL\x64\JoyShockLibrary.dll** to the root of your game directory.

**WARNING**: If you are using DS4Windows, you need to disable "Enable Output data to DS4" on the Profile Settings and "Hide DS4 Controller" on the Application Settings, then reconnect your controller phisically.

## Usage

After the script is started, the DualShock 4 or DualSense light bar should start working. There are only two light colors available:

* Normal: Sets the color of the player from the Game (Franklin, Michael and Trevor) or PlayerCompanion (for other Peds, see [here](https://github.com/justalemon/PlayerCompanion/wiki/Using-Custom-HUD-Colors) for instructions)
* Wanted: Flashes Blue and Red, just like in the PS4 version of the game

[appveyor-img]: https://img.shields.io/appveyor/build/justalemon/colorcoded?label=appveyor
[appveyor-url]: https://ci.appveyor.com/project/justalemon/colorcoded
[discord-img]: https://img.shields.io/badge/discord-join-7289DA.svg
[discord-url]: https://discord.gg/Cf6sspj
