using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkTrigger : MonoBehaviour
{
    //�̻��ĸ�����
    public Transform fireworks;
    //�����̻�
   List<ParticleSystem> particles;
    public float playTime;
    //�Ӹ�����õ������̻�
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
        //������Һ󣬿�ʼ�������
        if(other.CompareTag("Player"))
        {
            if (_hasPlay)
                return;
            _hasPlay = true;
            StartCoroutine(PlayFireCor());
        }

    }
    bool _hasPlay;
    //��һ������һ���ٷ���һ����ֱ������
    IEnumerator PlayFireCor()
    {
        foreach(var v in particles)
        {
            v.Play();
            yield return new WaitForSeconds(playTime);
        }

    }
}
