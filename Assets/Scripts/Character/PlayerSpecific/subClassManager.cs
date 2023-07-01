using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#region subclass types
public enum subClasses
{
    Motion, 
    Cryostasis, 
    Phantom
};
#endregion

public class subClassManager : MonoBehaviour
{
    [SerializeField] public subClasses mySubClass;
    
    [HideInInspector] private ABILITY_Motion abilityMotion;
    [HideInInspector] private SpriteRenderer sprRen;

    // Start is called before the first frame update
    void Start()
    {
        sprRen = GetComponent<SpriteRenderer>();

        abilityMotion = gameObject.AddComponent<ABILITY_Motion>();
        mySubClass = subClasses.Motion;

        switch (mySubClass)
        {
            case subClasses.Motion:
                break;
            default:
                Debug.Log("no ability");
                break;
        }

    }

    //toggle select class
    public void toggleAbibility()
    {
        Debug.Log("Toggle");

        switch (mySubClass)
        {
            case subClasses.Motion:
                abilityMotion.isActive = !abilityMotion.isActive;
                Debug.Log("Toggle motion");
                break;
        }
    }
}
