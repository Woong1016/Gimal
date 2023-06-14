using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] prefabs;
    public int count = 10;
    public BoxCollider area;
    public Text timerText;
    public GameObject resultScreen;

    private List<GameObject> enemies = new List<GameObject>();
    private bool isTimerRunning;
    private float startTime;

    void Start()
    {
        area.enabled = false;
        SpawnEnemies();
    }

    void Update()
    {
        if (isTimerRunning)
        {
            UpdateTimer();
        }

        if (enemies.Count == 0 && isTimerRunning)
        {
            StopTimer();
            ShowResultScreen();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < count; ++i)
        {
            Spawn();
        }

        StartTimer();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2f);
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);

        return spawnPos;
    }

    private void Spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        enemies.Add(instance);
    }

    private void StartTimer()
    {
        isTimerRunning = true;
        startTime = Time.time;
    }

    private void UpdateTimer()
    {
        float currentTime = Time.time - startTime;
        int minutes = Mathf.FloorToInt(currentTime / 60f);
        int seconds = Mathf.FloorToInt(currentTime % 60f);
        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);
        timerText.text = "Time: " + timerString;
    }

    private void StopTimer()
    {
        isTimerRunning = false;
    }

    private void ShowResultScreen()
    {
        resultScreen.SetActive(true);
        float totalTime = Time.time - startTime;
        int totalMinutes = Mathf.FloorToInt(totalTime / 60f);
        int totalSeconds = Mathf.FloorToInt(totalTime % 60f);
        string totalTimeString = string.Format("{0:00}:{1:00}", totalMinutes, totalSeconds);
        resultScreen.GetComponentInChildren<Text>().text = "Total Time: " + totalTimeString;
    }
}
