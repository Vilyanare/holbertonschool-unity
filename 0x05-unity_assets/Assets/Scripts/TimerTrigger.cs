using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerTrigger : MonoBehaviour {
	private GameObject player;
	void Start () {
		player = GameObject.Find("Player");
	}
	void OnTriggerExit (Collider other) {
		if (other.transform.name == "Player"){
			player.GetComponent<Timer>().enabled = true;
		}
	}
}
