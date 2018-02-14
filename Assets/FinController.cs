using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinController : MonoBehaviour
{
	[SerializeField] private GameObject TargetPosition;

	private Transform originalPosition;
	
	private Transform startMarker;
	private Transform endMarker;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;

	[SerializeField]
	private bool isMoving = false;
	
	[SerializeField]
	private bool isReturning = false;
	// Use this for initialization
	void Start ()
	{
		startMarker = gameObject.transform;
		originalPosition = startMarker;
		endMarker = TargetPosition.transform;
		DoMotion();
	}
	
	// Update is called once per frame
	void Update () {

		if (isMoving)
		{
			if (isReturning)
			{
				moveTowardsOriginalPostion();
			}
			else
			{
				moveTowardsTarget();
			}
		}
	}

	public void DoMotion()
	{
		startTime = Time.time;
		journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
		isMoving = true;
	}
	
	private void moveTowardsTarget()
	{
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fracJourney);

		if (transform.position == endMarker.position)
		{
			print("flip tween");
			startTime = Time.time;
			journeyLength = Vector3.Distance( startMarker.position, endMarker.position );
			isReturning = true;
		}
	}

	private void moveTowardsOriginalPostion()
	{
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp(endMarker.position, startMarker.position, fracJourney);

		if (transform.position == startMarker.position)
		{
			isReturning = false;
			isMoving = false;
		}
	}
}
