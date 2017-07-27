using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileUICtrl : MonoBehaviour {

    public GameObject player;

    private PlayerCtrl playerCtrl;

    private void Start()
    {
        playerCtrl = player.GetComponent<PlayerCtrl>();
    }

    public void MobileMoveLeft()
    {
        playerCtrl.MobileMoveLeft();
    }

    public void MobileMoveRight()
    {
        playerCtrl.MobileMoveRight();
    }

    public void MobileMoveStop()
    {
        playerCtrl.MobileMoveStop();
    }

    public void MobileFireBullets()
    {
        playerCtrl.MobileFireBullets();
    }

    public void MobileJump()
    {
        playerCtrl.MobileJump();
    }
}
