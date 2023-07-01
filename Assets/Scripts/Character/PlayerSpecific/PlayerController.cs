using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region keyBindings
    [Header("Key Bindings")]
    [SerializeField] private KeyCode KEY_Attack;
    [SerializeField] private KeyCode KEY_Block;
    [SerializeField] private KeyCode KEY_Parry;
    [SerializeField] private KeyCode KEY_Projectile;
    [SerializeField] private KeyCode KEY_Ulltimate;
    [SerializeField] private KeyCode KEY_Inventory;
    #endregion
    
    #region Script references
    [Header("Script references")]
    [HideInInspector] private characterStatSystem myStatSYS;
    [HideInInspector] private Movement myMovement;
    [HideInInspector] private Mouse_Projectiles projectileSYS;
    [SerializeField] private playerInventroyController inventoryController;
    [SerializeField] public inventoryOject Inventory;
    [SerializeField] private subClassManager playerClassSYS;
    [SerializeField] private PlayerUI myUI;
    #endregion

    #region Behaviour variables
    [Header("Controller bools")]
    [SerializeField] private int defMoveSpeed = 10;
    [SerializeField] private bool isDead;
    [SerializeField] private bool canattack = true;
    [SerializeField] private bool isAttacking = false;
    [SerializeField] private bool isBlocking = false;

    [Header("Runtime References")]
    [SerializeField] public GameObject TEMP_target;
    #endregion

    void Awake()
    {
        #region getReferences
        initPlayerController();
        #endregion
    }

    void Update()
    {
        playerController();
    }

    private void initPlayerController()
    {
        inventoryController = FindObjectOfType<playerInventroyController>();
        myUI = GameObject.FindGameObjectWithTag("UI").GetComponent<PlayerUI>();

        myStatSYS = GetComponent<characterStatSystem>();
        projectileSYS = GetComponent<Mouse_Projectiles>();

        #region attach components
        myMovement = gameObject.AddComponent<Movement>();
        myMovement.canMove = true;
        myMovement.moveSpeed = defMoveSpeed;

        playerClassSYS = gameObject.AddComponent<subClassManager>();
        playerClassSYS.mySubClass = subClasses.Motion;
        #endregion
    }

    private void playerController()
    {

        #region healthManager
        if (myStatSYS.returnHealthValue() <= 0)
        {
            myMovement.canMove = false;
            isDead = true;
        }
        else if (isDead)
        {
            myStatSYS.myAnim.SetBool("isDead", true);
        }
        #endregion

        #region inputSystem
        if (Input.GetKeyDown(KEY_Attack))
        {
            attack();
        }
        else if (Input.GetKeyDown(KEY_Parry))
        {
            parry();
        }
        else if (Input.GetKeyDown(KEY_Projectile))
        {
            projectile();
        }
        else if (Input.GetKeyUp(KEY_Ulltimate))
        {
            ability();
        }
        else if (Input.GetKeyUp(KEY_Inventory))
        {
            toggleInventory();
        }
        else if (Input.GetKeyDown(KEY_Block))
        {
            block();
        }
        else if (Input.GetKeyUp(KEY_Block))
        {
            isBlocking = false;
            myStatSYS.myAnim.SetBool("holdBlocking", false);
        }

        #region DEBUG INPUTS
        //debug
        if (Input.GetKeyUp(KeyCode.U))
        {
            Inventory.clearInventory();
        }
        if (Input.GetKeyUp(KeyCode.Y))
        {
            myStatSYS.takeHealth(1);
            myUI.updateHealthUI(myStatSYS.returnHealthValue());
        }
        #endregion

        #endregion
    }

    private void setKeyboardBindings()
    {
        //Incomplete
    }

    #region inputActions
    private void attack()
    {
        Debug.Log("Attacking");
        myStatSYS.myAnim.SetTrigger("isAttacking");

        if (TEMP_target != null)
        {
            TEMP_target.GetComponent<characterStatSystem>().damageTarget(gameObject, TEMP_target);

        }

    }

    private void parry()
    {
        Debug.Log("Parrying");
        myStatSYS.myAnim.SetTrigger("isParrying");
    }

    private void block()
    {
        isBlocking = true;
        myStatSYS.myAnim.SetTrigger("isBlocking");
        if (isBlocking)
        {
            myStatSYS.myAnim.SetBool("holdBlocking", true);

        }
    }

    private void projectile()
    {
        Debug.Log("Projectile");
        myStatSYS.myAnim.SetTrigger("fireProjectile");
        projectileSYS.instantiateProjectile();
    }

    private void ability()
    {
        playerClassSYS.toggleAbibility();
    }

    private void toggleInventory()
    {
        inventoryController.toggleInventory();
    }
    #endregion

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myStatSYS.myRb.velocity = Vector2.zero; // useless until movement is updated
    }
}
