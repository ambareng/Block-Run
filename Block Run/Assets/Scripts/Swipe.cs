
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour {

	private bool swipeRight, swipeLeft, tap, swipeUp, swipeDown;
	private bool isDragging = false;
	private Vector2 startTouch, swipeDelta;

	public Vector2 GetSwipeDelta { get { return swipeDelta; } }
	public bool GetSwipeRight { get { return swipeRight; } }
	public bool GetSwipeLeft { get { return swipeLeft; } }
	public bool GetSwipeUp { get { return swipeUp; } }
	public bool GetSwipeDown { get { return swipeDown; } }

	private void Update () {
		swipeRight = swipeLeft = tap = swipeUp = swipeDown = false;

		#region Standalone Inputs
		if (Input.GetMouseButtonDown (0)) {
			isDragging = true;
			startTouch = Input.mousePosition;
		} else if (Input.GetMouseButtonUp (0)) {
			isDragging = false;
			Reset ();	
		}
		#endregion

	    #region Mobile Inputs
		if (Input.touches.Length > 0) {
			if (Input.touches [0].phase == TouchPhase.Began) {
				isDragging = true;
				tap = true;
				startTouch = Input.touches [0].position;
			} else if (Input.touches [0].phase == TouchPhase.Ended || Input.touches [0].phase == TouchPhase.Canceled) {
				isDragging = false;
				Reset ();
			}
		}
		#endregion

		swipeDelta = Vector2.zero;
		if (isDragging) {
			if (Input.touches.Length > 0) {
				swipeDelta = Input.touches [0].position - startTouch;
			} else if (Input.GetMouseButton (0)) {
				swipeDelta = (Vector2)Input.mousePosition - startTouch;
			}
		}

		if (swipeDelta.magnitude > 125) {
			float x = swipeDelta.x;

			if (x < 0) {
				swipeLeft = true;
			} else {
				swipeRight = true;
			}

			Reset ();
		}
	}

	private void Reset () {
		startTouch = swipeDelta = Vector2.zero;
		isDragging = false;
	}

}
