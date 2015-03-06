using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private const float ZERO = 0.0f;

	private Rigidbody rigidBody;
	private bool canJump;
    private bool jumpPeak;

	public float speedScale;
    public float jumpMomentum;
	public Vector3 maxVelocity;
	public KeyCode jumpKey;

	void Start() {
		//Private
		rigidBody = GetComponent<Rigidbody> ();
		canJump = false;
        jumpPeak = false;

		//Public
		speedScale = 10.0f;
        jumpMomentum = 10.0f;
		maxVelocity = new Vector3 (0.5f, 20.0f, 0.5f);
		jumpKey = KeyCode.Space;
	}


	void FixedUpdate () {

		//Gets 'wasd' input
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		float moveJump = ZERO;

		if (canJump && Input.GetKey (jumpKey)) {
            moveJump = jumpMomentum;
			canJump = false;
		}

		Vector3 movement = new Vector3 (ZERO, moveJump, moveVertical);
        Vector3 rotate = new Vector3();

		//Control speed/height
		if (Mathf.Abs(movement.x) > maxVelocity.x) {
			float negative = 1.0f;
            if (movement.x < ZERO) { negative *= -1; }
			movement.x = maxVelocity.x * negative;
		}
		if (Mathf.Abs(movement.z) > maxVelocity.z) {
			float negative = 1.0f;
            if (movement.z < ZERO) { negative *= -1; }
			movement.z = maxVelocity.z * negative;
		}
		if (Mathf.Abs(movement.y) > maxVelocity.y) {
			float negative = 1.0f;
            if (movement.y < ZERO) { negative *= -1; }
			movement.y = maxVelocity.y * negative;
		}


		//Apply movement
		rigidBody.AddForce (movement * speedScale);

//		if (rigidBody.position.y <= .01) {
//			canJump = true;
//		}

        if (rigidBody.velocity.y < ZERO)
        {
            jumpPeak = true;
        }

        if (jumpPeak)
        {
            if (rigidBody.velocity.y >= ZERO)
            {
                canJump = true;
                jumpPeak = false;
            }
        }
		
		Debug.Log ("Movement: " + movement + " Maximum velocity: " + maxVelocity);
	}

//	void OnCollisionEnter(collision : Collision) {
//		if (rigidBody.grounded()) 
//		{
//			canJump = true;
//		}
//	}
}
