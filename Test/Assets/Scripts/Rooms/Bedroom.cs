using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bedroom : MonoBehaviour
{
public int AnomalyPicked = 0;

public bool ObjectDisappearingAnomaly = false;
public bool ObjectMovementAnomaly = false;
public bool IntruderAnomaly = false;
public bool NoiseAnomaly = false;
public bool OtherAnomaly = false; 

public GameObject AnomalyGeneratedText; 

    void Update()
    {
        
    }

    public void AnomalyPicker()
    {
        AnomalyPicked = Random.Range(1,6);

        if (AnomalyPicked == 1 && ObjectDisappearingAnomaly == false)
        {
        ObjectDisappearingAnomaly = true;
        ObjectDisappearing();
        }

        if (AnomalyPicked == 2 && ObjectMovementAnomaly == false)
        {
        ObjectMovementAnomaly = true;
        ObjectMovement();
        }

        if (AnomalyPicked == 3 && IntruderAnomaly == false)
        {
        IntruderAnomaly = true;
        Intruder();
        }

        if (AnomalyPicked == 4 && NoiseAnomaly == false)
        {
        NoiseAnomaly = true;
        Noise();
        }

        if (AnomalyPicked == 5 && OtherAnomaly == false)
        {
        OtherAnomaly = true;
        Other();
        }

        Debug.Log("Bedroom");
    }
    
    public void ObjectDisappearing()
    {
        Debug.Log("Object Disappearing");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Disappearing";
    }

    public void ObjectMovement()
    {
        Debug.Log("Object Movement");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Movement";
    }

    public void Intruder()
    {
        Debug.Log("Intruder");
        AnomalyGeneratedText.GetComponent<Text>().text = "Intruder";
    }

    public void Noise()
    {
        Debug.Log("Noise");
        AnomalyGeneratedText.GetComponent<Text>().text = "Noise";
    }

    public void Other()
    {
        Debug.Log("Other");
        AnomalyGeneratedText.GetComponent<Text>().text = "Other";
    }
}
