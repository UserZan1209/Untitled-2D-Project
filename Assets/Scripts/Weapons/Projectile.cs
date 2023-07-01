using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [HideInInspector] public Vector2 mousePos;
    [HideInInspector] private int projecileForce = 25;
    [HideInInspector] private Rigidbody2D myRb;
    // Start is called before the first frame update
    void Start()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(mousePos.x, mousePos.y, 1) * Time.deltaTime * projecileForce);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.transform.GetComponentInParent<characterStatSystem>().takeHealth(1); 
            Destroy(gameObject);
        }
    }
}
