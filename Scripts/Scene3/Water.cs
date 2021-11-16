using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    //力度
    public float force;
    //每个石头对应的弹起来的次数
    Dictionary<GameObject, int> stonesDic;
    //水花粒子
    public GameObject particleWater;
    private void Awake()
    {
        stonesDic = new Dictionary<GameObject, int>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //石头碰到后
        if (other.CompareTag("Stone"))
        {
            
            if (!stonesDic.ContainsKey(other.gameObject))
                stonesDic.Add(other.gameObject, 0);
            //如果石头弹起次数小于2或3
            if(stonesDic[other.gameObject]< Random.Range(2,4))
            {
                //给石头一个向上的冲击力
                var vel = other.GetComponent<Rigidbody>().velocity;
                vel.y = force * (4 - stonesDic[other.gameObject]);
                other.GetComponent<Rigidbody>().velocity = vel;
                stonesDic[other.gameObject]++;
                //生成水花
               var drop =  Instantiate(particleWater, other.transform.position, Quaternion.identity);
                Destroy(drop, 1);
            }
        }
    }
}
