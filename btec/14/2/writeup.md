# Unit XIV Assignment II
*By Nathan Windisch*

## PIII: Designing A Bespoke Event Driven Application
The software that I shall be designing is a plugin for piece of server software called `Spigot` that is used to make the generation of add-ons to the video game `Minecraft`. The plugin in question is called **Chill**, a tool which allows Administrators to freeze possible cheaters to prevent them from causing any more damage to legitimate players. After this point they can a voice chat service such as Teamspeak3 or Discord so that they can communicate with the staff member that froze them, possibly share their screen and, after rigorous checks, may be unfrozen. If it turns out that the player was cheating, they will be punished accordingly. The input of the program is when the Administrator freezes a player, the output is when the user tries to perform an action that is prohibited while they are frozen, along with notifying staff members when a person who should not be frozen is attempted to be frozen, and the process is the blocking of these actions. The following is a basic outline of how the program will work:

* The Administrator finds a cheat is firing up a large number of alerts from our AntiCheat systems,
* The Administrator teleports to the suspected cheater,
* The Administrator confirms that the user is breaking the rules or using external software to gain an unfair advantage,
* The Administrator freezes the user, blocking their access to perform any actions including movement, chat, commands, interacting with the world or other entities,
* The Administrator requests the user to join voice chat and searches their installation folder for any malicious files,
* If the Administrator finds anything on the user that they should not have, they will be punished accordingly; this can include being removed from the server either temporarily or permanently,
* If the Administrator does not find anything, then the user will be thawed and they will be allowed to continue their game.


* show tools & techniques used
 - selection
 - loop
 - event handler
 - debugging
 - var declaration
 - var scope
 - constants
 - data types
* examples of triggers used
 - commands executed
 - staff freezing player via right click/menu
* indicate all properties to be assigned to the screen components
* 3 well annotated design draft sketches
* test plan
* write algorithm & pseudo code
* flow chart

<div style="page-break-after=always;"></div>

## MII: Reasoning Behind Tools and Techniques
* list tools & techniques
* give reasons for the above
* justify the above
