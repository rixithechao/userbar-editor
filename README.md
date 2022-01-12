# userbar-editor
A userbar creation framework for the Unity editor (version 2019.4.3f1).  It was primarily built with the talkhaus' annual Mosts event in mind, but the framework should be flexible enough for more general needs.

![demo gif (outdated)](https://cdn.discordapp.com/attachments/583710218316415009/757856258329149540/userbarTool.gif)

**How to Use:**
1. Modify the Obj_Userbar prefab and the instances of it in SampleScene as needed.  Make sure to specify a unique File Suffix for every userbar you want to export.
2. Play the project and resize the editor/Game view window so that all userbars you want to export are fully shown. Any that are even partially offscreen will not export correctly.
3. Press the Enter/Return key to export the userbars. The results will be output to the Unity console.


**General Tips:**
- Needless to say, having at least a general familiarity with the Unity engine and editor (the UI system especially) is recommended.
- The project is set up to handle the sizes and positions of the userbar objects automatically.  Attempting to manually move or resize individual userbars is not recommended, but you can configure the layout via the Grid Layout Group fields on the Thin List and Thick List objects.
- The main customization is done through the inspector fields of the Userbar script, though you may need to dig through the child objects to change certain elements of the bars.
- For efficiency, it's best to edit the File Prefix field in prefab edit mode and only specify exceptions on a per-instance basis.
- If using this tool for multiple styles and sets of userbars, you may want to make a copy of SampleScene and a duplicate or Prefab Variant of Obj_Userbar for each occasion instead of editing SampleScene and Obj_Userbar directly.  (Prefab Variants will initially appear invisible; see the Troubleshooting/Known Issues section for a fix.)


**Troubleshooting/Known Issues:**
- Only userbars with a File Suffix string will be exported. If one seemingly doesn't get exported and there's no mention of it in the Console, check to make sure that field isn't blank and that it doesn't share its prefix and suffix with another userbar.
- Sometimes when tabbing into Unity or saving the scene or project, the text turns solid black.  Playing and stopping the project will fix it.
- Prefab Variants of Obj_Userbar will initially appear invisible.  To fix this, open the variant in the prefab editor, then in the inspector click the Revert All button inside the Overrides dropdown.  Make sure to do this before any customization as it will revert your changes!
