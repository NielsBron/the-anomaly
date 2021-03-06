using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivingRoom : MonoBehaviour
{
public int AnomalyPicked = 0;
public int MovementPicker = 0;
public int DisappearingPicker = 0;

public bool ObjectDisappearingAnomaly = false;
public bool ObjectMovementAnomaly = false;
public bool IntruderAnomaly = false;
public bool NoiseAnomaly = false;
public bool OtherAnomaly = false;
public bool DemonicPresenceAnomaly = false;

/// TEXT ///
public GameObject AnomalyGeneratedText;
public GameObject AnomalyCountText;
public GameObject AnomalyNotFoundText;


/// BUTTONS ///
public GameObject FixAnomalyBtn;
public GameObject AnomalyWindow;
public GameObject AnomalyWindowClose;
public GameObject AnomalyFixed;

public Button ObjectDisappearingBtn;
public Button ObjectMovementBtn;
public Button IntruderBtn;
public Button NoiseBtn;
public Button OtherBtn;
public Button DemonicPresenceBtn;
public Button Right;
public Button Left;

/// LIGHTS ///
public GameObject Light1;
public GameObject Light2;
public GameObject Light3;

/// OBJECTS ///
public GameObject IntruderObj;
public GameObject PaintingGood1;
public GameObject PaintingBad1;
public GameObject MovingPainting1;
public GameObject MovingChair;
public GameObject Television;
public GameObject Chair_Disappearing;
public GameObject Glass_Disappearing;




/// AUDIO ///
public AudioSource IntruderSound;
public AudioSource NoiseSound;
public AudioSource AnomalyFixSound;
public AudioSource ButtonClick;
public AudioSource RemPodSound;
public AudioSource MovingChairSound;
public AudioSource MovingPaintingSound;

public AnomalyCounterScript AnomalyCounterScript;
public GameObject RemPodScript;
public GameObject RemPodLight1;
public GameObject RemPodLight2;
public GameObject RemPodLight3;
public GameObject RemPodLight4;

    void Update()
    {
        
    }

    public void AnomalyPicker()
    {
        AnomalyPicked = Random.Range(1,7);

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
        if (AnomalyPicked == 6 && DemonicPresenceAnomaly == false)
        {
            DemonicPresenceAnomaly = true;
            DemonicPresence();
        }

        Debug.Log("Living Room");
    }
    
    public void ObjectDisappearing()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Object Disappearing");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Disappearing";
        DisappearingPicker = Random.Range(1,4);
        if (DisappearingPicker == 1)
        {
            Television.GetComponent<Animation>().Play("Tv_Disappearing");
        }
        if (DisappearingPicker == 2)
        {
            Chair_Disappearing.GetComponent<Animation>().Play("Chair_Disappear");
        }
        if (DisappearingPicker == 3)
        {
            Glass_Disappearing.GetComponent<Animation>().Play("Glass_Disappearing");
        }  
    }


    public void ObjectMovement()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Object Movement");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Movement";
        MovementPicker = Random.Range(1,3);
        if (MovementPicker == 1)
        {
            MovingPainting1.GetComponent<Animation>().Play("PaintingMoving2");
            MovingPaintingSound.Play();
        }
        if (MovementPicker == 2)
        {
            MovingChair.GetComponent<Animation>().Play("MovingChair");
            MovingChairSound.Play();
        }
    }

    public void Intruder()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Intruder");
        AnomalyGeneratedText.GetComponent<Text>().text = "Intruder";
        IntruderObj.SetActive(true);
        Light3.SetActive(true);
    }

    public void Noise()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Noise");
        AnomalyGeneratedText.GetComponent<Text>().text = "Noise";
        NoiseSound.Play();
    }

    public void Other()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Other");
        AnomalyGeneratedText.GetComponent<Text>().text = "Other";
        PaintingGood1.SetActive(false);
        PaintingBad1.SetActive(true);
    }

    public void DemonicPresence()
    {
        StartCoroutine(DemonicPresence1());
    }

    IEnumerator DemonicPresence1()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Demonic Presence");
        AnomalyGeneratedText.GetComponent<Text>().text = "Demonic Presence";
        RemPodScript.SetActive(true);
        yield return new WaitForSeconds (0.0f);
    }

    /// ANOMALY FIXER///
    public void ObjectDisappearingBtnClicked()
    {
        StartCoroutine(FixObjectDisappearing());
    }
    public void ObjectMovementBtnClicked()
    {
        StartCoroutine(FixObjectMovement());
    }
    public void IntruderBtnClicked()
    {
        StartCoroutine(FixIntruder());
    }
    public void NoiseBtnClicked()
    {
        StartCoroutine(FixNoise());
    }
    public void OtherBtnClicked()
    {
        StartCoroutine(FixOther());
    }
    public void DemonicPresenceBtnClicked()
    {
        StartCoroutine(FixDemonicPresence());
    }

    public void FixAnomaly()
    {   
        ButtonClick.Play();
        AnomalyWindow.SetActive(true);
        FixAnomalyBtn.SetActive(false);
        Right.enabled = false;
        Left.enabled = false;
    }
    public void CloseWindow()
    {
        ButtonClick.Play();
        AnomalyWindow.SetActive(false);
        FixAnomalyBtn.SetActive(true);
        Right.enabled = true;
        Left.enabled = true;
    }

    IEnumerator FixObjectDisappearing()
    {  
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectDisappearingAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            Television.GetComponent<Animation>().Play("Tv_Idle");
            Chair_Disappearing.GetComponent<Animation>().Play("Chair_Idle");
            Glass_Disappearing.GetComponent<Animation>().Play("Glass_Idle");
            AnomalyFixed.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            ObjectDisappearingAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Object Disappearing Anomaly found";
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(false);
            EnableButtons();
        }
    }
    
    IEnumerator FixObjectMovement()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectMovementAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            AnomalyFixed.SetActive(false);
            MovingPainting1.GetComponent<Animation>().Play("IdlePainting2");
            MovingChair.GetComponent<Animation>().Play("IdleChair");
            AnomalyCounterScript.TheAnomalyCounter--;
            ObjectMovementAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Object Movement Anomaly found";
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(false);
            EnableButtons();
        }
    }

    IEnumerator FixIntruder()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (IntruderAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            IntruderObj.SetActive(false);
            Light3.SetActive(false);
            AnomalyFixed.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            IntruderAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Intruder Anomaly found";
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
        }
    }

    IEnumerator FixNoise()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (NoiseAnomaly == true) 
        {
            NoiseSound.Stop();
            AnomalyFixSound.Play();
            AnomalyFixed.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            AnomalyFixed.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            NoiseSound.Stop();
            NoiseAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Noise Anomaly found";
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
        }
    }

    IEnumerator FixOther()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (OtherAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            AnomalyFixed.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            OtherAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
            PaintingGood1.SetActive(true);
            PaintingBad1.SetActive(false);
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Other Anomaly found";
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(false);
            EnableButtons();
        }
    }

    IEnumerator FixDemonicPresence()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        DisableButtons();
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (DemonicPresenceAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            EnableButtons();
            RemPodSound.Stop();
            RemPodScript.SetActive(false);
            AnomalyFixed.SetActive(false);
            RemPodLight1.SetActive(false);
            RemPodLight2.SetActive(false);
            RemPodLight3.SetActive(false);
            RemPodLight4.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            DemonicPresenceAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Demonic Presence Anomaly found";
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(false);
            EnableButtons();
        }
    }
    
    public void DisableButtons()
    {        
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
    }

    public void EnableButtons()
    {
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        DemonicPresenceBtn.enabled = true;
    }
}
