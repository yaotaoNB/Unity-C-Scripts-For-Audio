# Unity-C-Scripts-For-Audio
If you are an indie game developer, you must want to save the budget as much as possible. One big challenge is how to dealing with the audio within the game without using Wwise since when you publish the game, Wwise will also take a lot of money from you.
Here are some common scripts of the audio system for a 3D first person game, including a sound manager, movement (including footsteps and jump), script for birds or seagull, seawaves and so on.

All scripts you need are in the "Scripts" folder with floowing .cs files:

#1 Cranes.cs / Metal.cs, Wood.cs
When you have 2 sounds and you want them to be played interactively with each other but not simutaniously, you can drag the single Cranes.cs or both Metal.cs/ Wood.cs to the object you want. Create 2 Audio Sources on the object and drag them into the script Audio source slots.From here I'm trying to simlate the sound of a crane containing both metal/wood squish sound, but you can name or pick your audio clips whatever you want. If you want to switch to your own audio clip, simply drag/drop the "Resources" folder into you "asset" folder of the project and create a new folder in the "Resources" floder, change the path of Resources.LoadAll<AudioClip>("the path of your floder"); in the Start() of the script.

#2 Movement.cs
In this script you can apply the footstep/jump sound to the character and switch different types of footsteps in different surfaces/materials of your choice, it'll also randomly play different variations of the same footstep type as far as these variations are in the same folder inside of the Resources floder. To trigger the footsteps sounds in different materials, you need to first give different ground materials in the project a tag name, and apply that tag name in the script. You can add, copy/paste as many functions of the Raycast functions as you want depends on how many different surfaces you want. I'm using Raycast to detect weather or not the player is running/walking on the ground or the player is jumping/flying. Finally create folders for different materials inside of your Resources folder, and change the path in Resources.LoadAll<AudioClip>("your path");

#3 Music.cs/ Music2.cs
This 2 scripts are simple branching music scripts, each of them are using differnt ways to achieve the same result. When you switch a zone to another in the game, the previous music clip will not immediately stop and switch to the next music loop, it'll wait until the current music loop has finished.
The first one "Music.cs" is using a counter to measure it, the second one "Music2.cs" is using .isPlaying to detect the music loop. Build some 3d Objects or whatever has a collider with isTriggered checked so that it won't collide with the player, give each object a tag, add some loopable music clips in the Resources/Sounds/Music folder, set what music you want to play depends on the 3D object in the script.

#4 Player.cs
3 statics properties to get the positions of the player frame by frame when he is moving.

#5 SeagullTrigger.cs/ Seagull.cs
This 2 scripts are used for simulate the sound of birds in the game, when the player triggered by a 3D object in the game it'll turn on the Seagull sound, the sound will be played depends on the positions of the player in real time.

#6 SeaWavesOne.cs
This one is used for simulate seawaves sounds along the beach, set 3 different parameters of x,y,z and it'll switch between the 3 different locations and play the sound.
