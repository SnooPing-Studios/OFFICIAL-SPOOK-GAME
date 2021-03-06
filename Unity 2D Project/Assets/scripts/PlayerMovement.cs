using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

	// public var, configure in the inspector
	// speed var determines speed of player movement
	public float speed =20.0f;
	//health var determines health of object
	public float health = 100.0f;
	//damage var determines attack damage
	public float damage = 10.0f;
	public Text scoreText;
	public Text HP;
	public string destination;
	public string destination2;
	
	//private vars
	private Rigidbody2D myRigidbody;
	private float score = 0.0f;

    // Use this for initialization
    void Start () {
		//Get the rigidbody2d component and adds it tho the gameobject
		myRigidbody = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//checks if horizontal axis is being used
		if (Input.GetAxis ("Horizontal") != 0.0f) {
			if (Input.GetAxis ("Horizontal") < 0.0f) {
				transform.localRotation = Quaternion.Euler (0,180,0);
			} else {
				transform.localRotation = Quaternion.Euler (0,0,0);
			}
			transform.Translate (new Vector3(x: Time.deltaTime * speed, y: 0.0f));
		}

		//checks if vertical axis is being used
		if(Input.GetAxis("Vertical") != 0.0f) {
			transform.Translate (new Vector3(x: 0.0f, y: Time.deltaTime * speed * Input.GetAxis("Vertical")) );
		}

	
		HP.text = "HP: " + health;

		if (health <= 0.0f) {
			SceneManager.LoadScene (destination2);
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		//checks if the objects tag is enemy
		if (collision.gameObject.tag == "enemy") {
			//sends damage message to player object
			collision.gameObject.SendMessage ("TakeDamage", damage);
		}
	}	

	//ontriggerenter2d is called when the objects collider enters a triger collider
	void OnTriggerEnter2D(Collider2D collider) {

		//checks if the objects tag is coin
		if (collider.gameObject.tag == "coin") {
			Destroy (collider.gameObject);
			//increases score +1
			score++;
			//updates the scoretexts text to reflect the new score var
			scoreText.text = "Number of Items: " + score;
			if (score == 10) {
				SceneManager.LoadScene (destination);
			}
		}


	}

	//ontriggerenter2d is called when the objects collider exits a triger collider
	void OnTriggerExit2D(Collider2D collider) {
		//checks if the objects tag is ladder
		if (collider.gameObject.tag == "water") {
			health= health - 5;
		}
	}

	//takendamage is called when it is triggerd by another object
	public void TakeDamage(float damageTaken) {
		print ("taking damage");
		//subtract damge taken from health
		health -= damageTaken;
		//if health is less than 0 then destroy this object
		if (health <= 0.0f) {
			Destroy (gameObject);
			SceneManager.LoadScene (destination2);
		}

	}

}