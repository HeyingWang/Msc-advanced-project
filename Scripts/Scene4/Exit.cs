using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //��������˳���Ϸ
        if(other.CompareTag("Player"))
        {

            Application.Quit();
        }
    }
}
