using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Dropdown nplayers;
    public static int players;

    // Use this for initialization
    public void LoadByIndex(int sceneIndex)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneIndex);     
    }


    void Update()
    { 
        players = nplayers.value + 1;
        Debug.Log(players);
    }


}
