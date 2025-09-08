using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public CreateWeapon deleteWeapon;
    public EnemyHealth enemyHealth;
    public ButtonScript buttonScript;

    
    public EnemySpawner enemySpawner;
    public GameObject enemy;
    public GameObject plus;
    public GameObject minus;
    public CreateWeapon changeWeapon;
    public int number;
    

    

    public void PlusDeleteManager(GameObject plus) //무기에서 호출
    {
        Debug.Log("Delete weapon");
        deleteWeapon.DeleteWeaponPlus(plus);
    }

    public void MinusDeleteManager(GameObject minus) //무기에서 호출
    {
        Debug.Log("Delete weapon");
        deleteWeapon.DeleteWeaponMinus(minus);
    }

    public void GameOver() //플레이어 체력에서 호출
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; // 게임 정지
    }

    public void InitializeManager(GameObject enemy) //스포너에서 호출
    { 
        enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
        enemyHealth.InitializeHealth(); //체력 초기화
    }

    public void EnemyDiedManager(GameObject enemy)
    {
        enemySpawner.EnemyDied(enemy);
    }

    public void ChangeWeaponManager(int number)
    {
        Debug.Log("weapon changed");
        changeWeapon.ChangeWeapon(number);
    }
}
