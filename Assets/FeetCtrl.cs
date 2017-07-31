using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetCtrl : MonoBehaviour {

    public Transform dustPos;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GROUND"))
        {
            SfxController.instance.ShowPlayerDustEffect(dustPos.position);
        }
    }
}
