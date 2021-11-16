using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //碰到玩家重新加载场景
        if(collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
