using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flowers : MonoBehaviour
{
    public AudioSource AudioSource;

    bool _hasPlayed;
    void Update()
    {
        //���Ŀ�겥������������0.8�����������Ӳ���
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
