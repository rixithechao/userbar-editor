using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UserbarReferences : MonoBehaviour
{
	public PixelPerfectOutlinedText winnerTextComponent;
	public PixelPerfectOutlinedText categoryTextComponent;
	public Image imageComponent;
	public RectTransform barTransform;


	public void UpdateWinner(string newText)
	{
		winnerTextComponent.UpdateText(newText);
	}
	public void UpdateCategory(string newText)
	{
		categoryTextComponent.UpdateText(newText);
	}
	public void UpdateBackground(Sprite newBg)
	{
		imageComponent.sprite = newBg;
	}
}
