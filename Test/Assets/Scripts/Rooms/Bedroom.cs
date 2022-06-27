using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bedroom : MonoBehaviour
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

/// OBJECTS ///
public GameObject OuijaBoard;
public GameObject DisappearingBlanket;
public GameObject IntruderObj;
public GameObject MovingChair;


/// AUDIO ///
public AudioSource IntruderSound;
public AudioSource NoiseSound;
public AudioSource AnomalyFixSound;
public AudioSource ButtonClick;
public AudioSource ChairSound;

public AnomalyCounterScript AnomalyCounterScript;
    void Update()
    {
        
    }

    public void AnomalyPicker()
    {
        AnomalyPicked = Random.Range(4,5);

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

        Debug.Log("Bedroom");
    }
    
    public void ObjectDisappearing()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Object Disappearing");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Disappearing";
        DisappearingBlanket.GetComponent<Animation>().Play("Blanket_Disappearing");
    }

    public void ObjectMovement()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Object Movement");
        AnomalyGeneratedText.GetComponent<Text>().text = "Object Movement";
        MovingChair.GetComponent<Animation>().Play("MovingChair2");
        ChairSound.Play();
    }

    public void Intruder()
    {
        AnomalyCounterScript.TheAnomalyCounter++;
        Debug.Log("Intruder");
        AnomalyGeneratedText.GetComponent<Text>().text = "Intruder";
        IntruderObj.SetActive(true);
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
        OuijaBoard.GetComponent<Animation>().Play("zozo");
        yield return new WaitForSeconds (12.0f);
        OuijaBoard.GetComponent<Animation>().Play("zozo2");
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
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectDisappearingAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
            DisappearingBlanket.GetComponent<Animation>().Play("Blanket_Idle");
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
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }

    IEnumerator FixObjectMovement()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectMovementAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            MovingChair.GetComponent<Animation>().Play("IdleChair2");
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
            AnomalyFixed.SetActive(false);
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
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }

    IEnumerator FixIntruder()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (IntruderAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
            IntruderObj.SetActive(false);
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
            AnomalyNotFoundText.SetActive(false);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }

    IEnumerator FixNoise()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (NoiseAnomaly == true) 
        {
            NoiseSound.Stop();
            AnomalyFixSound.Play();
            AnomalyFixed.SetActive(true);
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
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
            AnomalyNotFoundText.SetActive(false);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }

    IEnumerator FixOther()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (OtherAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
            AnomalyFixed.SetActive(false);
            AnomalyCounterScript.TheAnomalyCounter--;
            OtherAnomaly = false;
            AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else 
        {
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(true);
            AnomalyNotFoundText.GetComponent<Text>().text = "No type Other Anomaly found";
            yield return new WaitForSeconds(2.0f);
            AnomalyNotFoundText.SetActive(false);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }

    IEnumerator FixDemonicPresence()
    {
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        DemonicPresenceBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (DemonicPresenceAnomaly == true) 
        {
            AnomalyFixed.SetActive(true);
            AnomalyFixSound.Play();
            OuijaBoard.GetComponent<Animation>().Stop("zozo2");
            OuijaBoard.GetComponent<Animation>().Play("zozoidle");
            yield return new WaitForSeconds(2.0f);
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
            AnomalyFixed.SetActive(false);
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
            ObjectDisappearingBtn.enabled = true;
            ObjectMovementBtn.enabled = true;
            IntruderBtn.enabled = true;
            NoiseBtn.enabled = true;
            OtherBtn.enabled = true;
            DemonicPresenceBtn.enabled = true;
        }
    }
}
