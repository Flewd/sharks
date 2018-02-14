using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class heartButton : MonoBehaviour {

    [SerializeField]
    GameObject finalScreen;

    [SerializeField] private PlayableDirector director;

    private void OnMouseDown()
    {
        director.Play();
        StartCoroutine(waitThenPress(0.25f));
    }
    
    IEnumerator waitThenPress(float time)
    {
        yield return new WaitForSeconds(time);
        finalScreen.SetActive(true);
    }
}
