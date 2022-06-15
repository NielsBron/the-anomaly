using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
public static bool GameIsPaused = false;

public GameObject PauseMenuUI;
public GameObject PostFX;
public Slider slider;
public Light livingRoom1;
public Light livingRoom2;
public Light hall1;
public Light hall2;
public Light hall3;
public Light bedroom1;
public Light bedroom2;
public Light bathroom1;

    void Start()
    {
    slider.value = 5;
    }
    
    void Update()
    {
        livingRoom1.intensity = slider.value;
        livingRoom2.intensity = slider.value;
        hall1.intensity = slider.value;
        hall2.intensity = slider.value;
        hall3.intensity = slider.value;
        bedroom1.intensity = slider.value;
        bedroom2.intensity = slider.value;
        bathroom1.intensity = slider.value;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } 
            else
            {
                Pause();
            }
        }
    }

    void Resume ()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause ()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;    
    }
    public void ReturnFunction()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void MenuFunction()
    {
        Debug.Log("Menu");
        SceneManager.LoadScene(0); 
    }
    public void QuitFunction()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
