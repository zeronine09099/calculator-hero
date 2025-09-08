using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public float createspeed = 1.0f;
    private float timer = 0f;

    public GameObject Plus;
    public GameObject Minus;
    public int poolCount = 20;

    private const int PLUS = 0;
    private const int MINUS = 1;
    private int weaponInfo = 0;

    List<GameObject> weaponLists = new List<GameObject>();
    List<Queue<GameObject>> weaponQueues = new List<Queue<GameObject>>();
    List<GameObject>weapons = new List<GameObject>();

    public static Queue <GameObject> pluses = new Queue<GameObject>();
    public static Queue<GameObject> minuses = new Queue<GameObject>();

    

    // Start is called before the first frame update
    void Start()
    {
        weaponLists.Add(Plus);
        weaponLists.Add(Minus);

        weaponQueues.Add(pluses);
        weaponQueues.Add(minuses);

        //GameObject plus;
        //GameObject minus;
        //weapons.Add(plus);
        //weapons.Add(minus);

        for (int j = 0; j < weaponLists.Count; j++)
        {
            for (int i = 0; i < poolCount; i++) //몹 생성 초기화
            {
                weapons[i] = Instantiate(weaponLists[i], transform);
                weapons[i].SetActive(false);
                pluses.Enqueue(weapons[i]);

            }

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

    public void ChangeWeapon(int number)
    {

    }
    
}
