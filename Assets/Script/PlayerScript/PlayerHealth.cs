using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject DotPrefab;
    public static int playerHealth = 3;
    public static List<GameObject> dots = new List<GameObject>();

    public static RectTransform rect;
    public static Vector2 pos;

    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        pos = rect.anchoredPosition;

        pos.x += 7.5f;
        rect.anchoredPosition = pos;

        for (int i = 0; i < playerHealth; i++)
        {
            GameObject dot = Instantiate(DotPrefab, transform);
            dots.Add(dot);
            pos.x -= 7.5f;
            rect.anchoredPosition = pos;
        }
    }
    public void TakeDamagePlayer(int amount)
    {
        Debug.Log("Health decreased");
        playerHealth -= amount;
        int lastIndex; 

        for (int i = 0; i < amount; i++) 
        {
            lastIndex = dots.Count - 1;
            Destroy(dots[lastIndex]);
            dots.RemoveAt(lastIndex);
            pos.x += 7.5f;
            rect.anchoredPosition = pos;
            if (lastIndex <= 0)
            {
                gameManager.GameOver();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
