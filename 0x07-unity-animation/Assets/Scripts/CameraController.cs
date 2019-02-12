using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Transform player;
	private Vector3 offset = new Vector3(0, 2.5f, -6.25f);
	private float minY = 0f, maxY = 5f;
	private float currentY, currentX;
	public bool isInverted;

	void Update () {
		isInverted = PlayerPrefs.GetInt("isInverted") != 0;
		if (isInverted) {
			currentY -= Input.GetAxis("Mouse Y");
			currentX -= Input.GetAxis("Mouse X");
		}
		else {
			currentY += Input.GetAxis("Mouse Y");
			currentX += Input.GetAxis("Mouse X");
		}

		currentY = Mathf.Clamp(currentY, minY, maxY);
	}

	void LateUpdate () {
		Quaternion rotation = Quaternion.Euler(currentY * 10, currentX * 10, 0);
		transform.position = player.position + rotation * offset;
		transform.LookAt(player);
	}
}
