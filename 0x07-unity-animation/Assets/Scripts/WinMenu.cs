using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class WinMenu : MonoBehaviour {
	public Button NextButton;
	public Button MenuButton;

	void Start () {
		NextButton.onClick.AddListener(Next);
		MenuButton.onClick.AddListener(MainMenu);
	}
	public void MainMenu () {
		SceneManager.LoadScene("MainMenu");
	}
	public void Next () {
		Scene CurrentLevel = SceneManager.GetActiveScene();
		string level = Regex.Match(CurrentLevel.name, @"\d+").Value;
		SceneManager.LoadScene("Level0" + (Int32.Parse(level) + 1).ToString());
	}
}
