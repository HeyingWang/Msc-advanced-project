using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.XR.Interaction.Toolkit;
public class Lamp : MonoBehaviour
{
    //����Ŀ��
    public Transform left;

    public Transform right;
    //���Ҵ�����
    public Transform leftTrigger;
    public Transform rightTrigger;
    //����
    NavMeshAgent _agent;
    
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        //�ɿ��ֺ�ָ�����
        GetComponent<XRGrabInteractable>().selectExited.AddListener((e) =>
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        });
    }
    //���������ߵĴ��������򵼺�����ߵ�Ŀ��㣬��֮���ұ�
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
