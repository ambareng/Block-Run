
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerBlockController : MonoBehaviour {

	public float blockSpeed = 5f;
	public float swipeSpeed = 1f;

	private Vector3 desiredPosition;
	private Swipe swipeControls; 
	private Transform player;
	private bool isRight, isLeft, isMid;
	private bool isMoving = true;
	private PauseManager pauseManager;

	void Awake () {
		swipeControls = FindObjectOfType<Swipe> ();
		player = this.transform;
		desiredPosition.Set (0f, -2f, 0f);
		isRight = isLeft = false;
		isMid = true;
		isMoving = true;
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			if (transform.position.y < -2) {
				transform.Translate (0f, blockSpeed * Time.deltaTime, 0f);
				isMoving = true;
			} else {
				isMoving = false;
			}

			if (isMoving == false) {
				if (swipeControls.GetSwipeLeft && (isMid == true || isRight == true)) {
					swipeSpeed = 5f;
					desiredPosition += (Vector3.left * 2.5f);
				}
				if (swipeControls.GetSwipeRight && (isMid == true || isLeft == true)) {
					swipeSpeed = 5f;
					desiredPosition += (Vector3.right * 2.5f);
				}

				player.transform.position = Vector3.MoveTowards (player.transform.position, desiredPosition, 3f * Time.deltaTime * swipeSpeed);
			}
		}
	}
		
	void OnTriggerEnter2D (Collider2D col) {
		isRight = isLeft = isMid = false;

		if (col.name == "Sensor Block") {
			isLeft = true;
		} else if (col.name == "Sensor Block (1)") {
			isMid = true;
		} else if (col.name == "Sensor Block (2)") {
			isRight = true;
		} else if (col.tag == "Blocker Block") {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

}
