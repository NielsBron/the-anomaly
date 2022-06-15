using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnomalyCounterScript : MonoBehaviour
{
public int TheAnomalyCounter = 0;

public GameObject Death;

///Anomaly Generator
public GameObject AnomalyGen;

///Room scripts
public GameObject Script1;
public GameObject Script2;
public GameObject Script3;
public GameObject Script4;



void Update ()
{
    if (TheAnomalyCounter == 6)
    {
        Death.SetActive(true);
        
        AnomalyGen.SetActive(false);

        Script1.SetActive(false);
        Script2.SetActive(false);
        Script3.SetActive(false);
        Script4.SetActive(false);
    }
}
}