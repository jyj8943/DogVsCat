using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public GameObject normalCat;
    public GameObject retryBtn;
    public GameObject fatCat;
    public GameObject pirateCat;

    public Text levelTxt;
    public RectTransform levelFront;

    private int level = 0;
    private int score = 0;

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
        
        // lv.1 20%의 확률로 고양이를 더 생성
        if (level == 1)
        {
            int p = Random.Range(0, 10);
            if (p < 2) Instantiate(normalCat);
        }
        // lv.2 50%의 확률로 고양이를 더 생성
        else if (level == 2)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(normalCat);
        }
        // lv.3 뚱뚱한 고양이를 생성
        else if (level == 3)
        {
            Instantiate(fatCat);
        }
        else if (level == 4)
        {
            int p = Random.Range(0, 10);
            if (p < 5) Instantiate(pirateCat);
            Instantiate(fatCat);
            Instantiate(normalCat);
        }
    }

    public void GameOver()
    {
        retryBtn.SetActive(true);
        Time.timeScale = 0f;
    }

    public void AddScore()
    {
        score++;
        level = score / 5;
        levelTxt.text = level.ToString();
        levelFront.localScale = new Vector3((score - level * 5) / 5f, 1f, 1f);
    }
}
