using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheats : MonoBehaviour
{
public GameObject TestingCheats;

    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            TestingCheats.SetActive(true);
        }
        if (Input.GetKeyDown("2"))
        {
            TestingCheats.SetActive(false);
        }
    }
}
