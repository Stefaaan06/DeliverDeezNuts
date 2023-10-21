using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Transactions;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Player Menu
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
public class playerMenu : MonoBehaviour
{
    bool GameIsPaused;
    [SerializeField] GameObject menu;
    [SerializeField] GameObject continueButton;
    [SerializeField] GameObject youDied;
    [SerializeField] PlayerController controller;
    [SerializeField] TMP_Text Highscore;
    bool dead = false;

    void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
        GameIsPaused = false;
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        GameIsPaused = true;    
        menu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;

        GameIsPaused = false;
        menu.SetActive(false);
    }

    public void finish()
    {
        GameIsPaused = true;
        menu.SetActive(true);

        continueButton.SetActive(false);
        dead = true;

    }

    public void Die()
    {
        continueButton.SetActive(false);
        youDied.SetActive(true);


        menu.SetActive(true);   

        GameIsPaused = true;    
        Time.timeScale = 0f;   
    }


    void Update()
    {
        if (controller.hp <= 0 && dead == false)
        {
            dead = true;
            Die();
        }
        if (Input.GetKeyDown(KeyCode.Escape))  
        {
            if (GameIsPaused)
            {
                if (!dead)
                {
                    GameIsPaused = false;
                    Resume();
                }
            }
            else
            {
                GameIsPaused = true;
                Pause();
            }
        }
    }

    public void Quit()
    {
        Application.Quit();     
    }

    public void backToMenu()
    {
        SceneManager.LoadScene(0);   
    }


    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  
    }
}
