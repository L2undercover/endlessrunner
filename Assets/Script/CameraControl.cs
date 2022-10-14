using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    //Create a public reffrence to the player - we will assign this using the Unity editor
    public GameObject player;

    void Update()
    {
        //Change our position relattive to the players position
        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    } 
}
