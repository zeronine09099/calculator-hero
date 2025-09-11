using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{

    public float  difficultyIncreaseInterval = 1.0f;
    private float timer = 0f;
    public GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= difficultyIncreaseInterval)
        {
            manager.IncreaseDifficultyManager();
            timer = 0f;
        }
    }
}
