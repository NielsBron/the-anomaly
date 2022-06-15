using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
public GameObject CreditsObj;
public GameObject MainMenuObj;
public GameObject NielsBron;
public GameObject CreditsAnim;

void Start()
{
    Time.timeScale = 1f;
}
public void Play()
{
    SceneManager.LoadScene(1);
}
public void Credits()
{
    MainMenuObj.SetActive(false);
    CreditsObj.SetActive(true);
    NielsBron.GetComponent<Animation>().Play("TextFadeIn");
    CreditsAnim.GetComponent<Animation>().Play("TextDown");

}

public void CreditsBack()
{
    MainMenuObj.SetActive(true);
    CreditsObj.SetActive(false);
    NielsBron.GetComponent<Animation>().Stop("TextFadeIn");
    CreditsAnim.GetComponent<Animation>().Stop("TextDown");
}
public void Quit()
{
    Application.Quit();
    Debug.Log("Quit");
}

}
