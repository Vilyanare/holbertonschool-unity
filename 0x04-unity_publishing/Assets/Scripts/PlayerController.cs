using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 2000f;
	public Text winLoseText;
	public Image winLoseBG;
	public GameObject winLoseObject;
	public Text scoreText;
	public Text healthText;
	private Rigidbody rb;
	private int score = 0;
	public int health = 5;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody>();
	}
	void Win () {
		winLoseObject.SetActive(true);
		winLoseBG.color = Color.green;
		winLoseText.color = Color.black;
		winLoseText.text = "You Win!";
	}
	void Lose () {
		winLoseObject.SetActive(true);
		winLoseBG.color = Color.red;
		winLoseText.color = Color.white;
		winLoseText.text = "Game Over!";
	}
	void SetHealthText () {
		healthText.text = (string.Format("Health: {0}", health));
	}
	void SetScoreText () {
		scoreText.text = (string.Format("Score: {0}", score));
	}
	void OnTriggerEnter (Collider other) {
		if (other.tag == "Pickup") {
			score++;
			Destroy(other.gameObject);
			SetScoreText();
			//Debug.Log(string.Format("Score: {0}", score));
		}

		if (other.tag == "Trap") {
			health--;
			SetHealthText();
			//Debug.Log(string.Format("Health: {0}", health));
		}

		if (other.tag == "Goal") {
			Win();
			StartCoroutine(LoadScene(3));
			//Debug.Log("You win!");
		}
	}
	IEnumerator LoadScene (float seconds) {
		yield return new WaitForSeconds(seconds);
		SceneManager.LoadScene("maze");
	}
	void Update () {
		if (health == 0) {
			Lose();
			StartCoroutine(LoadScene(3));
			//Debug.Log("Game Over!");
		}
	}
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey(KeyCode.Escape)) {
			SceneManager.LoadScene("menu");
		}
		if (Input.GetKey("d") || Input.GetKey(KeyCode.RightArrow)) {
			rb.AddForce(speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("a") || Input.GetKey(KeyCode.LeftArrow)) {
			rb.AddForce(-speed * Time.deltaTime, 0, 0);
		}

		if (Input.GetKey("w") || Input.GetKey(KeyCode.UpArrow)) {
			rb.AddForce(0, 0, speed * Time.deltaTime);
		}

		if (Input.GetKey("s") || Input.GetKey(KeyCode.DownArrow)) {
			rb.AddForce(0, 0, -speed * Time.deltaTime);
		}

	}
}
