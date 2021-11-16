using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkTrigger : MonoBehaviour
{
    //烟花的父物体
    public Transform fireworks;
    //所有烟花
   List<ParticleSystem> particles;
    public float playTime;
    //从父物体得到所有烟花
    private void Start()
    {
        particles = new List<ParticleSystem>();

        for(int i =0;i< fireworks.childCount;i++)
        {
            particles.Add(fireworks.GetChild(i).GetComponent<ParticleSystem>());
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //碰到玩家后，开始逐个播放
        if(other.CompareTag("Player"))
        {
            if (_hasPlay)
                return;
            _hasPlay = true;
            StartCoroutine(PlayFireCor());
        }

    }
    bool _hasPlay;
    //放一个，等一下再放下一个，直到放完
    IEnumerator PlayFireCor()
    {
        foreach(var v in particles)
        {
            v.Play();
            yield return new WaitForSeconds(playTime);
        }

    }
}
