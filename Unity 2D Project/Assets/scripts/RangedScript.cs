using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedScript: MonoBehaviour {

	// Public variables, configure in the inspector
	public float damage = 10.0f;
	public float speed = 1.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * Time.deltaTime * speed);
	}

	// OnCollisionEnter2D is called when the obejct's collider enters another collider
	void OnCollisionEnter2D(Collision2D collision) {
		// If the object's tag is Enemy deal damage to object, then destroy self
		if (collision.gameObject.tag == "Enemy") {
			collision.gameObject.SendMessage ("TakeDamage", damage);
		}
		Destroy (gameObject);
	}
}
