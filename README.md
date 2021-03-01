# userbar-editor
A userbar creation package for the Unity editor (version 2019.4.3f1).  It was primarily built with the talkhaus' annual Mosts event in mind, but the package should be flexible enough for more general needs.

![demo gif (slightly outdated)](https://cdn.discordapp.com/attachments/583710218316415009/757856258329149540/userbarTool.gif)

**How to Use:** 
1. Modify the Obj_Userbar prefab and the instances of it in SampleScene as needed.  Make sure to specify a unique File Suffix for every userbar you want to export.
2. Play the project and resize the editor/Game view window so that all userbars you want to export are fully shown. Any that are even partially offscreen will not export correctly.
3. Press the Enter/Return key to export the userbars. The results will be output to the Unity console.


**General Tips:**
- Needless to say, having at least a general familiarity with the Unity engine and editor (the UI system especially) is recommended.
- The project is set up to handle the sizes and positions of the userbar objects automatically.  Attempting to manually move or resize individual userbars is not recommended, but you can configure the layout via the Grid Layout Group fields on the Thin List and Thick List objects.
- The main customization is done through the inspector fields of the Userbar script, though you may need to dig through the child objects to change certain parts of the bars.
- For efficiency, it's best to edit the File Prefix field in prefab edit mode and only specify exceptions on a per-instance basis.


**Troubleshooting/Known Issues:**
- Only userbars with a File Suffix string will be exported. If one seemingly doesn't get exported and there's no mention of it in the Console, check to make sure that field isn't blank and that it doesn't share its prefix and suffix with another userbar.
- Sometimes when tabbing into Unity or saving the scene or project, the text turns solid black.  Playing and stopping the project will fix it.
