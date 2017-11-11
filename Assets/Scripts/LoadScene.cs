using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Dropdown nplayers;

    public Dropdown class1;
    public Dropdown class2;
    public Dropdown class3;
    public Dropdown class4;

    public static int classval1;
    public static int classval2;
    public static int classval3;
    public static int classval4;


    public static int players;

    // Use this for initialization
    public void LoadByIndex(int sceneIndex)
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(sceneIndex);     
    }


    void Update()
    {
        classval1 = class1.value;
        Debug.Log(classval1);


        players = nplayers.value + 1;
        Debug.Log(players);


    }


}
