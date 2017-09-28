using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private bool gameOver;
	private bool gameRestart;
	private int score;

	// Use this for initialization
	void Start () {
		gameOver = false;
		gameRestart = false;
		restartText.text = "";
		gameOverText.text = "";

		score = 0;
		UpdateScore ();

		StartCoroutine (SpawnWaves ());
	}

	void Update(){
		if (gameRestart) {
			if (Input.GetKeyDown(KeyCode.R)) {
				Application.LoadLevel (Application.loadedLevel);
			}
		}
	}

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
				restartText.text = "Press 'R' for Restart.";
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
}
