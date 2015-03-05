using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Rigidbody rigidBody;
	private bool canJump;

	public float speedScale;
	public Vector3 maxVelocity;
	public KeyCode jumpKey;

	void Start() {
		//Private
		rigidBody = GetComponent<Rigidbody> ();
		canJump = false;

		//Public
		speedScale = 10.0f;
		maxVelocity = new Vector3 (0.5f, 0.75f, 0.5f);
		jumpKey = KeyCode.Space;
	}


	void FixedUpdate () {

		//Gets 'wasd' input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveJump = 0.0f;

		if (canJump && Input.GetKey (jumpKey)) {
			moveJump = 10.0f;
			canJump = false;
		}

		Vector3 movement = new Vector3 (moveHorizontal, moveJump, moveVertical);

		//Control speed/height
		if (Mathf.Abs(movement.x) > maxVelocity.x) {
			float negative = 1.0f;
			if (movement.x < 0.0f) { negative *= -1; }
			movement.x = maxVelocity.x * negative;
		}
		if (Mathf.Abs(movement.z) > maxVelocity.z) {
			float negative = 1.0f;
			if (movement.z < 0.0f) { negative *= -1; }
			movement.z = maxVelocity.z * negative;
		}
		if (Mathf.Abs(movement.y) > maxVelocity.y) {
			float negative = 1.0f;
			if (movement.y < 0.0f) { negative *= -1; }
			movement.y = maxVelocity.y * negative;
		}

		//Apply movement
		rigidBody.AddForce (movement * speedScale);

		if (rigidBody.position.y <= .01) {
			canJump = true;
		}
		
		Debug.Log ("Movement: " + movement + " Maximum velocity: " + maxVelocity);
	}
}
