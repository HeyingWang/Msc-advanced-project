using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boxophobic.StyledGUI;
[ExecuteAlways]
public class SkyboxChange : MonoBehaviour
{
    //两个天空盒
    public Material skyboxDay;
    public Material skyboxNight;



    public void ChangeDay(float value)
    {
        //两个盒融合
        Material m = new Material(skyboxDay);
        m.Lerp(skyboxDay, skyboxNight, value);
        //应用
        RenderSettings.skybox = m;
    }
 

}
