using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TreeLeaves : MonoBehaviour
{
    //����
    public Transform targetPosition;
    //��Ӧ��������
    public string targetTreeName;
    //һ��ʼ�Ƿ�������
    public bool initOn;
    //�Ƿ�������
    bool _isOn;
    private void Start()
    {
        
        _isOn = initOn;
        //�ֱ�ץ���󴥷�OnSelected
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelected);
        //�ֱ��ɿ��󴥷�OnUnselected
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnUnselected);
    }



    
    private void OnTriggerEnter(Collider other)
    {
        //�������ǶԵ�������û�������ϣ���û�б����ץ�ţ�������
        if(other.name == targetTreeName && !_isOn && !_isSelected)
        {
            //����λ�ã��̶�λ��
            _isOn = true;
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            transform.GetComponent<Rigidbody>().freezeRotation = true;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //������
            other.GetComponent<Tree>().OnPick();
        }
    }
    //ͬ��
    private void OnTriggerStay(Collider other)
    {
        
        if (other.name == targetTreeName && !_isOn && !_isSelected)
        {
            _isOn = true;
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            transform.GetComponent<Rigidbody>().freezeRotation = true;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
            other.GetComponent<Tree>().OnPick();
        }
    }
    bool _isSelected;
    //��ʰȡ��ָ��������ԣ���Ϊ������ʱ������
    public void OnSelected(SelectEnterEventArgs args)
    {
        _isSelected = true;
        transform.GetComponent<Rigidbody>().freezeRotation = false;
        transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
    }
    public void OnUnselected(SelectExitEventArgs args)
    {
        _isSelected = false;
    }
    //�뿪��ʱ
    private void OnTriggerExit(Collider other)
    {
        
        if(other.name == targetTreeName && _isOn)
        {
            //������
            other.GetComponent<Tree>().OnLost();
            _isOn = false;
        }
    }


}
