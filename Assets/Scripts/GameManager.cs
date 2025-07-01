using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject normalCat;
    public GameObject retryBtn;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
        Application.targetFrameRate = 60;
        Time.timeScale = 1.0f;
    }

    void Start()
    {
        InvokeRepeating("MakeCat",0f, 1f);
    }
    
    void Update()
    {
        
    }

    private void MakeCat()
    {
        Instantiate(normalCat);
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }
}
