using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Text waveCountdown;

    public float spawnTime = 10.5f;
    private float countDown = 2f;
    private float waveIndex = 0;

    private void Update()
    {
        if (countDown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countDown = spawnTime;
        }

        countDown -= Time.deltaTime;
        waveCountdown.text = Mathf.Round(countDown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            EnemyBehaviour.SpawnEnemy(enemyPrefab, spawnPoint);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
