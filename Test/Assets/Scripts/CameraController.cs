using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{

    public int points = 1;

    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;

    public Button Right;
    public Button Left;

    public AudioSource ButtonClick;

    public GameObject HallFix;
    public GameObject LivingRoomFix;
    public GameObject BedroomFix;
    public GameObject BathroomFix;

    public GameObject PlayerRoomText;

    void Start()
    {
        Cam1.SetActive(true);
        Cam2.SetActive(false);
        Cam3.SetActive(false);
        Cam4.SetActive(false);

        LivingRoomFix.SetActive(true);
        HallFix.SetActive(false);
        BedroomFix.SetActive(false);
        BathroomFix.SetActive(false);
        PlayerRoomText.GetComponent<Text>().text = "Living Room";
    }

    public void RightClick()
    {
        points++;
        ButtonClick.Play();
    }
    public void LeftClick()
    {
        points--;
        ButtonClick.Play();
    }

    void Update()
    {
        if (points == 5)
        {
            points--;
            points--;
            points--;
            points--;
        }
        if (points == 0)
        {
            points++;
            points++;
            points++;
            points++;
        }

        if (points == 1)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(false);

            LivingRoomFix.SetActive(true);
            HallFix.SetActive(false);
            BedroomFix.SetActive(false);
            BathroomFix.SetActive(false);
            PlayerRoomText.GetComponent<Text>().text = "Living Room";
        }
        if (points == 2)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
            Cam4.SetActive(false);

            LivingRoomFix.SetActive(false);
            HallFix.SetActive(true);
            BedroomFix.SetActive(false);
            BathroomFix.SetActive(false);
            PlayerRoomText.GetComponent<Text>().text = "Hall";
        }
        if (points == 3)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
            Cam4.SetActive(false);

            LivingRoomFix.SetActive(false);
            HallFix.SetActive(false);
            BedroomFix.SetActive(true);
            BathroomFix.SetActive(false);
            PlayerRoomText.GetComponent<Text>().text = "Bedroom";
        }
        if (points == 4)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Cam4.SetActive(true);

            LivingRoomFix.SetActive(false);
            HallFix.SetActive(false);
            BedroomFix.SetActive(false);
            BathroomFix.SetActive(true);
            PlayerRoomText.GetComponent<Text>().text = "Bathroom";
        }
    }
}
