using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCollision : MonoBehaviour
{
    [HideInInspector] private GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
        parent = transform.parent.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            sendTargetToController(collision.gameObject);
        }
    }

    private void sendTargetToController(GameObject t)
    {
        parent.GetComponent<PlayerController>().TEMP_target = t.transform.parent.gameObject;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.transform.parent.gameObject.tag == "Player") 
        {
            Debug.Log("SceneChanges");
        }*/
    }

}
