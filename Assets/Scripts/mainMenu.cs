using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Main Menu code
/// @author Stefaaan
/// @version 1.1 -added documentation
/// </summary>
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

    public void openLink(string link)
    {
        Application.OpenURL(link);
    }
}
