# Unit XIV Assignment I
*By Nathan Windisch*

## PI: Features of Event Driven Programming
* [x] Define what is meant by event driven programming
* [x] Give examples of event driven systems
* [x] Give examples of programming languages used for event driven programs
* [x] Explain features of event driven programs

* [x] Service orientated
* [x] Time driven
* [x] Trigger functions
* [x] Events
* [ ] Event loops
* [ ] Flexibility
* [ ] Suitability for GUI
* [ ] Simplicity of programming
* [ ] Ease of development

### What is Event Driven Programming?
Event Driven Programming is the usage of events to define the outcome of the program. Events can be actions performed by the user, such as mouse clicks or key presses, inputs from sensors, or from calls sent by another thread. This means that the most programs that are written today that have some sort of user interactive feature are based on code that is event driven, due to the fact that having actions that respond to the user are inherently event driven. The following are some examples of programming languages that utilize event driven architecture:
* Java
* Visual C++
* Visual Basic
While all of these programing languages are similar and can do the same things, some are better suited to certain tasks than others. For instance, Visual Basic is better suited for entry level programming as it can make quick GUI based programs for easy access. Visual C++ is used for powerful but small programs that need to either work fast or work on systems with low amounts of resources such as embedded systems. This includes clocks in washing machines and microwaves, for example. Java is a more general purpose language that is used for making programs with high levels of compatibility as it works across many devices without the need of rewriting any code.

### What Are Event Driven Systems
Event Driven Systems are programs that have are based around the input that the user gives. Based on this, a specific output is devised and shown to the user. An example of this could be a calculator program that switches between a simple calculator layout and a more complex, scientific calculator layout. Event Driven Systems are incredibly useful for large corporations as they can perform complex functions with little user input, such as adding information to a database or retrieving certain parts of a file, both of which would need long commands such as `SQL` or `grep`. Event Driven Systems are especially useful for embedded systems such as sprinker systems which will need to retrieve if the internal temperature of the building is too high, or if a fire alarm has been pressed.

### Service Orientation
Service Orientation is used in event driven programing as a way to ensure that only a small amount of system resources are used by specific programs. This means that applications and features that run in the background do not need to take up large chunks of CPU or RAM usage, meaning that the total uptime of the system will be increased as these parts of the system do not need to be run 24/7. A good example of an application that takes advantage of Service Orientation are drivers, which are installed in the background whenever a new device that needs them is installed, ensuring that new physical devices can work properly on the fly. These services that install these key DLL files are very small and are only called when used, meaning that they are event driven as they are only used when needed.

### Time Driven
Time Driven functions are sections of code that are run on a timely basis, such as every hour or twice a week. These are very useful for automated systems that need to perform nightly backups, as no systems administrator needs to be there in order to start the process, it does it automatically based on the system's internal clock. Another good usage for Time Driven code is when performing Operating System update checks, as it means that the system runs independent of the central server. This can mean that user updates are staggered, if the user base is large, to prevent to many connections accessing one specific file or group of files, such as an Operating System upgrade.

### Trigger Functions
Trigger functions are the core part of event driven programming. They are called when specific actions are run, and many different trigger functions can be assigned to one specific action. An example of this could be an automated door system. During the day, the automatic doors open when the sensor is tripped but when the doors are locked during the night time the doors will not open. If the sensors in the doors motors sense that the door is being opened by force while locked, the local law enforcement could be called and notified of a possible break in. If the door is in "secure" mode then it can only be opened by RFID cards which are scanned onto the reader next to the door. This bypasses the lock and does not notify law enforcement.

### Events
#### Mouse Events
Mouse Events can be triggered when the mouse moves into a certain position on the screen, or if a certain area is clicked. Also, when the scroll wheel is moved either up or down could trigger an event, along with the forwards and backwards buttons being pressed on the side of the mouse.

#### Keyboard Events
Keyboard Events can be triggered when any key on the keyboard is pressed. An example of this is that when `F1` is pressed then a help message is normally displayed to the user. When the up and down keys on the keyboard are pressed, the page may change position. This can also be configured to use the `VI` and `VIM` keybinds, which are `H` for left, `L` for right, `J` for up and `K` for down.

#### Forms and UI
In Microsoft's `Windows`, Forms are objects that open a specific application when activated. An example of this is your home directory being opened when "My Computer" is pressed. Another example is that when the user presses on the "Google Chrome" shortcut is pressed, the internet browser opens. Forms are incredibly useful to the user experience, or UX, as it allows for programs and features to be accessed with ease, without the use of the command line interface.

#### External Events
External Events are called when a user requests that a program opens a specific file type, such as `Okular` opening the .pdf file type by default.

### Event Loops
Event Loops are called when a specific event needs to run multiple times in quick succession. An example of this is when a user enters in some text into a form that is not the correct data type, then the system should report to the user that an error occurred until the user fixes it.
