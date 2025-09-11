using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2.0f;
    public float timer = 0f;
    public float increaseAmount = 0.99f;

    public GameObject Plus_Weak_Enemy;
    public GameObject Minus_Weak_Enemy;
    private List<Queue<GameObject>> EnemyList = new List<Queue<GameObject>>();
    private Queue<GameObject> pwEnemyPool = new Queue<GameObject>();
    private Queue<GameObject> mwEnemyPool = new Queue<GameObject>();
    public int poolCount = 20;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        EnemyList.Add(pwEnemyPool);
        EnemyList.Add(mwEnemyPool);

        for (int i = 0; i < poolCount; i++) //各 积己 檬扁拳
        {
            GameObject enemy = Instantiate(Plus_Weak_Enemy, transform);
            enemy.SetActive(false);
            pwEnemyPool.Enqueue(enemy);
            manager.SetPoolManager(pwEnemyPool);
        }

        for (int i = 0; i < poolCount; i++) //各 积己 檬扁拳
        {
            GameObject enemy = Instantiate(Minus_Weak_Enemy, transform);
            enemy.SetActive(false);
            mwEnemyPool.Enqueue(enemy);
            manager.SetPoolManager(mwEnemyPool);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnInterval || timer == 0f)
        {
            int rNum = Random.Range(0, 2);
            Debug.Log(EnemyList[rNum].Count);
            if (EnemyList[rNum].Count > 0)
            {
                GameObject enemy = EnemyList[rNum].Dequeue();
                manager.InitializeManager(enemy);
                enemy.SetActive(true);
                Debug.Log("Spawn Enemy");
                enemy.transform.localPosition = Vector3.zero;
            }

            timer = 0f;
        }

        timer += Time.deltaTime;
    }

    public void EnemyDied(GameObject enemy)
    { 
        Enemy enemyScript = enemy.GetComponent<Enemy>();
        Debug.Log("Enemy Died");
        enemy.SetActive(false);
        switch (enemyScript.enemyType)
        {
            case EnemyType.pw:
                pwEnemyPool.Enqueue(enemy);
                break;
            case EnemyType.mw:
                mwEnemyPool.Enqueue(enemy);
                break;
        }
        enemy.transform.localPosition = Vector3.zero;
    }

    public void IncreaseDifficulty()
    {
        spawnInterval *= increaseAmount;
    }
}
