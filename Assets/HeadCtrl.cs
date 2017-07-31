using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCtrl : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Breakable"))
        {
            SfxController.instance.HandleBoxBreaking(other.gameObject.transform.parent.transform.position);

            //cat's velocity to zero
            gameObject.transform.parent.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

            Destroy(other.gameObject.transform.parent.gameObject);
        }
    }

}
