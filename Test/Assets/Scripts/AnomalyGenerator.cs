using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnomalyGenerator : MonoBehaviour
{
public int GeneratedNumber = 0;
public float timer = 5;
public int RoomPicked = 0;
public int TimesGenerated = 0;

public AnomalyCounterScript AnomalyCounterScript;
public LivingRoom livingRoomScript;
public Hall hallScript;
public Bedroom bedroomScript;
public Bathroom bathroomScript;

public GameObject TimerText;
public GameObject GeneratedRoomText;
public GameObject TimesGeneratedText;
public GameObject AnomalyCountText;

    void Update()
    {
        TimerText.GetComponent<Text>().text = "Timer: " + timer;
        timer -= Time.deltaTime;
        if( timer < 0)
        {
            GeneratedNumber = Random.Range(2, 3);
            AnomalyCounter();
            TimerText.GetComponent<Text>().text = "Generated " + TimesGenerated + " Time(s)";
            timer++; timer++; timer++; timer++; timer++;

            TimesGenerated++;
            TimesGeneratedText.GetComponent<Text>().text = "Generated " + TimesGenerated + " Time(s)";
        }
    }
    void AnomalyCounter()
    {
        if (GeneratedNumber == 2)
        {
        RoomPicker();
        AnomalyCountText.GetComponent<Text>().text ="Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
    }
    void RoomPicker()
    {
        RoomPicked = Random.Range(1,2);
        if(RoomPicked == 1)
        {
            livingRoomScript.AnomalyPicker();
            GeneratedRoomText.GetComponent<Text>().text = "Room: Living Room";
        }

        if(RoomPicked == 2)
        {
            hallScript.AnomalyPicker();
            GeneratedRoomText.GetComponent<Text>().text = "Room: Hall";
        }

        if(RoomPicked == 3)
        {
            bedroomScript.AnomalyPicker();
            GeneratedRoomText.GetComponent<Text>().text = "Room: Bedroom";
        }

        if(RoomPicked == 4)
        {
            bathroomScript.AnomalyPicker();
            GeneratedRoomText.GetComponent<Text>().text = "Room: Bathroom";
        }
    }
}