using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public float createspeed = 1.0f;
    private float timer = 0f;

    public GameObject Plus;
    public int poolCount = 20;
    public static Queue <GameObject> pluses = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolCount; i++) //몹 생성 초기화
        {
            GameObject plus = Instantiate(Plus, transform);
            plus.SetActive(false);
            pluses.Enqueue(plus);

        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= createspeed)
        {
            if (pluses.Count > 0)
            {
                GameObject plus = pluses.Dequeue();
                plus.SetActive(true);
                plus.transform.localPosition = Vector3.zero;
            }

            timer = 0f;
        }
    }
    
    
    public void DeleteWeapon(GameObject plus)
    {
        plus.SetActive(false);
        pluses.Enqueue(plus);
        plus.transform.localPosition = Vector3.zero;
    }
    
}
