using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private bool canJump = true;
	private Vector3 dir;
	private Rigidbody rb;
	private Timer timer;
	public int speed;
	public int jumpStrength;
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.y < -20) {
			resetPosition();
		}
	}
	void resetPosition () {
		transform.position = new Vector3(0, 20, 0);
		rb.velocity = new Vector3(0, 0, 0);
	}

	void FixedUpdate () {
		canJump = Physics.Raycast(transform.position, transform.up * -1, 1f);

		if (Input.GetKey("w")) {
			dir = Camera.main.transform.forward;
			dir.y = 0;
			transform.Translate(dir * speed * Time.deltaTime);
		}
		if (Input.GetKey("a")) {
			dir = Quaternion.Euler(0, -90, 0) * Camera.main.transform.forward;
			dir.y = 0;
			transform.Translate(dir * speed * Time.deltaTime);
		}
		if (Input.GetKey("s")) {
			dir = Quaternion.Euler(0, 180, 0) * Camera.main.transform.forward;
			dir.y = 0;
			transform.Translate(dir * speed * Time.deltaTime);
		}
		if (Input.GetKey("d")) {
			dir = Quaternion.Euler(0, 90, 0) * Camera.main.transform.forward;
			dir.y = 0;
			transform.Translate(dir * speed * Time.deltaTime);
		}
		if (Input.GetKey(KeyCode.Space) && canJump == true) {
			canJump = false;
			rb.AddForce(new Vector3(0, 1500 * jumpStrength * Time.deltaTime, 0));
		}

	}
}
