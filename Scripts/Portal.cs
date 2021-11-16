using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    //下一个场景的名字
    public string nextSceneName;
    private void OnTriggerEnter(Collider other)
    {
        //如果碰到玩家
        if(other.CompareTag("Player"))
        {
            //加载场景
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
