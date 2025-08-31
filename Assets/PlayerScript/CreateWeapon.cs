using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CreateWeapon : MonoBehaviour
{
    public float createspeed = 1.0f;
    private float timer = 0f;

    public GameObject Plus;
    public static Queue <GameObject> pluses = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= createspeed)
        {
            GameObject plus = Instantiate(Plus, transform.position, Quaternion.identity);
            plus.transform.SetParent(transform);
            plus.transform.localPosition = Vector3.zero;

            var weaponScript = plus.GetComponent<Weapon>();
            weaponScript.manager = this;

            pluses.Enqueue(plus);

            timer = 0f;
        }
    }
    
    
    public void DeleteWeapon(GameObject plus)
    {
        GameObject firstWeapon = pluses.Dequeue();
        Destroy(firstWeapon);
    }
    
}
