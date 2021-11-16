using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    //���
    public TextRevealer textRevealer;
    //�Ƿ��Ѿ���ʾ����
    bool _hasShown;
    //�Ƿ�һ��ʼ��Ϸ����ʾ
    public bool revealOnStart;
    public float delay = 0;
    private void Start()
    {
        //���һ��ʼ����ʾ������ʾ
        if(revealOnStart)
        {
            StartCoroutine(RevealOnStart());
        }
    }
    public void Show()
    {
        _hasShown = true;

        StartCoroutine(UnReveal());
    }
    //������Һ���ʾ
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_hasShown)
        {
            _hasShown = true;

            StartCoroutine(UnReveal());
        }
    }
    //�����룬������ʾ����6����ɢ
    IEnumerator RevealOnStart()
    {
        yield return new WaitForSeconds(2);
        textRevealer.Reveal();
        yield return new WaitForSeconds(6);
        textRevealer.Unreveal();
    }
    //��delay����ʾ����6����ɢ
    IEnumerator UnReveal()
    {
        yield return new WaitForSeconds(delay);
        textRevealer.Reveal();
        yield return new WaitForSeconds(6);
        textRevealer.Unreveal();
    }
}
