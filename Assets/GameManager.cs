using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    CreateWeapon deleteWeapon;
    EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InitializeManager()
    {
        enemyHealth.InitializeHealth();
    }

    public void DeleteManager()
    {
        Debug.Log("Delete weapon");
        deleteWeapon.DeleteWeapon(gameObject);
    }

    public void GameOver()
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; // 게임 정지
    }
}
