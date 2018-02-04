using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {

	public GameObject toSpawn;
	public int numToSpawn;
	public Vector3 spawnPoint;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			for (int i = 0; i < numToSpawn; i++) {
				GameObject newSpawn = Instantiate (toSpawn);
				newSpawn.transform.position = spawnPoint;
			}
			Destroy (gameObject);
		}
	}
}
