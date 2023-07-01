using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScripts : MonoBehaviour
{
    [SerializeField] public Camera mainCameraRef;
    [SerializeField] public GameObject playerRef;

    // Update is called once per frame
    private void Awake()
    {
        mainCameraRef = GetComponent<Camera>();
        playerRef = getPlayerRef();
    }
    void Update()
    {
        if(playerRef != null)
        {
            moveCamera(playerRef.transform.position);
        }
        else
        {
            playerRef = getPlayerRef();
        }
    }

    private GameObject getPlayerRef()
    {
        GameObject player;
        player = GameObject.FindGameObjectWithTag("Player");
        return player.transform.GetChild(0).gameObject;
    }

    private void moveCamera(Vector2 targetPos)
    {
        Vector3 target;
        target = new Vector3(targetPos.x, targetPos.y, transform.position.z);

        mainCameraRef.transform.position = target;
    }
}
