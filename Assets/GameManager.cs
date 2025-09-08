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
    

    

    public void PlusDeleteManager(GameObject plus) //���⿡�� ȣ��
    {
        Debug.Log("Delete weapon");
        deleteWeapon.DeleteWeaponPlus(plus);
    }

    public void MinusDeleteManager(GameObject minus) //���⿡�� ȣ��
    {
        Debug.Log("Delete weapon");
        deleteWeapon.DeleteWeaponMinus(minus);
    }

    public void GameOver() //�÷��̾� ü�¿��� ȣ��
    {
        Debug.Log("Game Over!");
        Time.timeScale = 0f; // ���� ����
    }

    public void InitializeManager(GameObject enemy) //�����ʿ��� ȣ��
    { 
        enemyHealth = enemy.GetComponentInChildren<EnemyHealth>();
        enemyHealth.InitializeHealth(); //ü�� �ʱ�ȭ
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
