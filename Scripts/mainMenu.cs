using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    [SerializeField] AudioSource soundOnClip;
    [SerializeField] TMP_Text Highscore;

    private void Start()
    {
        Highscore.text = PlayerPrefs.GetInt("Highscore").ToString();
    }
    public void click()
    {
        soundOnClip.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void loadTutorial()
    {
        SceneManager.LoadScene(1);
    }


    public void loadLevel()
    {
        SceneManager.LoadScene(2);
    }
}
