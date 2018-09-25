using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public int maxEnemyNum = 20;
    public int minEnemyNum = 14;
    public int maxRespawnInterval = 5;
    public int minRespawnInterval = 3;
    public int firstWave = 1;
    public GameObject enemy;
    public Text timeTextUI;
    public Text gameOverTextUI;
    public static bool isOver;
    private float timer;
    private float respawnTimer;

	// Use this for initialization
	void Awake () {
        Cursor.visible = false;
        timer = 0.0f;
        respawnTimer = firstWave;
        timeTextUI.text = "Time: 00:00:00";
        isOver = false;
    }

    void Update() {
        if (!isOver) {
            gameOverTextUI.enabled = false;
            if (respawnTimer < 0) {
                int respawnInterval = Random.Range(minRespawnInterval, maxRespawnInterval);
                int enemyNum = Random.Range(minEnemyNum, maxEnemyNum) + Mathf.Max(0, (int) Mathf.Log(2, (int)timer));
                for (int i = 0; i < enemyNum; i++)
                {
                    Instantiate(enemy);
                }
                respawnTimer = Random.Range(1, respawnInterval);
            }
            else {
                respawnTimer -= Time.deltaTime;
            }
            timer += Time.deltaTime;
            timeTextUI.text = "Time: " + FormatTime(timer);
        } else {
            gameOverTextUI.enabled = true;
            if (Input.GetKeyDown(KeyCode.R)) {
                //https://answers.unity.com/questions/1109503/unity-53-restarting-current-scene.html
                Scene loadedLevel = SceneManager.GetActiveScene();
                SceneManager.LoadScene(loadedLevel.buildIndex);
            }
        }
    }

    //https://answers.unity.com/questions/514378/timer-in-milliseconds-to-mmssms.html
    private string FormatTime(float time) {
        int intTime = (int)time;
        int minutes = intTime / 60;
        int seconds = intTime % 60;
        float fraction = time * 100;
        fraction = (fraction % 100);
        string timeText = System.String.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, fraction);
        return timeText;
    }
}
