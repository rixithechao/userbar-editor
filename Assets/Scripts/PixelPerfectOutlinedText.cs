using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class PixelPerfectOutlinedText : MonoBehaviour
{
	[TextArea] public string text;
	public TextAlignmentOptions alignment;
	[Space(20)]
	public OutlinedTextReferences refs;

	private string _text;
	private TextAlignmentOptions _alignment;


	public void UpdateText(string newText)
	{
		text = newText;
		_text = newText;
		foreach (TMP_Text item in refs.textComponents)
		{
			item.text = newText;
		}
	}

	void UpdateAlignment(TextAlignmentOptions newAlignment)
	{
		alignment = newAlignment;
		_alignment = newAlignment;
		foreach (TMP_Text item in refs.textComponents)
		{
			item.alignment = newAlignment;
		}
	}


#if UNITY_EDITOR
	private void OnValidate()
	{
		if (_text != text || _alignment != alignment)
		{
			UpdateText(text);
			UpdateAlignment(alignment);
		}
	}
#endif
}
