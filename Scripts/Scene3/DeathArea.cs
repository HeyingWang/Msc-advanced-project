using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DeathArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //����������¼��س���
        if(collision.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
