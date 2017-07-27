using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCtrl : MonoBehaviour {

	public enum CoinFX
    {
        Vanish,
        Fly
    }

    public CoinFX coinFx;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (coinFx == CoinFX.Vanish)
                Destroy(gameObject);
        }
    }
}
