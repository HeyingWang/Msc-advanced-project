using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Deer : MonoBehaviour
{
    //显示的位置
    public Transform showPos;
    //藏起来的位置
    public Transform hidePos;
    Animator _anim;
    //导航组件
    NavMeshAgent _agent;

    private void Awake()
    {
        _anim = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    //藏起来的时间点
    float _hideTime;
    public void Hide()
    {
        //告诉导航目标点
        _agent.destination = hidePos.position;
        _hideTime = Time.time;
    }

    private void Update()
    {
        //设置动画，如果没到目标点，则播放走路动画
        _anim.SetBool("isWalking", _agent.remainingDistance >= _agent.stoppingDistance+1);
        if(Time.time - _hideTime >=10f)
        {
            //如果躲起来了10秒，则出现
            _agent.destination = showPos.position;
        }
    }


}
