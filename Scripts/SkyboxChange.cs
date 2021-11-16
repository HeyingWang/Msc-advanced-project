using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Boxophobic.StyledGUI;
[ExecuteAlways]
public class SkyboxChange : MonoBehaviour
{
    //������պ�
    public Material skyboxDay;
    public Material skyboxNight;



    public void ChangeDay(float value)
    {
        //�������ں�
        Material m = new Material(skyboxDay);
        m.Lerp(skyboxDay, skyboxNight, value);
        //Ӧ��
        RenderSettings.skybox = m;
    }
 

}
