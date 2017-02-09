# Computer Science Project
*By Nathan Windisch*

## Introduction
### Scope
The issue is that there are not many choose-your-adventure video games on the market right now. My client is Oliver Eastgreen Cox and he has requested that I work with him to develop an application which will enable the user to play through predetermined stories, along with an audiobook being played alongside, for those with headphones who prefer listening to reading. The proposed final product, which I shall not be developing in this project but will be worked on later if further expansion is required, will have multiple free stories for the user to choose from, all with different themes and lengths in order to satisfy everyone's fictional tastes, from Science Fiction to Fantasy to Horror. All stories are intended to have multiple endings, but only a few of them may be able to be completed for this demonstration. Expansion packs could be made later down the line, to generate more profit. These expansion packs could be more stories categorised under different genres, changes to the colour scheme of the user interface or general soft currency which could be used to purchase these features or more that we add in the future. Another idea that has been toyed with is the ability for players to gain achievements while playing which, in turn will give them the soft currency for free, meaning that users can gain access to the paid content without spending any money at all, it will just be significantly harder as they will not earn as much as those that pay. As the game is single player, balance is not an issue at all due to the fact that nothing that a player does will have any significance to any other player at all. A player can cheat through the entire game and it will have no consequence to the rest of the playerbase.

To recap, the project will have the following features:

* A basic story with two or three different outcomes
* Items that are required to perform various actions within the story
* A menu which allows the user to select stories that they have selected
* A UI which is easy to use
* An options page
* A credits page

<div style="page-break-after: always;"></div>

### Boundaries
`input and output`

<div style="page-break-after: always;"></div>

### Convincing The Client
When discussing with the client for the first time we had a talk about what we wanted to create. He wanted an Android and possible an iOS application, but I explained to him that the development of two applications was too tricky. He listed the things that he wanted from the product, which I mentioned beforehand. After noting down what he wanted from me, I set to work on creating my very first Android application. After vigerous testing, I decided that it would be easier if I made a C# console varient of the game, and then ported it over to Android (and therefore Java, which is avery similar language) later, once it was finished.

<div style="page-break-after: always;"></div>

### Complexity
text

<div style="page-break-after: always;"></div>

## Analysis
### Outline
I have decided to approach the project by listing all the features that the client needs to have completed for a base product, what could be added to the project within the timescale and what may be added if there was a larger timespan on which to develop this program to it's full potential, if there were more time and resources available to me and my client. Some of the tasks that the client would like me to complete are:

* UI configuration
* Viewing stories grouped by genre
* Viewing stories grouped by last read
* Viewing stories grouped by user rating

The following are some tasks which would be possible if a second round of development were to be initiated, or if a longer timespan with more resources were to be used instead:

* Audio playing along with the user reader reading the story
* Access to a store page where users can purchase expansion packs and other downloadable content
* Ability to unlock and view achievements
* Ability to sign up to a web service in order to save and load progress, along with achievements and configuration profiles
* Ability to view leaderboards to see who has completed stories in the shortest amounts of time, with the most gear unlocked, who gained the most achievements and more

<div style="page-break-after: always;"></div>

### Use Case Diagram
The following is a UML 2.0 diagram that I have created to show how the proposed system will work.

<img src="resources/images/umlusecase.png" style="width=100%"></img>

As you can see, the Player has a few different options that they can choose from, such as:

* Creating the game
* Loading previously saved games
* Playing the game, which both creating and loading the game inherently extends their functionality towards
* Changing options
* Viewing the credits menu

Once they create the game, the game is instantly written to disc, meaning that it is persistant. When the user enters the game, they can view a menu which gives them two options:

* Saving the game
* Exiting the game

It is important to note that if you wish to quit and save your progress you will need to save then quit, or the game will just exit without writing your progress to the configuration files.

<div style="page-break-after: always;"></div>

### IOPS Chart
`Complexity, Storage, Estimates`
`Input, Output, Processing and Storage`

When working with my Use Case UML diagram, I discovered that there were a few IOPS procedures that needed to be looked at before I could continue. For reference, IOPS stands for `Input, Output, Processing and Storage`.

The first IOPS issue that I came across was the fact that I was not fully sure how I would allow the user to generate the default game files so that the user can create the game for the first time. I developed the following chart to make it clearer for myself when I got round to developing the actual program.

<img src="resources/images/iops1.png" style="width=100%"></img>

This is an IOPS chart that shows how a game is created. It contains redunancies to allow the user to enter the Load Game screen but still create a fresh game save if they have none currently.

The second IOPS issue that I came across is that I do not have a visual representation as to how the Change Options and Credits Menu functions will work. The following is a quick IOPS chart as to how the Change Options menu shall function:

<img src="resources/images/iops2.png" style="width=100%"></img>

The following IOPS chart is how the Credits menu will function:

<img src="resources/images/iops3.png" style="width=100%"></img>

<div style="page-break-after: always;"></div>

