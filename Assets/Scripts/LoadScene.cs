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

    public bool setstats = true;
    public bool inlevel = false;
    // Use this for initialization
    public void LoadByIndex(int sceneIndex)
    {
        
        Time.timeScale = 1.0f;
        inlevel = true;
        SceneManager.LoadScene(sceneIndex);     
    }


    public void uncheckplayers()
    {
        if (players < 2)
        {
            GameObject.Find("Player2").SetActive(false);
        }
        if (players < 3)
        {
            GameObject.Find("Player3").SetActive(false);
        }
        if (players < 4)
        {
            GameObject.Find("Player4").SetActive(false);
        }

        StartCoroutine(setplayers());

    }
    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }
    void LateUpdate()
    {
        if (inlevel == false)
        {
            classval1 = class1.value;


            players = nplayers.value + 1;

        }
        else
        {
            if (setstats == true)
            {
                Invoke("uncheckplayers", 2);
            }


        }


    }

    private IEnumerator setplayers()
    {
        print("players");
        for (int i = 0; i < players; i++)
        {
            GameObject.Find("Player" + i).name = i.ToString();
        }
        setstats = false;
        
        return null;
    }


}
