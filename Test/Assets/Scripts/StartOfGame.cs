using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOfGame : MonoBehaviour
{
    public GameObject FadeIn;
    public GameObject GameStart;
    public float timer = 2;

    void Start()
    {
        FadeIn.SetActive(true);
    }
    void Update()
    {
        timer -= Time.deltaTime;
        FadeIn.GetComponent<Animation>().Play("FadeIn");
        if( timer < 0)
        {
            GameStart.SetActive(false);
        }
    }
}
