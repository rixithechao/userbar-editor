using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Userbar : MonoBehaviour
{
	[TextArea] public string categoryText;
	[TextArea] public string winnerText;
	public Sprite background;
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
}
