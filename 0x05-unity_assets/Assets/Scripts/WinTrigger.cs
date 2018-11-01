using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour {
	private GameObject player;
	private Text timer;
	void Start() {
		player = GameObject.Find("Player");
		timer = GameObject.Find("TimerCanvas").GetComponentInChildren<Text>();
	}
	void OnTriggerEnter (Collider other) {
		if (other.transform.name == "Player") {
			player.GetComponent<Timer>().enabled = false;
			timer.color = Color.green;
			timer.fontSize = 36;
		}
	}
}
