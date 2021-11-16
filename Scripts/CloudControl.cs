using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CloudControl : MonoBehaviour
{
    //上下移动范围
    public float yRange;
    //移动速度
    public float moveSpeed;
    //被此手柄控制
    XRBaseInteractor XRBaseInteractor;
    //影响的播放器
    public AudioSource[] targetSource;
    //一开始的高度
    float _startY;
    //控制的天空盒
    public SkyboxChange changer;
    public bool isDown;
    public bool revert = false;
    //控制的粒子
    public ParticleSystem[] particleSystems;

    private void Start()
    {
        _startY = transform.position.y;
    }
    //手柄刚开始控制时
    public void SelectedEnter(SelectEnterEventArgs e)
    {
        //得到手柄
        XRBaseInteractor = e.interactor;
        //记录高度
        lastY = XRBaseInteractor.GetComponent<ActionBasedController>().positionAction.action.ReadValue<Vector3>().y;
        
    }

    float lastY;
    
    private void Update()
    {
        //如果此时被手柄控制
        if(XRBaseInteractor!=null)
        {
            
            print("enter");
            //读取手柄高度
            float currentY = XRBaseInteractor.GetComponent<ActionBasedController>().positionAction.action.ReadValue<Vector3>().y;
            //减去上一帧的高度，得到玩家手部移动
            float delta = currentY - lastY;
            //计算新位置
            Vector3 newPos = transform.position + Vector3.up * delta* moveSpeed;
            //将位置限定在范围内
            if(!isDown)
            newPos.y = Mathf.Clamp(newPos.y, _startY, _startY + yRange);
            else
                newPos.y = Mathf.Clamp(newPos.y, _startY - yRange,_startY);
            transform.position = newPos;

            lastY = currentY;
            float value;
            //按比例改变天空盒
            if (!isDown)
            {
                value = (transform.position.y - _startY) / yRange;
                if(changer!=null)
                    changer.ChangeDay(value);
            }

            else
            {
                value = 1 - (_startY - transform.position.y) / yRange;
                if (changer != null)
                    changer.ChangeDay(1- value);
            }
  
            //改变声音
            foreach (var v in targetSource)
            {
                if (revert)
                    v.volume = 1 - value;
                else
                    v.volume = value;
            }
            //控制粒子
            if (targetSource[0].volume > 0.5f)
                foreach (var p in particleSystems)
                {
                    p.Play();
                }
            else
                foreach (var p in particleSystems)
                {
                    p.Stop();
                }


        }
    }
    //手柄松开，则设置为空
    public void SelectedExit(SelectExitEventArgs e)
    {
        XRBaseInteractor = null;
    }
}
