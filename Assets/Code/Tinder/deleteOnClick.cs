using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class deleteOnClick : MonoBehaviour {
    
    [SerializeField] private PlayableDirector director;
    
    void OnMouseDown()
    {
        director.Play();
        StartCoroutine(waitThenDestroy(0.25f));
    }

    IEnumerator waitThenDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        GameObject.Destroy(gameObject);
    }

}
