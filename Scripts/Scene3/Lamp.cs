using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
public class Lamp : MonoBehaviour
{
    //左右目标
    public Transform left;

    public Transform right;
    //左右触发器
    public Transform leftTrigger;
    public Transform rightTrigger;
    //导航
    NavMeshAgent _agent;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        //松开手后恢复重力
        GetComponent<XRGrabInteractable>().selectExited.AddListener((e) =>
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        });
    }
    //如果碰到左边的触发器，则导航到左边的目标点，反之到右边
    private void OnTriggerEnter(Collider other)
    {
        if(other.transform == leftTrigger)
        {
            _agent.destination = left.position;
        }

        else if(other.transform == rightTrigger)
        {
            _agent.destination = right.position;
        }
    }
}
