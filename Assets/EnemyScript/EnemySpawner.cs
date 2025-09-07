using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2.0f;
    public float timer = 0f;

    public GameObject enemyPrefab;
    public int poolCount = 20;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();

    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        

        for (int i = 0; i < poolCount; i++) //몹 생성 초기화
        {
            GameObject enemy = Instantiate(enemyPrefab, transform);
            enemy.SetActive(false);
            enemyPool.Enqueue(enemy);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnInterval || timer == 0f)
        {
            if (enemyPool.Count > 0)
            {
                GameObject enemy = enemyPool.Dequeue();
                manager.InitializeManager(enemy);
                enemy.SetActive(true);
                enemy.transform.localPosition = Vector3.zero;
            }

            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    public void EnemyDied(GameObject enemy)
    {
        Debug.Log("Enemy Died");
        enemy.SetActive(false);
        enemyPool.Enqueue(enemy);
        enemy.transform.localPosition = Vector3.zero;
    }
}
