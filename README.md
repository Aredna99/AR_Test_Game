# AR_Test_Game
This simple game is developed in Unity using AR Foundation

## Important
This project was done on Unity **2021.3.0f1**, and it's been build to be an **Android app!**


## Project Info
The game is divided in 2 scene. 
- A really super simple **main menu scene**.
- A **game scene**, where the user can move and turn around using the phone's camera. 

### Main Menu Scene
Pressing one of the buttons in the **Main Menu scene**, there will be a simple SceneMgr script that will run a simple fade-out/fade-in for change the scene or for close the app.

### Game Scene
When starting the game, the user will be able to freely move, and after 3 seconds of gameplay (nothing) the enemies, with the **EnemyController** script attached to them, will start poping out around him from the EnemySpawner script attached to the EnemySpawner obj (MAX 10 eniemies active at the same time).

The player has a script attached called **PlayerController**, where you can set the player **Max Health** value and the **radius**, that will be the player "safe area".
When an enemy enter in this "safe area" the player will get some damages and an HP bar will change accordigly to his remaining hp.

Always inside the game scene there are 2 buttons
- An invicibility button wich will grant the player the invulnerability to all damages.
- A quit button that will send the player back to the main menu.

Thanks you for your attention!
