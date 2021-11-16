using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    //控制的AudioSource（播放器）
    public AudioSource[] targetSources;
    //每个树块改变的音量
    public float changeValue;
    //改变天空和的脚本
    public SkyboxChange change;
    //飞机
    public GameObject planes;

    //放到树上后
    public void OnPick()
    {
        //音量增加
        foreach (var v in targetSources)
        {
            v.volume += changeValue;
        }
        //如果加满了，飞机启动
        if (targetSources[0].volume >= 0.9f)
            if (planes != null)
                planes.SetActive(true);
        //如果控制天空盒，则改变值
        if (change != null)
            change.ChangeDay(targetSources[0].volume);


    }
    //从树上下来
    public void OnLost()
    {
        //音量降低
        foreach (var v in targetSources)
        {
            v.volume -= changeValue;
        }

        //改变天空
        if (change != null)
            change.ChangeDay(targetSources[0].volume);
    }

}
