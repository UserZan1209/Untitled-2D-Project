using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class sceneChangeObject : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.transform.parent.tag == "Player") 
        {
            SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
        }
    }
}
