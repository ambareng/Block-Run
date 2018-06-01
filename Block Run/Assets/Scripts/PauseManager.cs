
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour {

	public bool gameStart;
	public Text start;

	void Awake () {
		gameStart = false;
		start.enabled = true;
	}

	void Update () {
		if (Input.GetMouseButtonDown (0) && gameStart == false) {
			gameStart = true;
			start.enabled = false;
		}
	}

	public void Pause () {
		start.enabled = true;
		gameStart = false;
	}

}
