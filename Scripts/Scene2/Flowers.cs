using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public AudioSource AudioSource;

    bool _hasPlayed;
    void Update()
    {
        //如果目标播放器音量大于0.8，让所有粒子播放
        if(AudioSource.volume > 0.8f && !_hasPlayed)
        {
            _hasPlayed = true;
            foreach(var particle in GetComponentsInChildren<ParticleSystem>())
            {
                particle.Play();
            }
        }
    }
}
