using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public RectTransform rect;
    public float speed = 5f;
    public float rotateSpeed = 5f;
    public int damage = 1;

    public bool isColided = false;

    public CreateWeapon manager;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            var enemy = collision.GetComponentInChildren<EnemyHealth>();
                        
            enemy.TakeDamageEnemy(damage);

            manager.DeleteWeapon(gameObject);

        }
    }
}
