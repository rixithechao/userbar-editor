using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userbar : MonoBehaviour
{
	[TextArea] public string categoryText;
	[TextArea] public string winnerText;
	public Sprite background;
	[Space(20)]
	public string filePrefix = "output_";
	public string fileSuffix;
	[Space(20)]
	public UserbarReferences refs;


	private string _categoryText;
	private string _winnerText;
	private Sprite _background;


	public void UpdateCategory(string newText)
	{
		_categoryText = newText;
		categoryText = newText;
		refs.UpdateCategory(newText);
	}

	public void UpdateWinner(string newText)
	{
		_winnerText = newText;
		winnerText = newText;
		refs.UpdateWinner(newText);
	}

	public void UpdateBackground(Sprite newBg)
	{
		_background = newBg;
		background = newBg;
		refs.UpdateBackground(newBg);
	}


	#if UNITY_EDITOR
	private void OnValidate()
	{
		if (_categoryText != categoryText  || _winnerText != winnerText  ||  _background != background)
		{
			UpdateCategory(categoryText);
			UpdateWinner(winnerText);
			UpdateBackground(background);
		}
	}
	#endif


	public void Update()
	{
		if (Input.GetKeyUp(KeyCode.Return))
		{
			if (fileSuffix != null && fileSuffix != "")
				StartCoroutine(ExportImageFile());
		}
	}


	private IEnumerator ExportImageFile()
	{
		yield return 0;
		yield return new WaitForEndOfFrame (); // it must be a coroutine 

    	Vector3[] corners = new Vector3[4];
	    refs.barTransform.GetWorldCorners(corners);
		Vector3 topLeft = RectTransformUtility.WorldToScreenPoint(null, corners[0]);

		var gameViewSize = UnityEditor.Handles.GetMainGameViewSize();
		Canvas myCanvas = transform.root.GetComponent<Canvas>();
		Rect screenRect = RectTransformUtility.PixelAdjustRect(refs.barTransform, myCanvas);
		
		screenRect.x = topLeft.x; //refs.barTransform.anchoredPosition.x;
		screenRect.y = topLeft.y; //gameViewSize.y + refs.barTransform.anchoredPosition.y - screenRect.height;
		Texture2D tex = new Texture2D((int)screenRect.width, (int)screenRect.height, TextureFormat.RGB24, false);

		if (screenRect.xMax > gameViewSize.x  ||  screenRect.yMax > gameViewSize.y  ||  screenRect.x < 0  ||  screenRect.y < 0)
		{
			Debug.LogWarning("Cannot export " + filePrefix + fileSuffix + ".png, the userbar is not fully inside the Game view!");
		}
		else
		{
			tex.ReadPixels(screenRect, 0, 0);
			tex.Apply();
		
			// Encode texture into PNG
			var bytes = tex.EncodeToPNG();
			string filePath = Application.dataPath + "/Output/" + filePrefix + fileSuffix + ".png";

			System.IO.File.WriteAllBytes(filePath, bytes);
			Debug.Log(
				//"ANCHORED POSITION = " + refs.barTransform.anchoredPosition.ToString() + 
				//"\nSCREENSPACE RECT = " + screenRect.ToString() +
				"Userbar image exported to " + filePath);

		}

		#if UNITY_EDITOR
			DestroyImmediate(tex);
		#else
			Destroy(tex);	
		#endif
	}
}
