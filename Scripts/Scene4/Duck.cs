using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public ParticleSystem ParticleSystem;

    public TextControl control;

    bool _hasShown;
    public void OnSelected()
    {
        //点击鸭子后，播放粒子，等两秒后播放文字
        if (_hasShown)
            return;
        _hasShown = true;
        ParticleSystem.Play();

        control.delay = 2;
        control.Show();

    }
}
