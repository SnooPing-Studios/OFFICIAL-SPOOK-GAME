using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	// Public variables, configure in inspector
	public GameObject projectile;
	public int ammo = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// If ammo is greater than zero and the left mouse button is pressed, create a new projectile
		if (ammo > 0 && Input.GetButtonDown ("Fire1")) {
			GameObject newProjectile = Instantiate (projectile);
			newProjectile.transform.rotation = transform.rotation;
			newProjectile.transform.position = transform.position;
		}
	}
}
