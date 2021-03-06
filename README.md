# BattleshipGame.API

Implementation of the classic paper pencil guessing game. Each player has a ten by ten grid on which to place their battleships in the first phase.

![image](https://user-images.githubusercontent.com/34026211/128033537-c10df1de-f81b-4c8b-87e1-5b420e88f135.png)

# To Play
- **Step 1:** Create Game by calling endpoint GameManagement.CreateGame and providing player 1 and player 2.
- **Step 2:** Get Game Details by calling endpoint GameManagement.GetGameById and providing GameGUID.
- **Step 3:** In order to proceed each player need to complete placements of all 5 battleship by calling GameManagement.PositionBattleship and providing GameGUID, PlayerGUID, BattleshipGUID and Position Coordinates.
- **Step 4:** Each player will take turns and make their move by calling ScoreTracker.Attack and providing GameGUID, PlayerGUID and attack position coordinates. it runs results either Hit or Miss.

# Gaming Logic implemented
- It validates out of bound coordinates
- validate out of turn player moves
- invalid or empty GUIDs
- Game will not proceed until and unless all battleship pieces are placed on the Gameboard
- Each player have gameboard which captures battleship placements. and scoreboard which keep track of player moves and there outcome.
- customised error messages
- in-memory data persistence

# Deployment Link
https://battleshipgame-api.azurewebsites.net/swagger/index.html

# Repo Link
https://github.com/amjadleghari/BattleshipGame
