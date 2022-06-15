using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public GameObject HallCam;
    public GameObject BedroomCam;
    public GameObject BathroomCam;
    public GameObject LivingRoomCam;
    public AudioSource ButtonClick;

    public GameObject HallFix;
    public GameObject LivingRoomFix;
    public GameObject BedroomFix;
    public GameObject BathroomFix;
    // Update is called once per frame
    void Start()
    {
        LivingRoomCam.SetActive(false);
        HallCam.SetActive(true);
        BedroomCam.SetActive(false);
        BathroomCam.SetActive(false);

        HallFix.SetActive(true);
        LivingRoomFix.SetActive(false);
        BedroomFix.SetActive(false);
        BathroomFix.SetActive(false);
    }

    public void LivingRoomButton()
    {
        LivingRoomCam.SetActive(true);
        HallCam.SetActive(false);
        BedroomCam.SetActive(false);
        BathroomCam.SetActive(false);
        ButtonClick.Play();

        HallFix.SetActive(false);
        LivingRoomFix.SetActive(true);
        BedroomFix.SetActive(false);
        BathroomFix.SetActive(false);
    }
    public void HallCamButton()
    {
        LivingRoomCam.SetActive(false);
        HallCam.SetActive(true);
        BedroomCam.SetActive(false);
        BathroomCam.SetActive(false);
        ButtonClick.Play();

        HallFix.SetActive(true);
        LivingRoomFix.SetActive(false);
        BedroomFix.SetActive(false);
        BathroomFix.SetActive(false);
    }
    public void BedroomCamButton()
    {
        LivingRoomCam.SetActive(false);
        HallCam.SetActive(false);
        BedroomCam.SetActive(true);
        BathroomCam.SetActive(false);
        ButtonClick.Play();

        HallFix.SetActive(false);
        LivingRoomFix.SetActive(false);
        BedroomFix.SetActive(true);
        BathroomFix.SetActive(false);
    }
    public void BathroomCamButton()
    {
        LivingRoomCam.SetActive(false);
        HallCam.SetActive(false);
        BedroomCam.SetActive(false);
        BathroomCam.SetActive(true);
        ButtonClick.Play();

        HallFix.SetActive(false);
        LivingRoomFix.SetActive(false);
        BedroomFix.SetActive(false);
        BathroomFix.SetActive(true);
    }
    
    
    
    
    
    
    
    
    
    public void RightClick()
    {
        HallCam.SetActive(false);
        LivingRoomCam.SetActive(true);
    }

    public void LeftClick()
    {
        HallCam.SetActive(true);
        LivingRoomCam.SetActive(false); 
    }



}
