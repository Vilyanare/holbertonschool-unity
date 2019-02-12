using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {
	private GameObject player;
	private Text timer;
	public GameObject WinCanvas;
	public GameObject TimerCanvas;
	void Start() {
		player = GameObject.Find("Player");
		timer = TimerCanvas.GetComponentInChildren<Text>();
	}
	void OnTriggerEnter (Collider other) {
		if (other.transform.name == "Player") {
			player.GetComponent<Timer>().Win();
			player.GetComponent<Timer>().enabled = false;
			timer.color = Color.green;
			timer.fontSize = 36;
			WinCanvas.SetActive(true);
		}
	}
}
