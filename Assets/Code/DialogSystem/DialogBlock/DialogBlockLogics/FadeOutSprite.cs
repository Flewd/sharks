using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;

public class FadeOutSprite : DialogBlockLogic {

	[SerializeField] private Image image;
	
	[SerializeField] private float fadeSpeed = 0.01f;
	
	private Color SubtractColor;
	
	public override void execute(IDialogLogicComplete callback)
	{
		base.execute(callback);
		execute();
	}
	
	public override void execute()
	{
		base.execute();
		SubtractColor = new Color(0,0,0,fadeSpeed);
		StartCoroutine(incremenFade());
	}
	
	IEnumerator incremenFade()
	{
		while (image.color.a > 0)
		{
			image.color -= SubtractColor;
			yield return new WaitForSeconds(0.01f);
		}
		LogicComplete();
	}
}
