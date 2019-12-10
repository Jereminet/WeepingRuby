using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{

    public GameObject character;
    public GameObject[] mobs;
    public GameObject PauseMenuUI;
    public GameObject DeathMenuUI;
    public GameObject NextLevelUI;


    [HideInInspector]
    public AudioManager audioManager;

    [HideInInspector]
    public float minDistance;
    [HideInInspector]
    public float distance;
    [HideInInspector]
    public float maxSound;


    public static bool isGamePaused = false;
    
    private void Awake()
    {
        audioManager = AudioManager.instance;
        audioManager.ChangeVolume("heartbeat", 0);
        //audioManager.Play("heartbeat");
        maxSound = 1;
    }



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused) Resume();
            else Pause();
        }
        //ControlSound();

        if (Time.time == 100)
        {
            audioManager.Play("EvilLaughter");
        }
    }

    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
    }

    void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void ControlSound()
    {
        float tempMin = 100;
        foreach (GameObject enemy in mobs)
        {
            distance = Vector2.Distance(character.transform.position, enemy.transform.position);
            if (distance < tempMin)
            {
                
                tempMin = distance;
            }
        }
        minDistance = tempMin;
        if (minDistance < 2)
        {
            audioManager.ChangeVolume("heartbeat", 1);
            //audioManager.ChangeVolume("heartbeat", maxSound * procentageDistance);
            //float procentageDistance = (12 - minDistance) / 12;
        } 
        else if (minDistance < 4)
        {
            audioManager.ChangeVolume("heartbeat", 0.5f);
        }
        else
        {
            audioManager.ChangeVolume("heartbeat", 0);
        }
    }
        
}
