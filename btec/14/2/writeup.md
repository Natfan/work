# Unit XIV Assignment II
*By Nathan Windisch*

## PIII: Designing A Bespoke Event Driven Application
The software that I shall be designing is a plugin for piece of server software called `Spigot` that is used to make the generation of add-ons to the video game `Minecraft`. The plugin in question is called **Chill**, a tool which allows Administrators to freeze possible cheaters to prevent them from causing any more damage to legitimate players. After this point they can a voice chat service such as Teamspeak3 or Discord so that they can communicate with the staff member that froze them, possibly share their screen and, after rigorous checks, may be unfrozen. If it turns out that the player was cheating, they will be punished accordingly. The input of the program is when the Administrator freezes a player, the output is when the user tries to perform an action that is prohibited while they are frozen, along with notifying staff members when a person who should not be frozen is attempted to be frozen, and the process is the blocking of these actions. There are a few different tools that I shall use within this program, and I shall list them and describe why they are important.

### Selection
Selection is important to this program as without it, the Administrator cannot specify which user they would like to freeze, meaning that the program would be completely useless without it.

### Loops
Loops are also very important for the "\*" feature, which freezes all players on the server. This may be useful if there are some severe bugs that would affect the entire player base, so they are being frozen for thier own safety. This feature request a loop to go through all the online players on the server and add them all to the ArrayList of frozen players.

### Event Handlers
Event Handlers are used to prevent frozen players from moving, interacting with their environment, interacting with other players, typing commands or talking in chat, amongst other things. This is extremely useful and should be considered one of the core features of the system.

### Debugging
Debugging is extremely useful from a development standpoint as it helps me check where errors are in the code if any arise. I can do this by outputting messages when every action is performed, but only showing the messages to staff members if the debugging boolean is set to true. This should not be used in production to prevent spam towards the Administrator, as these messages will be sent in chat and could cause lots of spam such as a message being sent whenever a frozen player changes their position even by a centimeter.

### Variable Declaration and Scope
Variable declaration is useful as it allows me to store the unique identifiers of players who are frozen, meaning that checks can be performed on them and cancel their actions if they are within the list. The scope of this variable will be within the main class due to the fact that it will need to be accessed from every class, so it being stored in the main class makes it in the most central position possible.

### Constants
A constant that will be used is the ChatColor short hands. Instead of having to write out

`player.sendMessage(ChatColor.GOLD + "[" + ChatColor.YELLOW + "Colossal" + ChatColor.GOLD + "] " + ChatColor.DARK_AQUA + "You have been " + ChatColor.GREEN + "frozen" + ChatColor.DARK_AQUA + ".");`

Which is an excessively long line of code which will need to be changed if the formatting of the colours ever needs to change, I can just write:

```
ChatColor pri = ChatColor.DARK_AQUA;
ChatColor sec = ChatColor.GREEN;


player.sendMessage(ChatColor.GOLD + "[" + ChatColor.YELLOW + "Colossal" + ChatColor.GOLD + "] " + pri + "You have been " + sec + "frozen" + pri + ".");
```

Which is much shorter and more efficient. It also allows me to change the colour schema on the fly and it will be propagated across the entire program. Adding to this, I can add a `prefix` string to shorten this even more, changing it to:

```
string prefix = ChatColor.GOLD + "[" + ChatColor.YELLOW + "Colossal" + ChatColor.GOLD + "] ";
ChatColor pri = ChatColor.DARK_AQUA;
ChatColor sec = ChatColor.GREEN;


player.sendMessage(prefix + pri + "You have been " + sec + "frozen" + pri + ".");
```

As with the other constants, these variables will be accessible across the entire project.

### Data Types
I shall be using many different data types, some of which are primitive and can be found within the Java language, and some of which are more advanced and are native to Spigot. I shall list them as follows:

#### String
Strings will be used to store text data such as the `prefix` and are generally used for communicating with the user.

#### Integers
Integers will be used within for loops to keep track of which player they are currently operating on, along with using constants for changing timings on the fly. MAX_INT is also used for setting effects to be applied to the player infinitely.

