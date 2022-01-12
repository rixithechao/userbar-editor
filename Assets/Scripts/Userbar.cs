using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Userbar : MonoBehaviour
{
	[Header("Basic elements")]
	[TextArea] public string categoryText;
	[TextArea] public string winnerText;
	public Sprite background;

	[Header("Further customization")]
	[Space(20)]
	public Sprite overlay;
	public Sprite border;

	public Color backgroundTint;
	public Color overlayTint;
	public Color borderTint;

	[Header("Output")]
	[Space(20)]
	public string filePrefix = "output_";
	public string fileSuffix;

	[HideInInspector]
	public UserbarReferences refs;


	private string _categoryText;
	private string _winnerText;

	private Sprite _background;
	private Sprite _overlay;
	private Sprite _border;

	private Color _backgroundTint;
	private Color _overlayTint;
	private Color _borderTint;


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

	public void UpdateBackground(Sprite newImg)
	{
		_background = newImg;
		background = newImg;
		refs.UpdateImageSprite(refs.backgroundImageComponent, newImg);
	}
	public void UpdateOverlay(Sprite newImg)
	{
		_overlay = newImg;
		overlay = newImg;
		refs.UpdateImageSprite(refs.overlayImageComponent, newImg);
	}
	public void UpdateBorder(Sprite newImg)
	{
		_border = newImg;
		border = newImg;
		refs.UpdateImageSprite(refs.borderImageComponent, newImg);
	}

	public void UpdateBackgroundTint(Color newColor)
	{
		_backgroundTint = newColor;
		backgroundTint = newColor;
		refs.UpdateImageTint(refs.backgroundImageComponent, newColor);
	}
	public void UpdateOverlayTint(Color newColor)
	{
		_overlayTint = newColor;
		overlayTint = newColor;
		refs.UpdateImageTint(refs.overlayImageComponent, newColor);
	}
	public void UpdateBorderTint(Color newColor)
	{
		_borderTint = newColor;
		borderTint = newColor;
		refs.UpdateImageTint(refs.borderImageComponent, newColor);
	}



	#if UNITY_EDITOR
	private void OnValidate()
	{
		if (_categoryText != categoryText
		||  _winnerText != winnerText
		)
		{
			UpdateCategory(categoryText);
			UpdateWinner(winnerText);
		}

		if (_background != background
		||  _overlay != overlay
		||  _border != border
		)
		{
			UpdateBackground(background);
			UpdateOverlay(overlay);
			UpdateBorder(border);
		}

		if (_backgroundTint != backgroundTint
		||  _overlayTint != overlayTint
		||  _borderTint != borderTint
		)
		{
			UpdateBackgroundTint(backgroundTint);
			UpdateOverlayTint(overlayTint);
			UpdateBorderTint(borderTint);
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
