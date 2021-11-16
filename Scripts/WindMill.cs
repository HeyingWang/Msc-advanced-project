using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    //旋转速度
    public float speed;
   
    private void Update()
    {
        //每帧世界坐标旋转
        transform.Rotate(transform.right, Time.deltaTime * speed,Space.World);
    }
}
