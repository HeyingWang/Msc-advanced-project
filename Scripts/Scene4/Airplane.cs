using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BansheeGz.BGSpline.Curve;
public class Airplane : MonoBehaviour
{
    public GameObject[] curve;

    public TextControl control;
    int boneNumber;
    //如果两个骨头都被拾起来，则播放动画
    public void OnPickBone()
    {
        boneNumber++;
        if(boneNumber >=2)
        {
            foreach(var v in curve)
            {
                v.SetActive(true);
            }

            control.Show();


        }
    }
}
