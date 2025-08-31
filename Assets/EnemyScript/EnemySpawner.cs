using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnInterval = 2.0f;
    public float timer = 0f;

    public GameObject Enemy;
    public GameObject EnemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth enemyHealth = EnemyHealth.GetComponent<EnemyHealth>();
        enemyHealth.InitializeHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= spawnInterval || timer == 0f)
        {            
            GameObject enemy = Instantiate(Enemy, transform);
            enemy.transform.localPosition = Vector3.zero;
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
