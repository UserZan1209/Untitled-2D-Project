using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mouse_Projectiles : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject TargetObject;
    [SerializeField] public float rotSpeed;
    [SerializeField] public GameObject projectile;
    [SerializeField] private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame 
    void Update()
    {
        setRotation();
    }

    private void setRotation()
    {
        Quaternion rot = Quaternion.LookRotation(Vector3.forward, mousePos);
        TargetObject.transform.rotation = Quaternion.RotateTowards(player.transform.rotation, rot, 360);
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void setTargetPosition()
    {
      
        GameObject proj = Instantiate(projectile, mousePos, TargetObject.transform.rotation);
        proj.GetComponent<Projectile>().mousePos = mousePos;
    }

    public void instantiateProjectile()
    {
        setTargetPosition();
    }
}
