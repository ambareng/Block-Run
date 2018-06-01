
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerBlockController : MonoBehaviour {

	public float blockSpeed;

	private PauseManager pauseManager;
	private ScoreManager scoreManager;

	void Awake () {
		blockSpeed = 5f;
		pauseManager = FindObjectOfType<PauseManager> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			blockSpeed = 5f + scoreManager.currentScore / 1000;
			transform.Translate (0f, -blockSpeed * Time.deltaTime, 0f);	
		}
	}

}
