using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UserbarReferences : MonoBehaviour
{
	public PixelPerfectOutlinedText winnerTextComponent;
	public PixelPerfectOutlinedText categoryTextComponent;
	public Image backgroundImageComponent;
	public Image overlayImageComponent;
	public Image borderImageComponent;
	public RectTransform barTransform;


	public void UpdateWinner(string newText)
	{
		winnerTextComponent.UpdateText(newText);
	}
	public void UpdateCategory(string newText)
	{
		categoryTextComponent.UpdateText(newText);
	}

	public void UpdateImageSprite(Image imgRef, Sprite newImg)
	{
		imgRef.sprite = newImg;
	}
	public void UpdateImageTint(Image imgRef, Color newColor)
	{
		imgRef.color = newColor;
	}
}
