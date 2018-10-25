﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PuzzleManager : MonoBehaviour {

	public Text txt;
	public Text timer;
	public static int currentPiecesPerLine = 2;
	public static int score = 0;
	float time = 60.0f;
	
	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		txt.text = "Score: " + score;
		timer.text = "Time: " + System.Math.Round(time, 2);
	}
}