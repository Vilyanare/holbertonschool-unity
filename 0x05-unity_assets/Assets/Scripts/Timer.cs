using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text TimerText;
	private float time = 0.00f;

	void Update() {
		time += Time.deltaTime;
		TimerText.text = string.Format("{1:0}:{0:00.00}", time % 60, time / 60);
	}
}
