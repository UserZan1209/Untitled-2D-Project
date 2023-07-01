using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyOnLoad : MonoBehaviour
{
    [HideInInspector] public string objectId;

    public void Awake()
    {
        objectId = name + transform.position.ToString() + transform.eulerAngles.ToString();
    }
    void Start()
    {
        for(int i = 0; i < Object.FindObjectsOfType<dontDestroyOnLoad>().Length; i++)
        {
            if (Object.FindObjectsOfType<dontDestroyOnLoad>()[i] != this)
            {
                if(Object.FindObjectsOfType<dontDestroyOnLoad>()[i].objectId == objectId)
                {
                    Destroy(gameObject);
                }
            }
        }

        DontDestroyOnLoad(gameObject);
    }


}
