using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyMovement : MonoBehaviour {

	// Public variables, configure in the inspector
	// Speed variable, determines speed of player movement
	public float speed = 1.0f;
	// Jump variable, determines height of player jump
	public float jumpHeight = 200.0f;
	//health var determines health of object
	public float health = 100.0f;
	//damage var determines attack damage
	public float damage = 5.0f;

	// Private variables, local use only
	// Rigidbody variable, holds the object's rigidbody component
	private Rigidbody2D myRigidbody;
	// Player variable, holds the player's object
	private GameObject player;

	// Use this for initialization
	// Start is called at the beginning of the scene
	void Start () {
		// Gets the Rigidbody2D component attached to the gameObject
		myRigidbody = gameObject.GetComponent<Rigidbody2D> ();
		// Gets the player's object from the game manager
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		// Checks if the object's position is the same as the player's
		if (transform.position != player.transform.position) {
			// Checks if the player is above the object and the object is groudned
			if (player.transform.position.y > transform.position.y) {
				// Applies a y-axis force to the object based on jumpHeight
				myRigidbody.AddForce (new Vector2 (0.0f, jumpHeight));
			}
			transform.Translate (new Vector3((player.transform.position.x - transform.position.x) * speed * Time.deltaTime, 0.0f, 0.0f));
		}
	}

	// OnCollisionEnter2D is called when the obejct's collider enters another collider
	void OnCollisionEnter2D (Collision2D collision) {
		//checks if the objects tag is player
		if (collision.gameObject.tag == "Player") {
			//sends damage message to player object
			collision.gameObject.SendMessage ("TakeDamage", damage);
		}
	}

	// OnTriggerEnter2D is called when the object's collider enters a trigger collider
	void OnTriggerEnter2D(Collider2D collider) {

	}

	// OnTriggerExit2D is called when the object's collider exits a trigger collider
	void OnTriggerExit2D(Collider2D collider) {

	}

	//takendamage is calld when it is triggerd by another object
	public void TakeDamage(float damageTaken) {
		//subtract damge taken from health
		health -= damageTaken;
		//if health is less than 0 then destroy this object
		if (health <= 0.0f) {
			Destroy (gameObject);
		}
			
	}



}

