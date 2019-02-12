using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PauseMenu : MonoBehaviour {
	private GameObject player;
	private GameObject mainCamera;
	public GameObject menuBG;
	public Button ResumeButton;
	public Button RestartButton;
	public Button MenuButton;
	public Button OptionsButton;

	void Start () {
		player = GameObject.Find("Player");
		ResumeButton.onClick.AddListener(Resume);
		RestartButton.onClick.AddListener(delegate {MenuSwitch (1); });
		MenuButton.onClick.AddListener(delegate {MenuSwitch (2); });
		OptionsButton.onClick.AddListener(delegate {MenuSwitch (3); });
	}

	public void MenuSwitch (int select) {
		switch (select) {
			case 1:
				Scene scene = SceneManager.GetActiveScene();
				SceneManager.LoadScene(scene.name);
				break;
			case 2:
				SceneManager.LoadScene("MainMenu");
				break;
			case 3:
        		PlayerPrefs.SetString ("previousScene", SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene("Options");
				break;
		}
	}
	public void Pause () {
		player.GetComponent<Timer>().enabled = false;
		player.GetComponent<PlayerController>().enabled = false;
		Camera.main.GetComponent<CameraController>().enabled = false;
		menuBG.SetActive(true);
	}

	public void Resume () {
		menuBG.SetActive(false);
		player.GetComponent<Timer>().enabled = true;
		player.GetComponent<PlayerController>().enabled = true;
		Camera.main.GetComponent<CameraController>().enabled = true;
	}

	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Escape)) {
			if (menuBG.activeSelf == false) {
				Pause();
			}
			else {
				Resume();
			}
		}
	}
}
