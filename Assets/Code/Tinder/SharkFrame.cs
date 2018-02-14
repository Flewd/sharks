using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SharkFrame : MonoBehaviour {

    SpriteRenderer SpriteCanvas;

    [SerializeField]
    Sprite[] photos;

	// Use this for initialization
	void Start () {
        SpriteCanvas = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ImageButtonPressed(int imageNumber)
    {
        SpriteCanvas.sprite = photos[imageNumber];
    }
}
