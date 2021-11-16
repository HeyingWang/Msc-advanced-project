using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextControl : MonoBehaviour
{
    //插件
    public TextRevealer textRevealer;
    //是否已经显示过了
    bool _hasShown;
    //是否一开始游戏就显示
    public bool revealOnStart;
    public float delay = 0;
    private void Start()
    {
        //如果一开始就显示，则显示
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
    //碰到玩家后，显示
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !_hasShown)
        {
            _hasShown = true;

            StartCoroutine(UnReveal());
        }
    }
    //等两秒，文字显示，等6秒消散
    IEnumerator RevealOnStart()
    {
        yield return new WaitForSeconds(2);
        textRevealer.Reveal();
        yield return new WaitForSeconds(6);
        textRevealer.Unreveal();
    }
    //等delay秒显示，等6秒消散
    IEnumerator UnReveal()
    {
        yield return new WaitForSeconds(delay);
        textRevealer.Reveal();
        yield return new WaitForSeconds(6);
        textRevealer.Unreveal();
    }
}
