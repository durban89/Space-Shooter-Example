﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimpleTouchAreaButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {
	private bool touched;
	private int pointerID;
	private bool canFire;

	void Awake () {
		touched = false;
	}

	public void OnPointerDown(PointerEventData data) {
		// Set our start point
		if(!touched) {
			touched = true;
			canFire = true;
			pointerID = data.pointerId;
		}

	}

	public void OnPointerUp(PointerEventData data) {
		if (data.pointerId == pointerID) {
			touched = false;
			canFire = false;
		}
	}

	public bool CanFire(){
		return canFire;
	}

}
