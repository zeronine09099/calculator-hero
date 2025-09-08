using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
   
    public int damage = 1;

    public bool isColided = false;

    public GameManager deleteManager;

    // Start is called before the first frame update
    void Start()
    {    

    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Trash"))
        {
            var enemy = collision.GetComponentInChildren<EnemyHealth>();
            
            if (collision.CompareTag("Enemy"))
                {
                    enemy.TakeDamageEnemy(damage);
                }
        
            switch (gameObject.tag)
            {
                case "plus": 
                    deleteManager.PlusDeleteManager(gameObject);
                    break;
                case "minus":
                    deleteManager.MinusDeleteManager(gameObject);
                    break;
            }
        }

    }

    
}
