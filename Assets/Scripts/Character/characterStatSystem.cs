using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterStatSystem : MonoBehaviour
{
    //*
    //
    // This script manages the stat system for character objects that involve combat
    //
    // Contains Health, Stamina, Energy
    //
    //
    //*//
    #region References

    //Component refs
    [SerializeField] public GameObject characterObject;
    [SerializeField] public Rigidbody2D myRb;
    [SerializeField] public Animator myAnim;
    #endregion

    private void Start()
    {
        InitObject();
    }

    private void InitObject()
    {
        characterObject = transform.GetChild(0).gameObject;
        myRb = characterObject.GetComponent<Rigidbody2D>();
        myAnim = characterObject.GetComponent<Animator>();

    }

    #region Stat System

    [SerializeField] private int STAT_health = 10;
    [SerializeField] private int STAT_Stamina;
    [SerializeField] private int STAT_Energy;

    [SerializeField] private int STAT_attackDamage = 5;
    [SerializeField] private int STAT_magicDamage = 5;



    #region Health Functions
    public void takeHealth(int healthModifyer)
    {
        STAT_health -= healthModifyer;
        Debug.Log("Health decreased: " + healthModifyer);
    }

    public void gainHealth(int healthModifyer)
    {
        STAT_health += healthModifyer;
    }

    public int returnHealthValue()
    {
        return STAT_health;
    }

    public int returnAttackValue()
    {
        return STAT_attackDamage;
    }
    public int returnMAttackValue()
    {
        return STAT_magicDamage;
    }
    #endregion

    #endregion

    private void Update()
    {

    }

    public Vector2 returnCharacterPosition()
    {
        return characterObject.transform.position;
    }

    public void damageTarget(GameObject gO, GameObject target)
    {
        target.GetComponent<characterStatSystem>().takeHealth(gO.GetComponent<characterStatSystem>().returnAttackValue());
    }
}
