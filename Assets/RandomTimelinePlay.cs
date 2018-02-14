using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class RandomTimelinePlay : MonoBehaviour
{
	[SerializeField] private PlayableDirector director;

	private float tempInterval = 0;
	[SerializeField] private float onPlayDelay = 0f;
	[SerializeField] private float interval = 1f;
	[SerializeField] private float odds = 0.5f;
	
	// Use this for initialization
	void Start ()
	{
		StartCoroutine(waitCheckOdds(interval));
	}

	IEnumerator waitCheckOdds(float seconds)
	{
		yield return new WaitForSeconds(seconds + tempInterval);

		float rand = Random.Range(0f, 1f);

		if (rand <= odds)
		{
			director.Play();
			tempInterval = onPlayDelay;
		}
		else
		{
			tempInterval = 0;
		}
		
		StartCoroutine(waitCheckOdds(interval));
	}
}

/*
 * 
 * 
 * -1.66355
 * -1.213743
 * 0.149000
 * z rot 30.346