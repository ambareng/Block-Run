
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {


	private float hiScore;
	private PauseManager pauseManager;

	public float currentScore;
	public Text currentScoreText;
	public Text hiScoreText;

	void Awake () {
		currentScore = 0f;
		hiScore = PlayerPrefs.GetFloat ("Hi-Score", 0f);
		hiScoreText.text = "Hi-Score: " + Mathf.Round(hiScore).ToString ();
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			currentScore += 1f;
		}

		currentScoreText.text = "Score: " + Mathf.Round(currentScore).ToString ();

		if (currentScore > hiScore) {
			hiScore = currentScore;
			hiScoreText.text = "Hi-Score: " + Mathf.Round(hiScore).ToString ();
			PlayerPrefs.SetFloat ("Hi-Score", hiScore);
		}
	}

}
