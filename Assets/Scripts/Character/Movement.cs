using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] public int moveSpeed;
    [SerializeField] public bool canMove;
    public bool isFacingRight = true;

    [HideInInspector] private SpriteRenderer mySPRRen;
    [HideInInspector] private characterStatSystem pStatSys;
    [HideInInspector] private playerAnimationContrroller pAnimContrroller;
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
        pStatSys = GetComponent<characterStatSystem>();
        pAnimContrroller = GetComponent<playerAnimationContrroller>();
        
    }

    void FixedUpdate()
    {
        if (canMove) { InputMovement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); }

        if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) 
        {
            float h = Input.GetAxis("Horizontal");
            pStatSys.isMoving = true;


            if(h < 0.01f && isFacingRight == true)
            {
                FlipX();
            }
            if(h > -0.01f && isFacingRight == false)
            {
                FlipX();
            }


        }
        else
        {
            pStatSys.isMoving = false;
        }
    }

    private void FlipX()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private void InputMovement(float x, float y)
    {
        Vector2 targetVector;
        targetVector = new Vector2(x, y);
        transform.Translate(targetVector * Time.deltaTime * moveSpeed);
    }
}
