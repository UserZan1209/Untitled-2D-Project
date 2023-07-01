using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radiusExplosive : MonoBehaviour
{
    [HideInInspector] private CircleCollider2D myTrigger;
    [HideInInspector] private SpriteRenderer sprRen;

    [SerializeField] public int blastRadius = 4;
    [SerializeField] public float fallSpeed = 1;
    [SerializeField] public Vector3 fallVector;
    // Start is called before the first frame update
    void Start()
    {
        myTrigger = GetComponent<CircleCollider2D>();
        sprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void increaseTriggerRadius()
    {
        myTrigger.radius = blastRadius;
        sprRen.color = Color.red;
    }

    //to be called from the drone script
    public void dropBomb()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y , transform.position.z);
        newPos = newPos -= fallVector; 

        if(transform.position != newPos)
        {
            transform.Translate(newPos * fallSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            increaseTriggerRadius();
            dropBomb();
            Debug.Log("boom..");
        }
    }
}
