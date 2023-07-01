using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public int moveSpeed;
    [SerializeField] public bool canMove;

    [HideInInspector] private SpriteRenderer mySPRRen;
    // Update is called once per frame
    //*
    //
    //  Create static player amimation object
    // https://www.youtube.com/watch?v=SDfEytEjb5o - nav mesh movement
    //
    //  Flip sprite based on input

    //*//

    private void Start()
    {
        mySPRRen = transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        if (canMove) { InputMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }
    }

    private void InputMovement(float x, float y)
    {
        if(x < 0)
        {
            //mySPRRen.flipX = true;
        }
        else if(x > 0)
        {
            //mySPRRen.flipX = false;
        }

        Vector2 targetVector;
        targetVector = new Vector2(x, y);
        transform.Translate(targetVector * Time.deltaTime * moveSpeed);
    }
}
