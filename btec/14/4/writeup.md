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

<div style="page-break-after: always"></div>

## MI: Technical Documentation
### Overview
This program was developed for staff members on a game server that I own and administrate. The plugin allows those with specific permissions to execute commands that 
