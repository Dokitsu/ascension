using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {
    private enum turn {Start,Movement,Action,End}
    [SerializeField]
    private turn currentphase = turn.Start;
    public List<GameObject> players;
    [SerializeField]
    private List<GameObject> Enemies;
    [SerializeField]
    private int phasenumber = 0;
    private int turns = 2;
    [SerializeField]
    private GameObject currentplayer;
    private Image[] die = new Image[5];
    public GameObject menu;
    


	// Use this for initialization
	void Start ()
    {
        currentplayer = players[0];
	}
	
	// Update is called once per frame
	void Update ()
    {
        //currHP = currentplayer.
        //UpdateHealth();
    }

    public void endplayerturn()
    {
        turns = 2;
        phasenumber++;
        if (phasenumber - 4 > Enemies.Capacity)
        {
            phasenumber = 0;
            currentplayer = players[phasenumber];
        }
        else
        {
            if (phasenumber < 4)
            {
                currentplayer = players[phasenumber];

            }
            if (phasenumber >= 4)
            {
                currentplayer = Enemies[phasenumber - 4];

            }
        }
        
    }
    

    public void changephase()
    {
        if (turns > 0)
        {
            turns--;
            if (turns == 0)
            {
                endplayerturn();
            }
        }
        else
        {
            endplayerturn();
        }

    }
    public void moveunit()
    {
        menu.SetActive(false);
        currentplayer.GetComponent<Move>().onactivate();
        currentplayer.GetComponent<Move>().active = true;
    }

    public void unitattack()
    {
        menu.SetActive(false);
        //currentplayer.getcomponent<attack>().active = true;
    }
    public void rest()
    {
        currentplayer.GetComponent<UnitInformation>().rest();
        changephase();
    }



}
