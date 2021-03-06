﻿using System.Collections;
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

    public Texture[] cam;

    public RawImage player1;
    public RawImage player2;
    public RawImage player3;
    public RawImage player4;

    public static int players;

    [SerializeField]
    private bool setstats = true;
    [SerializeField]
    private bool inlevel = false;
    // Use this for initialization
    public void LoadByIndex(int sceneIndex)
    {
        
        Time.timeScale = 1.0f;
        inlevel = true;
        SceneManager.LoadScene(sceneIndex);     
    }


    void Update()
    {
        int p1 = class1.value;
        int p2 = class2.value;
        int p3 = class3.value;
        int p4 = class4.value;

        player1.texture = cam[p1];
        player2.texture = cam[p2];
        player3.texture = cam[p3];
        player4.texture = cam[p4];

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
            classval2 = class2.value;
            classval3 = class3.value;
            classval4 = class4.value;

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
