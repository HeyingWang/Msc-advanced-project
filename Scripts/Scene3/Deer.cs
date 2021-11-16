using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Deer : MonoBehaviour
{
    //��ʾ��λ��
    public Transform showPos;
    //��������λ��
    public Transform hidePos;
    Animator _anim;
    //�������
    NavMeshAgent _agent;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    //��������ʱ���
    float _hideTime;
    public void Hide()
    {
        //���ߵ���Ŀ���
        _agent.destination = hidePos.position;
        _hideTime = Time.time;
    }

    private void Update()
    {
        //���ö��������û��Ŀ��㣬�򲥷���·����
        _anim.SetBool("isWalking", _agent.remainingDistance >= _agent.stoppingDistance+1);
        if(Time.time - _hideTime >=10f)
        {
            //�����������10�룬�����
            _agent.destination = showPos.position;
        }
    }


}
