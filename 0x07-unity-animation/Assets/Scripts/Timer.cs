using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
	public Text TimerText;
	public Text FinalTime;
	private float time = 0.00f;

	void Update() {
		time += Time.deltaTime;
		TimerText.text = string.Format("{1:0}:{0:00.00}", time % 60, time / 60);
	}
	public void Win () {
		FinalTime.text = TimerText.text;
		TimerText.enabled = false;
	}
}
