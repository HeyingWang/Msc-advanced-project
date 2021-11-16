using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GriaffeMove : MonoBehaviour
{
    //����������
    Animator _animator;
    //����
    NavMeshAgent _agent;
    //��ʾ������λ��
    public Transform showPosition;
    public Transform hidePosition;
    //������
    public AudioSource controller;
    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    private void Start()
    {
     
    }
    private void Update()
    {
        //���Ŀ����������0.5����ʾ����������
        if(controller.volume >0.5f)
        {
            Show();
        }
        else
        {
            Hide();
        }

  //���ö���
        _animator.SetBool("Running", !(_agent.remainingDistance <=_agent.stoppingDistance));
    }
    //������һ��Ŀ��
    public void Show()
    {
        _agent.SetDestination(showPosition.position);
    }

    public void Hide()
    {
        _agent.SetDestination(hidePosition.position);
    }

}
