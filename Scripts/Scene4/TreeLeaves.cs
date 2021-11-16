using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TreeLeaves : MonoBehaviour
{
    //树块
    public Transform targetPosition;
    //对应树的名字
    public string targetTreeName;
    //一开始是否在树上
    public bool initOn;
    //是否在树上
    bool _isOn;
    private void Start()
    {
        
        _isOn = initOn;
        //手柄抓到后触发OnSelected
        GetComponent<XRGrabInteractable>().selectEntered.AddListener(OnSelected);
        //手柄松开后触发OnUnselected
        GetComponent<XRGrabInteractable>().selectExited.AddListener(OnUnselected);
    }



    
    private void OnTriggerEnter(Collider other)
    {
        //碰到的是对的树，且没有在树上，且没有被玩家抓着，就上树
        if(other.name == targetTreeName && !_isOn && !_isSelected)
        {
            //设置位置，固定位置
            _isOn = true;
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
            transform.GetComponent<Rigidbody>().freezeRotation = true;
            transform.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            //告诉树
            other.GetComponent<Tree>().OnPick();
        }
    }
    //同上
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
    //被拾取后恢复刚体属性，因为在树上时禁用了
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
    //离开树时
    private void OnTriggerExit(Collider other)
    {
        
        if(other.name == targetTreeName && _isOn)
        {
            //告诉树
            other.GetComponent<Tree>().OnLost();
            _isOn = false;
        }
    }


}
