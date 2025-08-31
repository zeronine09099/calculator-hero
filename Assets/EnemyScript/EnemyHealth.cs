using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject DotPrefab; // ü�� �� 
    public int enemyHealth = 3; // ü��
    public List<GameObject> dots = new List<GameObject>(); //ü�� ����Ʈ

    public RectTransform rect; //ü�¹� ��ġ
    public Vector2 pos;

    // Start is called before the first frame update
    void Start() //ü�� UI ����
    {
       
    }

    public void TakeDamageEnemy(int amount)
    {
        Debug.Log("Enemy health decreased");
        enemyHealth -= amount;

        for (int i = 0; i < amount; i++)
        {
            if(dots.Count <= 0)
            {
                break;
            }
            int lastIndex = dots.Count - 1;
            Destroy(dots[lastIndex]);
            dots.RemoveAt(lastIndex);
            pos.x += 7.5f;
            rect.anchoredPosition = pos;
        }

        if (enemyHealth <= 0)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    public void InitializeHealth()
    {
        rect = GetComponent<RectTransform>();

        pos = rect.anchoredPosition;
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
