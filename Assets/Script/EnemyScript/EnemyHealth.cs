using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DotPrefab; // 체력 점 
    public int initialHealth = 3;
    public int enemyHealth; // 체력
    public List<GameObject> dots = new List<GameObject>(); //체력 리스트

    public RectTransform rect; //체력바 위치
    public Vector2 pos;
    private float temp = 0;

    public int hitByPlus = 1; //플러스에 맞았을 때 변화하는 수치
    public int hitByMinus = 1; //마이너스에 맞았을 때 변화하는 수치

    public GameManager manager;

    // Start is called before the first frame update
    void Start() //체력 UI 적용
    {
        
    }

    public void TakeDamageEnemy(int amount,string tag)
    {
        switch (tag) {     
            case "plus":
                amount *= hitByPlus;
                break;
            case "minus":
                amount *= hitByMinus;
                break;
        }
        Debug.Log("Enemy health decreased");
        int repeat;
        int temp = enemyHealth;
        enemyHealth -= amount;
        if (amount > dots.Count)
        {
            repeat = dots.Count;
        }
        else
        {
            repeat = amount;
        }

        /* for (int i = 0; i < amount; i++)
         {
             if(dots.Count <= 0)
             {
                 for(int j = 0; j <= temp; j++)
                 {
                     pos.x -= 7.5f;
                 }
                 rect.anchoredPosition = pos;
                 break;
             }
            */
        for (int i = 0; i < repeat; i++)
        {
            int lastIndex = dots.Count - 1;
            Destroy(dots[lastIndex]);
            dots.RemoveAt(lastIndex);
            pos.x += 7.5f;
            rect.anchoredPosition = pos;
        }
        

        if (enemyHealth <= 0)
        {
            for(int i = 0; i < 1; i++)
            {
                pos.x -= 7.5f;
                rect.anchoredPosition = pos;
            }
            manager.EnemyDiedManager(transform.parent.gameObject);
        }
    }

    public void InitializeHealth()
    {
        enemyHealth = initialHealth;
        rect = GetComponent<RectTransform>();

        pos = rect.anchoredPosition;
        temp = pos.x;
        pos.x += 7.5f;
        rect.anchoredPosition = pos;

        for (int i = 0; i < enemyHealth; i++)
        {
            GameObject dot = Instantiate(DotPrefab, transform);
            dots.Add(dot);
            pos.x -= 7.5f;
            rect.anchoredPosition = pos;
        }
        
        
    }
    

}
