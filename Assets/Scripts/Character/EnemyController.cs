using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Script refs
    [HideInInspector] private characterStatSystem myStatSYS;
    [HideInInspector] private EnemyMovement myMovement;

    [SerializeField] private GameObject itemPrefab;
    [HideInInspector] private bool hasDroppedItem = false;

    //drops
    [SerializeField] private Item syringe;
    // Start is called before the first frame update
    void Start()
    {
        myStatSYS = GetComponent<characterStatSystem>();
        myMovement = transform.GetChild(0).gameObject.GetComponent<EnemyMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        checkHealth();
    }

    private void checkHealth()
    {
        if(myStatSYS.returnHealthValue() <= 0 && hasDroppedItem != true)
        {
            transform.GetChild(0).gameObject.SetActive(false);

            myMovement.canMove = false;
            generateItem();

            hasDroppedItem = true;
        }
    }

    private void generateItem()
    {
        GameObject pref = GameObject.Instantiate(syringe.prefabGameObject, transform.GetChild(0).gameObject.transform.position, Quaternion.identity) ;
        pref.GetComponent<itemObject>().item = syringe;
    }
}
