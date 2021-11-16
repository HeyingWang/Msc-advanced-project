using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    //���Ƶ�AudioSource����������
    public AudioSource[] targetSources;
    //ÿ������ı������
    public float changeValue;
    //�ı���պ͵Ľű�
    public SkyboxChange change;
    //�ɻ�
    public GameObject planes;

    //�ŵ����Ϻ�
    public void OnPick()
    {
        //��������
        foreach (var v in targetSources)
        {
            v.volume += changeValue;
        }
        //��������ˣ��ɻ�����
        if (targetSources[0].volume >= 0.9f)
            if (planes != null)
                planes.SetActive(true);
        //���������պУ���ı�ֵ
        if (change != null)
            change.ChangeDay(targetSources[0].volume);


    }
    //����������
    public void OnLost()
    {
        //��������
        foreach (var v in targetSources)
        {
            v.volume -= changeValue;
        }

        //�ı����
        if (change != null)
            change.ChangeDay(targetSources[0].volume);
    }

}
