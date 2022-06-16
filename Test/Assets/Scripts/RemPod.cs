using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemPod : MonoBehaviour
{
    public int LightMode;

    public GameObject Light1;
    public GameObject Light2;
    public GameObject Light3;
    public GameObject Light4;

    public AudioSource RemPodSound;

    void Update() {
        if (LightMode == 0) {
            StartCoroutine (AnimateLight ());
        }
    }

    IEnumerator AnimateLight () {
        LightMode = Random.Range (1,12);
        if (LightMode == 1) {
            Light1.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (5.0f);
            Light1.SetActive(false);
            RemPodSound.Stop();
        }
        if (LightMode == 2) {
            yield return new WaitForSeconds (5.0f);
        }
        if (LightMode == 3) {
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.1f);
            Light2.SetActive(false);
            RemPodSound.Stop();
        }
        if (LightMode == 4) {
            yield return new WaitForSeconds (5.0f);
        }
        if (LightMode == 5) {
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (3.0f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (1.0f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (2.0f);
            Light2.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (1.0f);

        }
        if (LightMode == 6) {
            Light4.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (3.0f);
            Light4.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (4.0f);
            Light4.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (1.0f);
        }
        if (LightMode == 7) {
            Light3.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.05f);
            Light3.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.05f);
            Light2.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.05f);
            Light2.SetActive(false);
            RemPodSound.Stop();
        }
        if (LightMode == 8) {
            yield return new WaitForSeconds (5.0f);
        }
        if (LightMode == 9) {
            Light3.SetActive(true);
            Light1.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.05f);
            Light3.SetActive(false);
            Light1.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (0.05f);
            Light3.SetActive(true);
            Light1.SetActive(true);
            RemPodSound.Play();
            yield return new WaitForSeconds (0.05f);
            Light3.SetActive(false);
            Light1.SetActive(false);
            RemPodSound.Stop();
        }
        if (LightMode == 10) {
            RemPodSound.Play();
            Light1.SetActive(true);
            Light2.SetActive(true);
            Light3.SetActive(true);
            Light4.SetActive(true);
            yield return new WaitForSeconds (3.0f);
            Light1.SetActive(false);
            Light2.SetActive(false);
            Light3.SetActive(false);
            Light4.SetActive(false);
            RemPodSound.Stop();
            yield return new WaitForSeconds (1.0f);
        }
        if (LightMode == 11) {
            yield return new WaitForSeconds (5.0f);
        }
        yield return new WaitForSeconds (1.0f);
        LightMode = 0;
    }
}
