using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quickMenu : MonoBehaviour
{
    [SerializeField] private GameObject quickMenuObject;
    // Start is called before the first frame update
    void Start()
    {
        quickMenuObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //save
    //load

    public void Quit()
    {
        Application.Quit();
    }
}
