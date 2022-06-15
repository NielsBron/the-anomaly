using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AnomalyGen : MonoBehaviour
{
public GameObject PaintingGood1;
public GameObject PaintingGood2;
public GameObject PaintingBad1;
public GameObject PaintingBad2;
public GameObject MovingPainting1;
public GameObject DisappearingPainting1;
public GameObject Light1;
public GameObject Light2;
public GameObject Light3;
public GameObject Death;
public GameObject GeneratedNumberText;
public GameObject AnomalyCountText;
public GameObject TimerText;
public GameObject TimerGeneratedText;
public GameObject AnomalyTypeText;
public GameObject AnomalyNotFoundText;
public GameObject Script;

public GameObject IntruderAnim;

////////// BUTTONS //////////////
public GameObject FixAnomalyBtn;
public GameObject AnomalyWindow;
public GameObject AnomalyWindowClose;
public GameObject AnomalyFixed;

public Button ObjectDisappearingBtn;
public Button ObjectMovementBtn;
public Button IntruderBtn;
public Button NoiseBtn;
public Button OtherBtn;

public bool ObjectDisappearingAnomaly = false;
public bool ObjectMovementAnomaly = false;
public bool IntruderAnomaly = false;
public bool NoiseAnomaly = false;
public bool OtherAnomaly = false;
public int AnomalyPicked = 0;
public int PaintingPicker = 0;
public int GeneratedNumber = 0;
private float timer = 5;

public int TimesGenerated = 0;
public int AnomalyPickedTest = 0;
public AudioSource IntruderSound;
public AudioSource NoiseSound;
public AudioSource AnomalyFixSound;
public AudioSource ButtonClick;

public AnomalyCounterScript AnomalyCounterScript;
    void Start()
    {
    }
    void Update()
    {
        TimerText.GetComponent<Text>().text = "Timer: " + timer;
        timer -= Time.deltaTime;
        if( timer < 0)
        {
            GeneratedNumber = Random.Range(1, 4);
            GeneratedNumberText.GetComponent<Text>().text = "Generated: " + GeneratedNumber;
            AnomalyCounter();
            TimesGenerated++;
            TimerGeneratedText.GetComponent<Text>().text = "Generated " + TimesGenerated + " Time(s)";
            //timer++; timer++; timer++; timer++; timer++;
            timer++; timer++; timer++; timer++; timer++;
            //timer++; timer++;
        }
        if (AnomalyCounterScript.TheAnomalyCounter == 5){
            Death.SetActive(true);
            Script.SetActive(false);
        }
    }
    void AnomalyCounter()
    {
        if (GeneratedNumber == 2)
        {
        AnomalyPicker();
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
    }

    void AnomalyPicker()
    {
        AnomalyPicked = Random.Range(1, 6);
    if (AnomalyPicked == 1 && ObjectDisappearingAnomaly == false)
    {
        ObjectDisappearingAnomaly = true;
        ObjectDisappearing();
        AnomalyCounterScript.TheAnomalyCounter++;
    }
    else if (AnomalyPicked == 1 && ObjectDisappearingAnomaly == true)
    {
        AnomalyPicked = Random.Range(2,6);
    }

    if (AnomalyPicked == 2 && ObjectMovementAnomaly == false)
    {
        ObjectMovementAnomaly = true;
        ObjectMovement();
        AnomalyCounterScript.TheAnomalyCounter++;
    }
    else if (AnomalyPicked == 2 &&ObjectMovementAnomaly == true)
    {
        AnomalyPicked = Random.Range(1,2);
        AnomalyPicked = Random.Range(3,6);
    }

    if (AnomalyPicked == 3 && IntruderAnomaly == false)
    {
        IntruderAnomaly = true;
        Intruder1();
        AnomalyCounterScript.TheAnomalyCounter++;    }
    else if (AnomalyPicked == 3 && IntruderAnomaly == true)
    {
        AnomalyPicked = Random.Range(1,3);
        AnomalyPicked = Random.Range(4,6);
    }

    if (AnomalyPicked == 4 && NoiseAnomaly == false)
    {
        NoiseAnomaly = true;
        Noise();
        AnomalyCounterScript.TheAnomalyCounter++;
    }
    else if (AnomalyPicked == 4 && NoiseAnomaly == true)
    {
        AnomalyPicked = Random.Range(1,4);
        AnomalyPicked = Random.Range(5,6);
    }

    if (AnomalyPicked == 5 && OtherAnomaly == false)
    {
        PaintingPicker = Random.Range(1,3);
        OtherAnomaly = true;
        Other();
        AnomalyCounterScript.TheAnomalyCounter++;
    }
    else if (AnomalyPicked == 5 && OtherAnomaly == true)
    {
        AnomalyPicked = Random.Range(1,5);
    }
    }

    /////////// IF ANOMALY IS ALREADY PICKED - PICK A DIFFERENT ANOMALY

    public void Intruder1()
    {
        StartCoroutine(Intruder());
    }

    void ObjectDisappearing()
    {
        DisappearingPainting1.GetComponent<Animation>().Play("PaintingDisappearing1");
        AnomalyTypeText.GetComponent<Text>().text = "AnomalyType: Object Disappearing ";
    }
    void ObjectMovement()
    {
        MovingPainting1.GetComponent<Animation>().Play("PaintingMoving");
        AnomalyTypeText.GetComponent<Text>().text = "AnomalyType: Object Movement ";
    }
    IEnumerator Intruder()
    {
        IntruderAnim.SetActive(true);
        IntruderAnim.GetComponent<Animation>().Play("IntruderMoving");
        IntruderSound.Play();
        AnomalyTypeText.GetComponent<Text>().text = "AnomalyType: Intruder ";
        yield return new WaitForSeconds (4f);
        Light3.SetActive(false);
        yield return new WaitForSeconds (4f);
        Light2.SetActive(false);
        yield return new WaitForSeconds (4f);
    }
    void Noise()
    {
        NoiseSound.Play();
        AnomalyTypeText.GetComponent<Text>().text = "AnomalyType: Noise ";
    }
    void Other()
    {
        AnomalyTypeText.GetComponent<Text>().text = "AnomalyType: Other ";
        if (PaintingPicker == 1)
    {
        PaintingGood1.SetActive(false);
        PaintingBad1.SetActive(true);
    }
        if (PaintingPicker == 2)
    {
        PaintingGood2.SetActive(false);
        PaintingBad2.SetActive(true);
    }
    }

///// Anomaly Fixer Window opener
    public void FixAnomaly()
    {   ButtonClick.Play();
        AnomalyWindow.SetActive(true);
        FixAnomalyBtn.SetActive(false);
    }
    public void CloseWindow()
    {
        ButtonClick.Play();
        AnomalyWindow.SetActive(false);
        FixAnomalyBtn.SetActive(true);
    }
/////// StartCoroutine for AnomalyFix Buttons
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
//// Anomaly Fixer Button functions

    IEnumerator FixObjectDisappearing()
    {  
        ButtonClick.Play();
        //// DISABLE ALL BUTTONS WHEN ONE BUTTON IS PRESSED ////
        ObjectDisappearingBtn.enabled = false;
        ObjectMovementBtn.enabled = false;
        IntruderBtn.enabled = false;
        NoiseBtn.enabled = false;
        OtherBtn.enabled = false;
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectDisappearingAnomaly == true) {
        AnomalyFixed.SetActive(true);
        AnomalyFixSound.Play();
        yield return new WaitForSeconds(2.0f);
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        DisappearingPainting1.GetComponent<Animation>().Play("IdlePainting1");
        AnomalyFixed.SetActive(false);
        AnomalyCounterScript.TheAnomalyCounter--;
        ObjectDisappearingAnomaly = false;
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else {
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
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (ObjectMovementAnomaly == true) {
        AnomalyFixed.SetActive(true);
        AnomalyFixSound.Play();
        yield return new WaitForSeconds(2.0f);
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        AnomalyFixed.SetActive(false);
        MovingPainting1.GetComponent<Animation>().Play("IdlePainting");
        AnomalyCounterScript.TheAnomalyCounter--;
        ObjectMovementAnomaly = false;
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else {
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
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (IntruderAnomaly == true) {
        AnomalyFixed.SetActive(true);
        AnomalyFixSound.Play();
        yield return new WaitForSeconds(2.0f);
        IntruderAnim.SetActive(false);
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        AnomalyFixed.SetActive(false);
        AnomalyCounterScript.TheAnomalyCounter--;
        IntruderAnomaly = false;
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        IntruderSound.Stop();
        Light2.SetActive(true);
        Light3.SetActive(true);
        }
        else {
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
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (NoiseAnomaly == true) {
        AnomalyFixSound.Play();
        AnomalyFixed.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        AnomalyFixed.SetActive(false);
        AnomalyCounterScript.TheAnomalyCounter--;
        NoiseSound.Stop();
        NoiseAnomaly = false;
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        }
        else {
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
        yield return new WaitForSeconds(2.0f);
        //// IF TRUE ////
        if (OtherAnomaly == true) {
        AnomalyFixed.SetActive(true);
        AnomalyFixSound.Play();
        yield return new WaitForSeconds(2.0f);
        ObjectDisappearingBtn.enabled = true;
        ObjectMovementBtn.enabled = true;
        IntruderBtn.enabled = true;
        NoiseBtn.enabled = true;
        OtherBtn.enabled = true;
        AnomalyFixed.SetActive(false);
        AnomalyCounterScript.TheAnomalyCounter--;
        OtherAnomaly = false;
        AnomalyCountText.GetComponent<Text>().text = "Anomalies: " + AnomalyCounterScript.TheAnomalyCounter;
        PaintingGood1.SetActive(true);
        PaintingGood2.SetActive(true);
        PaintingBad1.SetActive(false);
        PaintingBad2.SetActive(false);
        }
        else {
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
        }
    }
}