### SMART Objectives
After identifying my Use Case issues via IOPS, I decided to create a SMART Objectives table to list all the subissues that I have and if they fall under the SMART categories or not. SMART stands for `Specfic`, `Measureable`, `Achieveable`, `Realistic` and `Time Bound`.

|Use Case|Objective|S|M|A|R|T|
|-|
|UC1|Checking if user is in the main menu|Y|Y|Y|Y|Y|
|UC1|Checking if user clicks "create game"|Y|Y|Y|Y|Y|
|UC1|Checking if user has a game already|Y|Y|Y|Y|Y|
|UC1|If the user has a game already, go to the Load Game screen|Y|Y|Y|Y|Y|
|UC1|If the user doesn't have a game already, go to the Create Game screen|Y|Y|Y|Y|Y|
|UC1|Checking if user clicks "load game"|Y|Y|Y|Y|Y|
|UC1|Checking if user has a game already|Y|Y|Y|Y|Y|
|UC1|If the user has a game already, go to the Load Game screen|Y|Y|Y|Y|Y|
|UC1|If the user doesn't have a game already, go to the Create Game screen|Y|Y|Y|Y|Y|
|UC2|Check if user is in the main menu|Y|Y|Y|Y|Y|
|UC2|Check if user is clicks "Change Options"|Y|Y|Y|Y|Y|
|UC2|Go to the "Change Options" menu|Y|Y|Y|Y|Y|
|UC3|Check if user is in the main menu|Y|Y|Y|Y|Y|
|UC3|Check if user is clicks "Credits"|Y|Y|Y|Y|Y|
|UC3|Go to the "Credits" menu|Y|Y|Y|Y|Y|

<div style="page-break-after: always;"></div>

### Interview
After generating all of this data I met up with my client for my first interview. The following is a rundown of what was said. The prefix `[O]` is for things that my client, Oliver Cox said, and the prefix `[N]` is for things that I said.

[O]:

<div style="page-break-after: always;"></div>

### Feedback
text

<div style="page-break-after: always;"></div>

## Design
### Testing Strategy
text

<div style="page-break-after: always;"></div>

### Test Plan
`table with main tests then more rows with subtests`

The following are my test cases. Please note that the numbers under **Play Game** are due to the fact that I have a total of four tests currently set up, and each one can be dependent on any other. This means that there is a total of 16 possible tests, and I performed them all. The **Options** subsection is when I tested a quick mock up of the application, and the results can be seen in the table below.

|Test #|Test Description|Test Date|Bugs Detected?|Bugs Fixed?|New Bugs Created?|
|-|
|N/A|**Play Game**|N/A|N/A|N/A|N/A|
|01|0000|22-Jun-16|10:01|N|N/A|
|02|0001|22-Jun-16|10:03|N|N/A|
|03|0010|22-Jun-16|10:05|N|N/A|
|04|0011|22-Jun-16|10:07|N|N/A|
|05|0100|22-Jun-16|10:09|N|N/A|
|06|0101|22-Jun-16|10:11|N|N/A|
|07|0110|22-Jun-16|10:13|N|N/A|
|08|0111|22-Jun-16|10:15|N|N/A|
|09|1000|22-Jun-16|10:17|N|N/A|
|10|1001|22-Jun-16|10:19|N|N/A|
|11|1010|22-Jun-16|10:21|N|N/A|
|12|1011|22-Jun-16|10:23|N|N/A|
|13|1100|22-Jun-16|10:25|Y|Y|
|14|1101|22-Jun-16|10:27|Y|Y|
|15|1110|22-Jun-16|10:29|Y|Y|
|16|1111|22-Jun-16|10:31|Y|Y|
|N/A|**Options**|N/A|N/A|N/A|N/A|
|17|fastType enabled|22-Jun-16|10:42|N|N/A|
|19|instaType enabled|22-Jun-16|10:44|N|N/A|
|18|fastType and instaType enabled|22-Jun-16|10:46|Y|Y|
|N/A|**Edit Options**|N/A|N/A|N/A|N/A|
|20|Edit key for skip|22-Jun-16|10:53|N|N/A|
|21|Edit key for option 1|22-Jun-16|10:53|N|N/A|
|22|Edit key for option 2|22-Jun-16|10:53|N|N/A|

<div style="page-break-after: always;"></div>

### Entity Relationship Diagram
text

<div style="page-break-after: always;"></div>

### HCI (?)
text

<div style="page-break-after: always;"></div>

### Flow Chart
`per usecase`

<div style="page-break-after: always;"></div>

### Class Diagram
`uml 2.0`
`object, module, flow`

<div style="page-break-after: always;"></div>

## Implementation
`C#, JS, SQL, PHP`
`src, annotations`

<div style="page-break-after: always;"></div>

## Testing
`evidence table, with pass/fail`
`interation tests and fixes`

<div style="page-break-after: always;"></div>

## Evaluation

`User Acceptance Testing`

<div style="page-break-after: always;"></div>

`SMART`

<div style="page-break-after: always;"></div>

`Interview Feedback`

<div style="page-break-after: always;"></div>

`Future Extentions: cost, impact, etc`

<div style="page-break-after: always;"></div>

## Sources