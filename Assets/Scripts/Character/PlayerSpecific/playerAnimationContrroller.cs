using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnimationContrroller : MonoBehaviour
{
    [SerializeField] public Animator playerAnimator;
    [HideInInspector] private characterStatSystem pStatSys;
    // Start is called before the first frame update
    void Start()
    {
        pStatSys = transform.parent.GetComponent<characterStatSystem>();    

        playerAnimator = GetComponent<Animator>();
        pStatSys.myAnim = playerAnimator;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            pStatSys.myAnim.SetBool("isMoving", !pStatSys.myAnim.GetBool("isMoving"));
        }
    }
}
