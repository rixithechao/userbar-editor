# userbar-editor
A userbar creation package for the Unity editor.  It's primarily built with the talkhaus' annual Mosts event in mind, but the package should be flexible enough for more general needs. 

To use, modify the Obj_Userbar prefab and the instances of it in SampleScene as needed and then just screencap the Game view at 1x zoom and paste into your image editor of choice.

![demo gif](https://cdn.discordapp.com/attachments/583710218316415009/757856258329149540/userbarTool.gif)

General Tips:
- Needless to say, having at least a general familiarity with the Unity engine (the UI system especially) is recommended.
- The project is set up so that manually moving elements via their transforms is unnecessary;  most customization can be done entirely through the inspector fields, though you may need to dig through the objects' children to change a given part of the userbar.

Known Issues:
- Sometimes when tabbing into Unity or saving the scene or project, the text turns solid black.  To fix this, just play and stop the project.
