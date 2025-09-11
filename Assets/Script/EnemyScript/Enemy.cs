using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public enum EnemyType
{
    pw,
    mw
}

public class Enemy : MonoBehaviour
{
    public float speed = 1f; // 적 속도
    public int damage = 1; // 적 공격력
    public float attackInterval = 1.0f; //공격 딜레이 시간
    private float timer = 0f;
    private bool isColliding = false;
    public EnemyType enemyType;

    


    public GameObject enemyPrefab;

    private Queue<GameObject> myPool;

    private PlayerHealth target;

    public void SetPool(Queue<GameObject> pool)
    {
        myPool = pool;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime); // 속도만큼 이동

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

    /*public void EnemyDied(GameObject enemy)
    {
        Debug.Log("Enemy Died");
        enemy.SetActive(false);
        myPool.Enqueue(enemy);
        
    }
    */

    private void OnTriggerEnter2D(Collider2D collision) // 충돌 시 이벤트 발생
    {
        if (collision.CompareTag("Player")) // 충돌 즉시 아군 데미지 호출, 이후 딜레이마다 데미지 호출
        {
            target = collision.GetComponentInChildren<PlayerHealth>(); //부딫힌 오브젝트의 자식에서 PlayerHealth 요소 갖고 오기

            isColliding = true;           
            speed = 0f;
        }
    }
}
