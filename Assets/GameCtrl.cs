using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameCtrl : MonoBehaviour {

    public static GameCtrl instance;
    public float restartDelay;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    /// <summary>
    /// restarts the level when player dies
    /// </summary>
    public void PlayerDied(GameObject player)
    {
        player.SetActive(false);
       
        Invoke("RestartLevel", restartDelay);
    }

    /// <summary>
    /// restarts the level when player falls into the water
    /// </summary>
    public void PlayerDrowned(GameObject player)
    {       
        Invoke("RestartLevel", restartDelay);
    }

    void RestartLevel()
    {
        SceneManager.LoadScene("Gameplay");
    }
}
