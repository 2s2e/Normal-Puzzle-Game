using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteHallWay : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement playerMovement;
    public PortalTeleporter portal;
    void Update()
    {
        playerMovement = player.GetComponent<PlayerMovement>();
        if(!playerMovement.isRunning) {
            portal.enabled = false;
            Debug.Log("isn't moving");
        } else {
            portal.enabled = true;
            Debug.Log("is moving");
        }
    }
}
