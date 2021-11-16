using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using BansheeGz.BGSpline.Curve;
public class Deer2 : MonoBehaviour
{
    public Material m;
    //Ҫ��ʾ����Ʒ
    public GameObject[] objToShow;

    bool _has;
    private void Awake()
    {
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(SelectEntered);
        
    }
    
    void SelectEntered(SelectEnterEventArgs e)
    {
        if (_has)
            return;
        _has = true;
        StartCoroutine(OnClickCor());
    }

    //��������
    IEnumerator OnClickCor()
    {
        //���ò�����ɫ�� �𽥱�͸��
        float _t = 0;
         while(_t < 2)
        {
            m.SetColor("_BaseColor", new Color(1, 1, 1,1- _t / 2));
            _t += Time.deltaTime;
            yield return 0;
        }
         //ÿ��3����ʾһ������
         foreach(var child in objToShow)
        {
            child.SetActive(true);
            yield return new WaitForSeconds(3);
        }
    }

    private void OnDisable()
    {
        m.SetColor("_BaseColor", new Color(1, 1, 1,1));
    }


}
