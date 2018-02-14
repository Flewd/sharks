using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class PhotoButton : MonoBehaviour {

    [SerializeField]
    SharkFrame spriteFrame;

    [SerializeField]
    int imageButtonIndex = 0;

	[SerializeField] private PlayableDirector director;

    void OnMouseDown()
    {
	    director.Play();
	    StartCoroutine(waitThenPress(0.25f));
    }
	
	IEnumerator waitThenPress(float time)
	{
		yield return new WaitForSeconds(time);
		spriteFrame.ImageButtonPressed(imageButtonIndex);
	}
}
