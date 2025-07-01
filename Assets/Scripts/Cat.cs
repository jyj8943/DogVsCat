using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Cat : MonoBehaviour
{
    public RectTransform front;

    public GameObject hungryCat;
    public GameObject fullCat;

    private float full = 5.0f;
    private float energy = 0.0f;
    
    void Start()
    {
        Application.targetFrameRate = 60;

        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);
    }

    void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * 0.05f;
        }
        else
        {
            if (transform.position.x > 0)
            {
                transform.position += Vector3.right * 0.05f;
            }
            else
            {
                transform.position -= Vector3.left * 0.05f;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Food"))
        {
            if (energy < full)
            {
                energy += 1f;
                front.localScale = new Vector3(energy / full, 1f, 1f);
                Destroy(collision.gameObject);
                if (energy == full)
                {
                    hungryCat.SetActive(false);
                    fullCat.SetActive(true);
                }
            }
        }
    }
}
