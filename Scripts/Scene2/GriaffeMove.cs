using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GriaffeMove : MonoBehaviour
{
    //动画控制器
    Animator _animator;
    //导航
    NavMeshAgent _agent;
    //显示和隐藏位置
    public Transform showPosition;
    public Transform hidePosition;
    //播放器
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
        //如果目标声音大于0.5则显示，否则隐藏
        if(controller.volume >0.5f)
        {
            Show();
        }
        else
        {
            Hide();
        }

  //设置动画
        _animator.SetBool("Running", !(_agent.remainingDistance <=_agent.stoppingDistance));
    }
    //给导航一个目标
    public void Show()
    {
        _agent.SetDestination(showPosition.position);
    }

    public void Hide()
    {
        _agent.SetDestination(hidePosition.position);
    }

}
