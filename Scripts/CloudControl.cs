using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
public class CloudControl : MonoBehaviour
{
    //�����ƶ���Χ
    public float yRange;
    //�ƶ��ٶ�
    public float moveSpeed;
    //�����ֱ�����
    XRBaseInteractor XRBaseInteractor;
    //Ӱ��Ĳ�����
    public AudioSource[] targetSource;
    //һ��ʼ�ĸ߶�
    float _startY;
    //���Ƶ���պ�
    public SkyboxChange changer;
    public bool isDown;
    public bool revert = false;
    //���Ƶ�����
    public ParticleSystem[] particleSystems;

    private void Start()
    {
        _startY = transform.position.y;
    }
    //�ֱ��տ�ʼ����ʱ
    public void SelectedEnter(SelectEnterEventArgs e)
    {
        //�õ��ֱ�
        XRBaseInteractor = e.interactor;
        //��¼�߶�
        lastY = XRBaseInteractor.GetComponent<ActionBasedController>().positionAction.action.ReadValue<Vector3>().y;
        
    }

    float lastY;
    
    private void Update()
    {
        //�����ʱ���ֱ�����
        if(XRBaseInteractor!=null)
        {
            
            print("enter");
            //��ȡ�ֱ��߶�
            float currentY = XRBaseInteractor.GetComponent<ActionBasedController>().positionAction.action.ReadValue<Vector3>().y;
            //��ȥ��һ֡�ĸ߶ȣ��õ�����ֲ��ƶ�
            float delta = currentY - lastY;
            //������λ��
            Vector3 newPos = transform.position + Vector3.up * delta* moveSpeed;
            //��λ���޶��ڷ�Χ��
            if(!isDown)
            newPos.y = Mathf.Clamp(newPos.y, _startY, _startY + yRange);
            else
                newPos.y = Mathf.Clamp(newPos.y, _startY - yRange,_startY);
            transform.position = newPos;

            lastY = currentY;
            float value;
            //�������ı���պ�
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
  
            //�ı�����
            foreach (var v in targetSource)
            {
                if (revert)
                    v.volume = 1 - value;
                else
                    v.volume = value;
            }
            //��������
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
    //�ֱ��ɿ���������Ϊ��
    public void SelectedExit(SelectExitEventArgs e)
    {
        XRBaseInteractor = null;
    }
}
