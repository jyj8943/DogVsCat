using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject food;
    
    void Start()
    {
        InvokeRepeating("MakeFood", 0f, 0.2f);
    }

    private void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x;

        if (x > 8.5f)
        {
            x = 8.5f;
        }
        if (x < -8.5f)
        {
            x = -8.5f;
        }
        
        transform.position = new Vector2(x, transform.position.y);
    }

    private void MakeFood()
    {
        float x = transform.position.x;
        float y = transform.position.y + 2f;
        
        Instantiate(food, new Vector2(x, y), quaternion.identity);
    }
}
