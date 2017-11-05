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

    public GameObject Playercam;
    public Vector3 playerpos;


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

        currentplayer.GetComponent<Light>().enabled = true;
        playerpos = currentplayer.transform.position;
        Playercam.transform.position = new Vector3(playerpos.x, 60, playerpos.z-50);
    }

    public void endplayerturn()
    {
        turns = 2;
        phasenumber++;
        currentplayer.GetComponent<Light>().enabled = false;
        if (phasenumber > players.Capacity + Enemies.Capacity-1) 
        {
            print("New rotation");
            phasenumber = 0;
            currentplayer = players[phasenumber];
        }
        else
        {
            if (phasenumber < players.Capacity)
            {
                print("Player's turn " + phasenumber);
                currentplayer = players[phasenumber];

            }
            if (phasenumber >= players.Capacity)
            {
                print("Enemy's turn " + phasenumber);
                currentplayer = Enemies[phasenumber - players.Capacity];

            }
        }
        
    }
    
    public void removingenemy(UnitInformation me)
    {

        foreach(GameObject enemy in Enemies)
        {
            if (enemy.name == me.gameObject.name)
            {
                Enemies.Remove(enemy);
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

    public void settingupattack()
    {

    }

    public void unitattack()
    {
        menu.SetActive(false);
        currentplayer.GetComponent<AttackScript>().onactivate();
        currentplayer.GetComponent<AttackScript>().active = true;
    }
    public void rest()
    {
        currentplayer.GetComponent<UnitInformation>().rest();
        changephase();
    }


}