#### ArrayList
An ArrayList will be used to keep track of all of the users that have been frozen, to ensure that if they perform any action that is not allowed and if they are in the ArrayList then it will be cancelled.

#### UUID
Due to the fact that players can change their usernames it is important to use their Universal Unique IDentifier, or UUID, when adding players to the ArrayList due to the fact they could just change their name and be thawed.

#### Entity
An Entity is any dynamic, moving object within the game. This encompasses but is not limited to players, animals and monsters, along with projectiles and boats. These will need to be intercepted when preventing actions.

##### Player
The Player is a subset of an entity that is controlled by the user. Both the Administrator and the users are considered players, but the Administrators cannot be frozen due to a specific permission node that prevents it, unlike regular users.

##### HumanEntity
The HumanEntity is an interface of the Player, and NPCs, that is used by chest functions within Spigot.

#### Projectile
The Projectile is an entity that moves through the air within the game. There are a few subsets of it, such as Arrows, Potions, EnderPearls, Eggs and Snowballs. As a rule of thumb, if the player can throw it then it is a Projectile. These will need to be

##### Potion
A Potion is an item within Minecraft that gives the consumer a specific effect when applied. They can either be drunk or, in the case of this instance, thrown onto the ground. These 'splash' potions cause an AoE which applies the potion effect to all entities within the vicinity.

##### EnderPearl
An EnderPearl is a projectile which can be thrown by the Player. When it lands, it is deleted and the Player is teleported to that position. This will need to be cancelled if the user is frozen due to the fact that the frozen user should not be able to move.

#### Inventory
An Inventory can be a large range of things, but in this case it will be both the menu that will be shown to the user when they are frozen, and also it will be the user's actual inventory to ensure that they cannot move anything around.

#### ItemStack
ItemStacks are all items that can be stored within an Inventory. These will be used when showing the menu to the player.

#### ItemMeta
ItemMeta is a subset of an ItemStack that is used for customizing the Item. It can change the name of the Item, as well as adding lore to the item.

#### ChatColor
ChatColor is the way that colours are used within Spigot, due to the fact that Minecraft only has 16 colours and 6 modifiers, such as obfuscated and bold. This will be used for all colour within the project, such as shown above when the user was informed that they were frozen.

### Triggers Used
There will be two methods of triggering a user being frozen by an Administrator, the first one will be typing the command `/freeze <playerName>`. The second will be selecting their name from an Inventory based menu system. These methods will add the user to the frozen ArrayList and will display the message to the user that they have been frozen. They will also be given a Blindness effect so that they cannot see, and then when they perform any action that is not permitted then it will be blocked, due to the other events within the project.

### Properties Assigned to Screen Components
There will not be that many on screen properties within this project due to the fact that this is a relatively small system, but I shall list them as follows:

#### Help Page
The help page will be shown when the user executes the command `chill`, `freezehelp`, `helpfreeze`, `sshelp` or `helpss`. When executed it will run the following code.
```
sender.sendMessage("/freeze <playerName> - Freezes/Unfreezes a player, used as a toggle. chill.freeze");
sender.sendMessage("/frozen <playerName> - Checks if a player is frozen. chill.frozen");
sender.sendMessage("/panic - Places you into panic mode, whereby you cannot be unfrozen. chill.panic");
```

#### Command Reference
If the player runs the commands either with too many arguments, not enough arguments or invalid arguments, a help prompt will be displayed to the user telling them what the correct syntax is. The following is an example of that:

```
sender.sendMessage("/freeze <playerName>");
```

#### Confirmation Page


#### User Menu


#### Admin Menu


#### Messages in Chat While Frozen


#### Messages in Chat when Action is Forbidden


* indicate all properties to be assigned to the screen components
* 3 well annotated design draft sketches
* test plan
* write algorithm & pseudo code

### Flow Chart
The following is a flow chart that will outline the process of this system:

<img src="https://raw.githubusercontent.com/Natfan/work/master/btec/14/2/Chill%20Flow%20Diagram.png"></img>

<div style="page-break-after=always;"></div>

## MII: Reasoning Behind Tools and Techniques
* list tools & techniques
* give reasons for the above
* justify the above
