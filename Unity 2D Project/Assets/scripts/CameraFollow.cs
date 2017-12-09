using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	// Public variables, configure in inspector
	public bool followX = true;
	public bool followY = true;
	public bool followZ = true;
	public float dampTime = 0.15f;
	public float deadZone = 0.1f;
	public Transform target;
	public float offset = 0.0f;

	// Private variables, local use only
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (target)
		{
			// Calculate movment vectors
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(target.position);
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			destination.y = destination.y + offset;

			// Follow only in specified axes
			if (!followX) {
				destination.x = transform.position.x;
			}
			if (!followY) {
				destination.y = transform.position.y;
			}
			if (!followZ) {
				destination.z = transform.position.z;
			}

			// Follow only if target is outside of the dead-zone
			if (target.position.y < transform.position.y + deadZone && target.position.y > transform.position.y - deadZone) {
				destination.y = transform.position.y;
			} else {
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			}
			if (target.position.x < transform.position.x + deadZone && target.position.x > transform.position.x - deadZone) {
				destination.x = transform.position.x;
			} else {
				transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
			}
		}
	}
}
