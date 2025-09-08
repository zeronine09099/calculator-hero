using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DotPrefab; // ü�� �� 
    public int initialHealth = 3;
    public int enemyHealth; // ü��
    public List<GameObject> dots = new List<GameObject>(); //ü�� ����Ʈ

    public RectTransform rect; //ü�¹� ��ġ
    public Vector2 pos;
    private float temp = 0;

    public GameManager manager;

    // Start is called before the first frame update
    void Start() //ü�� UI ����
    {
        
    }

    public void TakeDamageEnemy(int amount)
    {
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
