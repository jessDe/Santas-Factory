using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Akt1TriggerCaught : MonoBehaviour
{
    private void Start()
    {
        
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject.Find("Akt 1 Manager").GetComponent<Akt1Manager>().Akt1Done();
        }
    }
}
