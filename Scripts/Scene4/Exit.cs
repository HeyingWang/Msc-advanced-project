using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //碰到玩家退出游戏
        if(other.CompareTag("Player"))
        {

            Application.Quit();
        }
    }
}
