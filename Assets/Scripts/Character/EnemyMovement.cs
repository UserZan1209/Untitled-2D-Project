using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 targetPos;
    [SerializeField] private SpriteRenderer sprRen;

    [SerializeField] private int moveSpeed;
    [SerializeField] private int detectionDistance = 10;

    [SerializeField] public bool canMove = false;


    // Start is called before the first frame update
    void Start()
    {
       sprRen = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canMove)
        {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);

            flipX();
        }
    }

    private void flipX()
    {
        if (transform.position.x < player.transform.position.x)
        {
            sprRen.flipX = false;
        }
        else if(transform.position.x > player.transform.position.x)
        {
            sprRen.flipX = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player = collision.gameObject;

            resetPlayerPosition();
            canMove = true; // enter

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player" && canMove == true)
        {
            toggleCanMove();
        }
    }

    private void resetPlayerPosition()
    {
        // make a function on player controller to fetch position of the player

        targetPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Debug.Log("TargetPos");
    }

    private void toggleCanMove()
    {
        canMove = !canMove;
    }

}
