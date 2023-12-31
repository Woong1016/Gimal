using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject[] prefabs; // 찍어낼 게임 오브젝트를 넣어요
                                 // 배열로 만든 이유는 게임 오브젝트를
                                 // 다양하게 찍어내기 위해서입니다
    private BoxCollider area;    // 박스콜라이더의 사이즈를 가져오기 위함
    public int count = 10;       // 찍어낼 게임 오브젝트 갯수

    private List<GameObject> ENEMY = new List<GameObject>();

    void Start()
    {
        area = GetComponent<BoxCollider>();

        Invoke("SpawnEnemies", 4f); // 4초 뒤에 SpawnEnemies 함수 호출

        area.enabled = false;
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < count; ++i)// count 수 만큼 생성한다
        {
            Spawn();// 생성 + 스폰위치를 포함하는 함수
        }
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

        Vector3 spawnPos = GetRandomPosition();// 랜덤위치함수

        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        ENEMY.Add(instance);
    }
}
