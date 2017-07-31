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
   

    public void ShowCoinSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_coin_sparkle, pos, Quaternion.identity);
    }

    public void ShowBulletSparkle(Vector3 pos)
    {
        Instantiate(sfx.sfx_bullet_sparkle, pos, Quaternion.identity);
    }

    public void ShowPlayerDustEffect(Vector3 pos)
    {
        Instantiate(sfx.sfx_player_lands, pos, Quaternion.identity);
    }

    public void ShowSplashEffect(Vector3 pos)
    {
        Instantiate(sfx.sfx_water_splash, pos, Quaternion.identity);
    }

    public void HandleBoxBreaking(Vector3 pos)
    {

        Vector3 pos1 = pos;
        pos1.x -= 0.3f;

        Vector3 pos2 = pos;
        pos2.x += 0.3f;

        Vector3 pos3 = pos;
        pos3.x -= 0.3f;
        pos3.y -= 0.3f;

        Vector3 pos4 = pos;
        pos4.x += 0.3f;
        pos4.y += 0.3f;

        Instantiate(sfx.sfx_fragment1, pos1, Quaternion.identity);
        Instantiate(sfx.sfx_fragment2, pos2, Quaternion.identity);
        Instantiate(sfx.sfx_fragment2, pos3, Quaternion.identity);
        Instantiate(sfx.sfx_fragment1, pos4, Quaternion.identity);
    }
}
