using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMill : MonoBehaviour
{
    //��ת�ٶ�
    public float speed;
   
    private void Update()
    {
        //ÿ֡����������ת
        transform.Rotate(transform.right, Time.deltaTime * speed,Space.World);
    }
}
