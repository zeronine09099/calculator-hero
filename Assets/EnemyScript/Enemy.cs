using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 1f; // �� �ӵ�
    public int damage = 1; // �� ���ݷ�
    public float attackInterval = 1.0f; //���� ������ �ð�
    private float timer = 0f;
    private bool isColliding = false;

    
    public GameObject enemyPrefab;
   

    private PlayerHealth target;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // �ӵ���ŭ �̵�

        if(isColliding)
        {
            if (timer >= attackInterval || timer == 0)
            {
                target.TakeDamagePlayer(damage);
                timer = 0f;
            }

            timer += Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision) // �浹 �� �̺�Ʈ �߻�
    {
        if (collision.CompareTag("Player")) // �浹 ��� �Ʊ� ������ ȣ��, ���� �����̸��� ������ ȣ��
        {
            target = collision.GetComponentInChildren<PlayerHealth>(); //�΋H�� ������Ʈ�� �ڽĿ��� PlayerHealth ��� ���� ����

            isColliding = true;           
            speed = 0f;
        }
    }
}
