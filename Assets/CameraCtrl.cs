using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour {


    public Transform player;
    private float yOffset;

    private void Start()
    {
        yOffset = transform.position.y - player.position.y;
    }

    void Update () {
        // transform.position = new Vector3(player.transform.position.x, player.position.y + yOffset, transform.position.z);

        transform.position = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
    }
}
