using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public float createspeed = 1.0f;
    private float timer = 0f;
    public float increaseAmount = 0.99f;

    public GameObject Plus;
    public GameObject Minus;
    public int poolCount = 20;

    private int weaponNumber = 0;

    List<GameObject> weaponLists = new List<GameObject>();  

    List<Queue<GameObject>> weaponQueues = new List<Queue<GameObject>>();
    public static Queue <GameObject> pluses = new Queue<GameObject>();
    public static Queue <GameObject> minuses = new Queue<GameObject>();

    

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
                GameObject weapon = Instantiate(weaponLists[j], transform);
                weapon.SetActive(false);
                weaponQueues[j].Enqueue(weapon);

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
                GameObject weapon = weaponQueues[weaponNumber].Dequeue();
                weapon.SetActive(true);
                weapon.transform.localPosition = Vector3.zero;
            }

            timer = 0f;
        }
    }
    
    
    public void DeleteWeaponPlus(GameObject plus)
    {
        plus.SetActive(false);
        pluses.Enqueue(plus);
        plus.transform.localPosition = Vector3.zero;
    }

    public void DeleteWeaponMinus(GameObject minus)
    {
        minus.SetActive(false);
        minuses.Enqueue(minus);
        minus.transform.localPosition = Vector3.zero;
    }


    public void ChangeWeapon(int number)
    { 
        weaponNumber = number;
        Debug.Log(weaponNumber);
    }

    public void IncreaseDifficulty()
    {
        createspeed *= increaseAmount;
    }


}
