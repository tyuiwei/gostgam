﻿using UnityEngine;
using System.Collections;

public class GhostController : MonoBehaviour {

	public float speed = 1;
	public float timeInDirection = 4;
	public int timesSnapped = 0;
	public int snapsAllowed = 3;

	private float time = 0;
	private Vector2 dir;

	// Use this for initialization
	void Start () {

		pickDir (); 

	}
	
	// Update is called once per frame
	void Update () {

		if (time < timeInDirection) {
			transform.Translate (dir * speed * Time.deltaTime);
		} else {
			pickDir ();
			time = 0;
		}
		if (transform.position.x <= (-1 * GameManager.mapSize.x / 2) || transform.position.x >= (GameManager.mapSize.x / 2)) {
			Vector2 pos = transform.position;
			transform.position = new Vector2(-1*pos.x, pos.y) ;
		}		
		if (transform.position.y <= (-1 * GameManager.mapSize.y / 2) || transform.position.y >= (GameManager.mapSize.y / 2)) {
			Vector2 pos = transform.position;
			transform.position = new Vector2(pos.x, -1*pos.y) ;
		}
		if (timesSnapped >= snapsAllowed) {
			goAway ();
			timesSnapped = 0;

		}
		time += Time.deltaTime;

	}

	void pickDir() {
		dir = new Vector2 (Random.Range (-1, 1), Random.Range (-1, 1));
		//Debug.Log (time);
	}
	public void goAway() {
		gameObject.transform.position = new Vector3 ((Random.Range(0, 1)*2-1)*GameManager.mapSize.x/2, (Random.Range(0, 1)*2-1)*GameManager.mapSize.y/2)
	}




}
