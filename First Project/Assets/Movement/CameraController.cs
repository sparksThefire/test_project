using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

    private Vector3 offset;

	public GameObject player;
    public float cameraSensitivity;

	// Use this for initialization
	void Start () {
		offset = transform.position;
        cameraSensitivity = 4.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position + offset;

        //float angleIntensity = Input.GetAxis("Horizontal");

        //transform.LookAt(player.transform);
        //transform.Rotate(Vector3.up * angleIntensity * cameraSensitivity, Time.deltaTime);

        //transform.Rotate(player.transform.position, angleIntensity * cameraSensitivity);
	}
}
