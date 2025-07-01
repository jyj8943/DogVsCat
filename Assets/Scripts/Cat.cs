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
    private float speed = 0.05f;

    public int type;
    
    private bool isFull = false;
    
    void Start()
    {
        float x = Random.Range(-9.0f, 9.0f);
        float y = 30.0f;
        transform.position = new Vector2(x, y);

        if (type == 1)
        {
            speed = 0.05f;
            full = 5f;
        }
        else if (type == 2)
        {
            speed = 0.02f;
            full = 10f;
        }
        else if (type == 3)
        {
            speed = 0.1f;
        }
    }

    void Update()
    {
        if (energy < full)
        {
            transform.position += Vector3.down * speed;

            if (transform.position.y < -16f)
            {
                GameManager.instance.GameOver();
            }
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
                    if (!isFull)
                    {
                        isFull = true;
                        hungryCat.SetActive(false);
                        fullCat.SetActive(true);
                        Destroy(gameObject, 3f);
                        GameManager.instance.AddScore();
                    }
                }
            }
        }
    }
}
