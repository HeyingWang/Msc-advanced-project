using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoneTrigger : MonoBehaviour
{
    //骨头要被放置的位置
    public Transform targetPos;
    //骨头放置后的颜色
    public Material yellow;
    //烟雾
    public ParticleSystem particleSystem1;
    private void OnTriggerEnter(Collider other)
    {
        //如果碰到骨头
        if(other.CompareTag("Bone"))
        {
            //骨头碰撞器取消
            other.transform.GetComponent<Collider>().enabled = false;
            //骨头放到目标位置
            other.transform.position = targetPos.position;
            other.transform.rotation = targetPos.rotation;
            //改颜色
            other.transform.GetComponent<MeshRenderer>().material = yellow;
            //固定，放置掉落
            other.transform.GetComponent<Rigidbody>().freezeRotation = true;
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //防止玩家抓取
            other.transform.GetComponent<XRGrabInteractable>().enabled = false;
            //告诉飞机
            GetComponentInParent<Airplane>().OnPickBone();
            if(particleSystem1!=null)
            particleSystem1.Stop();
        }
    }

}
