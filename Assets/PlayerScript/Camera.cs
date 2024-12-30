using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Follow_player : MonoBehaviour {

    public Transform player;
    public float sensitivity = 1.0f;
    // Update is called once per frame
    void Update () {
        float rotH = Input.GetAxis("Mouse X");
        float rotV = Input.GetAxis("Mouse Y");
        
        transform.position = player.transform.position + new Vector3(0, 0, 0);
        transform.RotateAround (Vector3.zero, transform.right, -rotV * sensitivity);
        transform.RotateAround (player.transform.position, -Vector3.up, -rotH * sensitivity);
    }
}

