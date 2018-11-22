using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Button level1;
	public Button level2;
	public Button level3;
	public Button OptionsButton;
	public Button ExitButton;
	void Start () {
		level1.onClick.AddListener(delegate {LevelSelect(1); });
		level2.onClick.AddListener(delegate {LevelSelect(2); });
		level3.onClick.AddListener(delegate {LevelSelect(3); });
		OptionsButton.onClick.AddListener(delegate {LevelSelect(4); });
		ExitButton.onClick.AddListener(delegate {LevelSelect(5); });
	}
	public void LevelSelect(int level) {
		switch (level) {
			case 1:
				SceneManager.LoadScene("Level01");
				break;
			case 2:
				SceneManager.LoadScene("Level02");
				break;
			case 3:
				SceneManager.LoadScene("Level03");
				break;
			case 4:
        		PlayerPrefs.SetString ("previousScene", SceneManager.GetActiveScene ().name);
				SceneManager.LoadScene("Options");
				break;
			case 5:
					Debug.Log("Quit Game");
					Application.Quit();
				break;

		}
	}
}
