using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABILITY_Motion : MonoBehaviour
{
    [SerializeField] private GameObject objectReferece;

    [SerializeField] public bool isActive = false;
    [SerializeField] public int initialSpeed;
    // Start is called before the first frame update
    void Start()
    {
        objectReferece = gameObject.transform.GetChild(0).gameObject;
        Debug.Log("Motion Gained. Parent object: "+ objectReferece.name);

        initialSpeed = GetComponent<Movement>().moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (isActive)
        {
            GetComponent<Movement>().moveSpeed = initialSpeed * 3;
            //pass input to switch animations on player
        }
        else
        {
            GetComponent<Movement>().moveSpeed = initialSpeed;
        }
    }

}
