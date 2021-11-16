using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //����
    public float force;
    //ÿ��ʯͷ��Ӧ�ĵ������Ĵ���
    Dictionary<GameObject, int> stonesDic;
    //ˮ������
    public GameObject particleWater;
    private void Awake()
    {
        stonesDic = new Dictionary<GameObject, int>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //ʯͷ������
        if (other.CompareTag("Stone"))
        {
            
            if (!stonesDic.ContainsKey(other.gameObject))
                stonesDic.Add(other.gameObject, 0);
            //���ʯͷ�������С��2��3
            if(stonesDic[other.gameObject]< Random.Range(2,4))
            {
                //��ʯͷһ�����ϵĳ����
                var vel = other.GetComponent<Rigidbody>().velocity;
                vel.y = force * (4 - stonesDic[other.gameObject]);
                other.GetComponent<Rigidbody>().velocity = vel;
                stonesDic[other.gameObject]++;
                //����ˮ��
               var drop =  Instantiate(particleWater, other.transform.position, Quaternion.identity);
                Destroy(drop, 1);
            }
        }
    }
}
