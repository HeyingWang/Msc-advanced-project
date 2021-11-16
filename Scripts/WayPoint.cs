using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //碰到玩家后，告诉引导者
        if(other.CompareTag("Player"))
        {
            Leader.Instance.OnPlayerEnterPoint(this);
        }
    }
}
