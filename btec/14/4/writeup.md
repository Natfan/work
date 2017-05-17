# Unit XIV Assignment IV
*By Nathan Windisch*

## PVI: Onscreen Help
For this segment I will be listing on screen help that will be displayed when the user enters a command wrong, or if they type in the command without the arguments.

### The Main Help Page
The following page will be sent when a user executes the command `/chill`:

![chill](https://github.com/Natfan/work/raw/master/btec/14/4/pics/chill.png)

This is what the code for it looks like:

```java
sender.sendMessage("/freeze <playerName> - Freezes/Unfreezes a player, used as a toggle. chill.freeze");
sender.sendMessage("/frozen <playerName> - Checks if a player is frozen. chill.frozen");
sender.sendMessage("/panic - Places you into panic mode, whereby you cannot be unfrozen. chill.panic");
```

### The Command Reference
#### Freeze
The following is what will be sent if the user execute too many or too few arguments after the '/freeze' command:

![freeze command](https://github.com/Natfan/work/raw/master/btec/14/4/pics/freeze.png)

And this is what the code for it looks like:

```java
sender.sendMessage("Please specify a player.");
```

#### Freeze All
The following is what will be sent if the user execute too many or too few arguments after the '/freeze all' command:
![freeze all command](https://github.com/Natfan/work/raw/master/btec/14/4/pics/freezeall.png)

And this is what the code for it looks like:

```java
sender.sendMessage("This is a very serious command.");
sender.sendMessage("This freezes all online players.");
sender.sendMessage("If you are okay with this, type /freeze all confirm");
```

#### Thaw
The following is what will be sent if the user execute too many or too few arguments after the '/thaw' command:
![thaw command](https://github.com/Natfan/work/raw/master/btec/14/4/pics/thaw.png)

And this is what the code for it looks like:

```java
sender.sendMessage("Please specify a player.");
```

#### Frozen
The following is what will be sent if the user executes too many or too few arguments after the `/frozen` command:
![frozen command](https://github.com/Natfan/work/raw/master/btec/14/4/pics/frozen.png)

And this is what the code for it looks like:

```java
sender.sendMessage("Please specify a player.");
```

<div style="page-break-after: always"></div>

## MI: Technical Documentation
### Overview
This program was developed for staff members on a game server that I own and administrate. The plugin allows those with specific permissions to execute commands that will let them stop suspected cheaters from interacting with the world, thus allowing legitimate players to enjoy the game without interruption. Once a player has been frozen, they will not be able to move, attack other players or interact with the environment, among other things. A menu will appear on their screen informing them as to why they have been frozen and the IP address to the voice server that they need to connect to so that they can talk to an Administrator. Once they have joined the voice server, they may need to download a piece of software that will allow the Administrator to scan their game files to ensure that they are not cheating. If they confess to cheating, then their punishment may be reduced. However, if they do not confess and it turns out that they were cheating, their ban will be permanent.

### User Guide
#### Freezing
If you believe that a player is cheating beyond reasonable doubt, and you have recorded evidence of doing actions which either do not seem legitimate or set of large amounts/high numbers of AntiCheat violations, then you may freeze a player. You are also allowed to freeze a player if they are obviously cheating and are in the action of preventing other legitimate players from having an enjoyable experience, such as killing them to take their stuff. You are not allowed to freeze a player as a joke, even if they explicitly request it. Freezing is a serious action and will be broadcast to all online staff members. To prevent abuse, you cannot freeze other staff members as they have the `chill.override` permission. If you attempt to freeze a staff member then the action will be denied and all online staff will be notified of this. If you abuse the features of freezing you may be demoted or even banned from the server. The command to freeze a player is `/freeze <playerName>`

#### Freezing All Players
Only members of the Leadership and Ownership Team have the ability to freeze all players on the server, due to the fact that there is no `/thaw all` command. This is because there is currently no way to distinguish between a player that has been frozen in a single command, and players that have been frozen in a mass command, due to the fact that they are both added to the `frozen` ArrayList with the same method. Freezing all players without a good reason and adequate warning is a very serious offence, and can get the command removed from your repertoire. The command to issue this is `/freeze all`. You will then be prompted to confirm it, at which point you will have to have to type in `/freeze all confirm`.

#### Thawing
If you believe that the player that you froze was not cheating, you can either type `/freeze <playerName` to toggle the frozen status of the player, or you can type `/thaw <playerName>` to unfreeze them directly. It is preferred that you use the latter command due to the fact that you could accidentally freeze an incorrect player. Please only thaw players that you personally have frozen, to prevent interference with other Administrators punishments issues.

#### Frozen
To check if a player is frozen, simply issue `/frozen` command to check if the player is frozen or not. The command output will either show if the player IS frozen, like so:
![frozen check true](https://github.com/Natfan/work/raw/master/btec/14/4/pics/frozen_true.png)

And this is what the output will be if the player is NOT frozen:
![frozen check false](https://github.com/Natfan/work/raw/master/btec/14/4/pics/frozen_false.png)

This is a very simple command and cannot really be abused. Please note that all information gained as a staff member should not be revealed to the player base unless a consensus from the Ownership Team is reached. While we try to be a transparent organisation, some inner workings of the Administrative side of things need to be kept secret.


