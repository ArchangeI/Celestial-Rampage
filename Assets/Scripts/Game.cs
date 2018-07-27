using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement; 

public class Game : MonoBehaviour {

	private static Game singleton;
	[SerializeField]	
	RobotSpawn[] spawns;
	public int enemiesLeft;
	public GameObject gameOverPanel;
	public GameUI gameUI;
	public GameObject player;
	public int score;
	public int waveCountdown;
	public bool isGameOver;

	// 1
	void Start() {
	  singleton = this;
		StartCoroutine("increaseScoreEachSecond");
		isGameOver = false;
		Time.timeScale = 1;
		waveCountdown = 30;
		enemiesLeft = 0;
		StartCoroutine("updateWaveTimer");
	  SpawnRobots();
	}

	// 2
	private void SpawnRobots() {
	  foreach (RobotSpawn spawn in spawns) {
	    spawn.SpawnRobot();
	    enemiesLeft++;
	  }
		gameUI.SetEnemyText(enemiesLeft);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator updateWaveTimer() {
	  while (!isGameOver) {
	    yield return new WaitForSeconds(1f);
	    waveCountdown--;
	    gameUI.SetWaveText(waveCountdown);

	    // Spawn next wave and restart count down
	    if (waveCountdown == 0) {
	      SpawnRobots();
	      waveCountdown = 30;
	      gameUI.ShowNewWaveText();
	    }
	  }
	}

	IEnumerator increaseScoreEachSecond() {
	  while (!isGameOver) {
	    yield return new WaitForSeconds(1);
	    score += 1;
	    gameUI.SetScoreText(score);
	  }
	}

	public void AddRobotKillToScore() {
	  score += 10;
	  gameUI.SetScoreText(score);
	}

	public static void RemoveEnemy() {
	  singleton.enemiesLeft--;
	  singleton.gameUI.SetEnemyText(singleton.enemiesLeft);

	  // Give player bonus for clearing the wave before timer is done
	  if (singleton.enemiesLeft == 0) {
	    singleton.score += 50;
	    singleton.gameUI.ShowWaveClearBonus();
	  }
	}

	// 1
	public void OnGUI() {
	  if (isGameOver && Cursor.visible == false) {
	    Cursor.visible = true;
	    Cursor.lockState = CursorLockMode.None;
	  }
	}

	// 2
	public void GameOver() {
	  isGameOver = true;
	  Time.timeScale = 0;
	  player.GetComponent<FirstPersonController>().enabled = false;
	  player.GetComponent<CharacterController>().enabled = false;
	  gameOverPanel.SetActive(true);
	}

	// 3
	public void RestartGame() {
	  SceneManager.LoadScene(Constants.SceneBattle);
	  gameOverPanel.SetActive(true);
	}

	// 4
	public void Exit() {
	  Application.Quit();
	}

	// 5
	public void MainMenu() {
	  SceneManager.LoadScene(Constants.SceneMenu);
	}

}
