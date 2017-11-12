using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public GameObject restartButton;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	public Text scoreText;
//	public Text restartText;
	public Text gameOverText;

	private bool gameOver;
	private bool gameRestart;
	private int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		gameRestart = false;
		restartButton.SetActive (false);
//		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();

		StartCoroutine (SpawnWaves ());
	}

//	void Update(){
//		if (gameRestart) {
//			if (Input.GetKeyDown(KeyCode.R)) {
//				Application.LoadLevel (Application.loadedLevel);
//			}
//		}
//	}

	void UpdateScore() {
		scoreText.text = "Score: " + score;
	}

	IEnumerator SpawnWaves (){

		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {

				GameObject hazard = hazards [Random.Range (0, hazards.Length)];

				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return  new WaitForSeconds (waveWait);

			if (gameOver) {
				restartButton.SetActive (true);
//				restartText.text = "Press 'R' for Restart.";
				gameRestart = true;
				break;
			}
		}
	}

	public void AddScore(int newScoreValue) {
		score += newScoreValue;
		UpdateScore ();
	}

	public void GameOver() {
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	public void RestartGame(){
		Application.LoadLevel (Application.loadedLevel);
	}
}
