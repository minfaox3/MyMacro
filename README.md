# MyMacro
![thumb](https://github.com/minfaox3/MyMacro/blob/master/thumb.gif?raw=true)

## Description
This application allows actions such as mouse operations and keystrokes to be performed continuously and repeatedly.  
A series of actions can be written out as a file and read back in.

## Dependences
OS：Windows  
Develop Language：C#  
Framework：.NET 8.0  

Used Packages：  
* InputSimulator by Michael Noonan
    * https://www.nuget.org/packages/InputSimulator/1.0.4
    * MIT License
* Newtonsoft.Json by James Newton-King
    * https://www.nuget.org/packages/Newtonsoft.Json/13.0.3
    * MIT License

## Usage
Simply follow the text displayed on each button in the screen.  
![view](https://github.com/minfaox3/MyMacro/blob/master/view.png?raw=true)

### 1.Select window
Select the window you wish to operate on from the "Target Window".  
You can update the list of windows with the Update button.  
Windows that are not activated cannot be selected.  

When you decide which window to select with the Select button, a thumbnail image of that window is displayed in the "Selected window" on the right side.  
When selecting a window that is running with privilege, MyMacro also requires privilege, so the Request Privilege window is displayed. If you approve, MyMacro will restart with privilege, so please select that window again.  

### 2.Create action order
You can register your favorite actions from "Key," "Mouse," "Click," "Scroll," "Text," and "Delay" in "MacroSettings" by push "Add" button.  
You can also export and import action data from "File" at the top of the screen.  

#### Key
For each key, you can make either "Down", "Press", or "Up" movement.

#### Mouse
Enter the position you want the mouse to move to. The position can be within the coordinates of a virtual window (including not only the primary monitor but also extended windows such as a secondary monitor).  
The current mouse position is always displayed in the status bar at the bottom of MyMacro, except when a macro is running.  

#### Click
For each mouse button, you can make either "Click", "DoubleClick", "Down", or "Up" movement.

#### Scroll
Can scroll horizontally or vertically. Upward and rightward scrolling is on the plus side.  

#### Text
Text entered in the text box will be typed.

#### Delay
Waiting processing can be performed in ms or sec.  

### 3.Edit actions order
The added actions are displayed in the Order table in the lower left corner of the screen, and can be reordered with the Up and Down buttons or deleted with the Delete button.  

### 4.Play actions
Press Play in the lower right corner of the screen to execute the action.

#### Loop
Checking the Loop checkbox repeats the action.   
The interval until the next loop can be specified in the text box to the right of "LoopSpan.

#### Terminate
The "TerminateKey" allows you to set the key for interruption.  
Select a key not to be used in the action.

## Note
For safety reasons, it will not be executed when the specified window is not in focus.
Therefore, pressing "Play" will automatically focus the target window, but if the user takes an action that takes the window out of focus, no action will be taken at that time.

## LICENSE
[MIT](https://github.com/minfaox3/MyMacro/blob/master/LICENSE)