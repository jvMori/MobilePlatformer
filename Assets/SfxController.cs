using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxController : MonoBehaviour {

    public static SfxController instance;

    public SFX sfx;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
   

    public void ShowSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_sparkle, pos, Quaternion.identity);
    }
}
