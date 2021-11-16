using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BoneTrigger : MonoBehaviour
{
    //��ͷҪ�����õ�λ��
    public Transform targetPos;
    //��ͷ���ú����ɫ
    public Material yellow;
    //����
    public ParticleSystem particleSystem1;
    private void OnTriggerEnter(Collider other)
    {
        //���������ͷ
        if(other.CompareTag("Bone"))
        {
            //��ͷ��ײ��ȡ��
            other.transform.GetComponent<Collider>().enabled = false;
            //��ͷ�ŵ�Ŀ��λ��
            other.transform.position = targetPos.position;
            other.transform.rotation = targetPos.rotation;
            //����ɫ
            other.transform.GetComponent<MeshRenderer>().material = yellow;
            //�̶������õ���
            other.transform.GetComponent<Rigidbody>().freezeRotation = true;
            other.transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //��ֹ���ץȡ
            other.transform.GetComponent<XRGrabInteractable>().enabled = false;
            //���߷ɻ�
            GetComponentInParent<Airplane>().OnPickBone();
            if(particleSystem1!=null)
            particleSystem1.Stop();
        }
    }

}
