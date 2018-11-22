using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class OptionsMenu : MonoBehaviour {
	public Button ApplyButton;
	public Button BackButton;
	public Toggle InvertY;
	public int isInverted;
	private string previousScene;
	void Start () {
		previousScene = PlayerPrefs.GetString("previousScene");
		if (PlayerPrefs.GetInt("isInverted", 0) != 0) {
			InvertY.isOn = true;
		}
		ApplyButton.onClick.AddListener(delegate {Options(1); });
		BackButton.onClick.AddListener(delegate {Options(2); });
		InvertY.onValueChanged.AddListener(delegate {InvertAxis (InvertY); });
	}

	public void InvertAxis (Toggle change) {
		if (change.isOn) {
			isInverted = 1;
		}
		else {
			isInverted = 0;
		}
	}

	public void Options (int save) {
		switch (save) {
			case 1:
				PlayerPrefs.SetInt("isInverted", isInverted);
				SceneManager.LoadScene(previousScene);
				break;
			case 2:
				SceneManager.LoadScene(previousScene);
				break;
		}
	}
}
