using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //������Һ󣬸���������
        if(other.CompareTag("Player"))
        {
            Leader.Instance.OnPlayerEnterPoint(this);
        }
    }
}
