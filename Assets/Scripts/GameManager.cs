using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int maxEnemyNum = 20;
    public int minEnemyNum = 10;
    public int maxRespawnInterval = 5;
    public int minRespawnInterval = 3;
    public int firstWave = 1;
    public GameObject enemy;
    private float respawnTimer;
	// Use this for initialization
	void Awake () {
        respawnTimer = firstWave;
    }

    void Update() {
        if (respawnTimer < 0) {
            int respawnInterval = Random.Range(minRespawnInterval, maxRespawnInterval);
            int enemyNum = Random.Range(minEnemyNum, maxEnemyNum);
            for (int i = 0; i < enemyNum; i++) {
                Instantiate(enemy);
            }
            respawnTimer = Random.Range(1, respawnInterval);
        } else {
            respawnTimer -= Time.deltaTime;
        }
    }
}
