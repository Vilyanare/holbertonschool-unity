using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	private Vector3 offset = new Vector3(0, 2.5f, -6.25f);
	private float minY = 0f;
	private float maxY = 5f;
	private float currentY;
	private float currentX;

	// Update is called once per frame
	void Update () {
		currentY += Input.GetAxis("Mouse Y");
		currentX += Input.GetAxis("Mouse X");

		currentY = Mathf.Clamp(currentY, minY, maxY);
	}

	void LateUpdate () {
		Quaternion rotation = Quaternion.Euler(currentY * 10, currentX * 10, 0);
		transform.position = player.position + rotation * offset;
		transform.LookAt(player);
	}
}
