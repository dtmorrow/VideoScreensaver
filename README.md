# VideoScreensaver
This application functions as a screensaver that will play a looping video while active. The video that plays is configurable, as well as the volume of the video (if the video has sound).

## Requirements
Microsoft .NET Framework 4.5.2 or higher.

## Usage
* Place "VideoScreensaver.scr" in the folder you want to "install" it. It should not be moved from this folder after you install it until you decide to uninstall it.
* Right-click "VideoScreensaver.scr" and select "Configure" to open the configuration dialog. A configuration file (Config.txt) will be created in the same directory when you do this. This file stores the configuration settings and should remain in the same directory as the screensaver.
* After configuration, right-click "VideoScreensaver.scr" again and select "Test". If all is correct, the video should be playing full-screen, and any actions (mouse movements/clicks, key presses) should close the video.
* To install the screensaver, right-click and select "Install" to put the screensaver in Windows' Screen Saver Settings. It will then run whenever the selected wait time is reached.
* To uninstall the screensaver, simply open Windows' Screen Saver Settings, select any other screensaver or "None", then press the "OK" button. VideoScreensaver will be removed from the Windows' Screen Saver Settings drop-down menu. To be able to select it again, simply right-click "VideoScreensaver.scr" and select "Install" again.

## Building
Solution requires Visual Studio 2015.  
Project has post-build event that renames the target executable to have extension ".scr".
