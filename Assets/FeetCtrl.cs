using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {

    public GameObject player;
    public Transform dustPos;
    private PlayerCtrl playerCtrl;

    private void Start()
    {
        playerCtrl = gameObject.transform.parent.gameObject.GetComponent<PlayerCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GROUND"))
        {
            SfxController.instance.ShowPlayerDustEffect(dustPos.position);

            playerCtrl.isJumping = false;
        }

        if (other.gameObject.CompareTag("Platform"))
        {
            SfxController.instance.ShowPlayerDustEffect(dustPos.position);

            playerCtrl.isJumping = false;

            player.transform.parent = other.gameObject.transform;
            Debug.Log("trigger");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("trigger exit");
            player.transform.parent = null;
        }
    }
}
