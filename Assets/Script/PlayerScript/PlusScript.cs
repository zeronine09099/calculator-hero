using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusScript : MonoBehaviour
{
    public RectTransform rect;
    public float speed = 5f;
    public float rotateSpeed = 5f;

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
}
