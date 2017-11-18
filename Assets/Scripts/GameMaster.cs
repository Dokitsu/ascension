using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class GameMaster : MonoBehaviour {
    private enum turn {Start,Movement,Action,End}
    [SerializeField]
    private turn currentphase = turn.Start;
    public List<GameObject> players;
    [SerializeField]
    public List<GameObject> Enemies;
    [SerializeField]

    private int phasenumber = 0;
    private int turns = 2;
    [SerializeField]
    private GameObject currentplayer;
    private Image[] die = new Image[5];

    public GameObject menu;
    public GameObject emenu;

    public bool playersturn;

    public GameObject Playercam;
    public Vector3 playerpos;

    public Gate Key;
    public GameObject Gate;


    //Game classes
    public GameObject tank;
    public GameObject ranger;
    public GameObject healer;

    //Game Enemies
    public GameObject Zomb;

    public Vector3[] spawnlocation;
    public Vector3[] Espawnlocation;

    //for SQL
    private string link;


    /// <summary>
    /// Used to handle the games turn system
    /// Is boss alive?
    /// no (Unlock Gate)
    /// all enemies dead?
    /// auto win
    /// </summary>

        //this will pull the first class
    //SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 0;

    void Start()
    {
        link = "URI=file:" + Application.dataPath + "/Plugins/Descent.sqlite";
        Debug.Log(link);
        IDbConnection database;
        database = (IDbConnection)new SqliteConnection(link);
        database.Open();

        //using (IDbCommand read = database.CreateCommand())
        //{
        //    string sqlque = "SELECT * FROM Class";
        //    read.CommandText = sqlque;
        //    using (IDataReader reader = read.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            //Debug.Log(reader.GetString(0));
        //        }
        //        database.Close();
        //        reader.Close();
        //    }
        //}

        players.Capacity = LoadScene.players;
        Enemies.Capacity = LoadScene.players + 1;

        ///Spawns players and enemies based on selections on the title scene
        for (int i = 0; i < LoadScene.players; i ++)
        {
            GameObject playerset;
            GameObject Eset;

            Debug.Log("player in " + (i + 1));

            // 
            // GM sets spawn point for enemies
            //
            Enemies.Add(Instantiate(Eset = Zomb, Espawnlocation[i], Quaternion.identity));


            //players.Add(GameObject.Find("Player" + (i + 1)));
            if (LoadScene.classval1 == 0)
            {
                players.Add(playerset = Instantiate(tank, spawnlocation[i], Quaternion.identity));
                //// copy this
                using (IDbCommand read = database.CreateCommand())
                {
                    string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 0"; // change the offset for different characters
                    read.CommandText = sqlque;
                    using (IDataReader reader = read.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            playerset.GetComponent<UnitInformation>().myname = reader.GetString(0);
                            playerset.GetComponent<UnitInformation>().maxHP = reader.GetInt16(1);
                            playerset.GetComponent<UnitInformation>().currHP = reader.GetInt16(1);
                            playerset.GetComponent<UnitInformation>().range = reader.GetBoolean(2);
                            playerset.GetComponent<UnitInformation>().truemovement = reader.GetInt32(3);
                        }
                        database.Close();
                        reader.Close();
                    }
                }
                //// 
            }
            if (LoadScene.classval1 == 1)
            {
                players.Add(playerset = Instantiate(ranger, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 8;
                playerset.GetComponent<UnitInformation>().currHP = 8;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 5;
                playerset.GetComponent<UnitInformation>().myname = "Jain Fairwood";
            }
            if (LoadScene.classval1 == 2)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 12;
                playerset.GetComponent<UnitInformation>().currHP = 12;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 4;
                playerset.GetComponent<UnitInformation>().myname = "Avril Albright";
            }
            if (LoadScene.classval1 == 3)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 8;
                playerset.GetComponent<UnitInformation>().currHP = 8;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 4;
                playerset.GetComponent<UnitInformation>().myname = "Tomble Burrowell";
            }
            if (LoadScene.classval1 == 4)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 14;
                playerset.GetComponent<UnitInformation>().currHP = 14;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 3;
                playerset.GetComponent<UnitInformation>().myname = "Grisban the Thirsty";
            }
            if (LoadScene.classval1 == 5)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 10;
                playerset.GetComponent<UnitInformation>().currHP = 10;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 4;
                playerset.GetComponent<UnitInformation>().myname = "Widow Tarha";

            }
            if (LoadScene.classval1 == 6)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 8;
                playerset.GetComponent<UnitInformation>().currHP = 8;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 4;
                playerset.GetComponent<UnitInformation>().myname = "Leoric of the Book";
            }
            if (LoadScene.classval1 == 7)
            {
                players.Add(playerset = Instantiate(healer, spawnlocation[i], Quaternion.identity));
                playerset.GetComponent<UnitInformation>().maxHP = 10;
                playerset.GetComponent<UnitInformation>().currHP = 10;
                playerset.GetComponent<UnitInformation>().defense = 1;
                playerset.GetComponent<UnitInformation>().range = true;
                playerset.GetComponent<UnitInformation>().truemovement = 5;
                playerset.GetComponent<UnitInformation>().myname = "Ashrian";
            }
        }

        Enemies.Add(GameObject.Find("Boss"));

        currentplayer = players[0];
        playersturn = true;


    }
	

	void Update ()
    {
        // checks if the enemy has been defeated and will skip thier turn
        if (currentplayer == null)
        {
            phasenumber--;
            endplayerturn();
            Debug.Log("killed");
        }

        currentplayer.GetComponent<Light>().enabled = true;
        playerpos = currentplayer.transform.position;

        // player cam veiws the player on HUD
        Playercam.transform.position = new Vector3(playerpos.x, 60, playerpos.z-50);

    }

    public void endplayerturn()
    {
        turns = 2;
        phasenumber ++;
        if (currentplayer == null)
        {

        }
        else
        {
            currentplayer.GetComponent<Light>().enabled = false;
        }

        if (playersturn == false)
        {
            if (phasenumber >= Enemies.Capacity)
            {
                playersturn = true;
                phasenumber = 0;
            }
        }

        if (playersturn)
        {
            if (phasenumber >= players.Capacity)
            {
                playersturn = false;
                phasenumber = 0;
            }
        }

        if (playersturn)
        {
            currentplayer = players[phasenumber];
            if (currentplayer.GetComponent<UnitInformation>().alive == false)
            {
                Debug.Log("player incapacitated");
                endplayerturn();
            }
            currentplayer.GetComponent<UnitInformation>().UpdatePlayerHealthGUI();
        }

        if (playersturn == false)
        {
            currentplayer = Enemies[phasenumber];
            currentplayer.GetComponent<UnitInformation>().UpdatePlayerHealthGUI();
        }
    }

    public void removingenemy(UnitInformation me)
    {
        if (me.gameObject.name == "Boss")
        {
            Debug.Log("boss ded");
            Key = Gate.GetComponent<Gate>();
            Key.Opengate();
        }

        foreach (GameObject enemy in Enemies)
        {
            if (enemy.gameObject == me.gameObject)
            {
                Enemies.Remove(enemy);
                Enemies.Capacity = Enemies.Capacity --;
            }
        }

        if (Enemies.Capacity <= 0)
        {
            Debug.Log("win game");
            SceneManager.LoadScene("WinCondition");
        }
    }



    public void changephase()
    {
        emenu.SetActive(false);
        menu.SetActive(false);

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

        if (playersturn)
        {
            menu.SetActive(true);
        }

        if (playersturn == false)
        {
            emenu.SetActive(true);
        }

    }
    public void moveunit()
    {
        emenu.SetActive(false);
        menu.SetActive(false);
        currentplayer.GetComponent<Move>().onactivate();
        currentplayer.GetComponent<Move>().active = true;
    }

    public void settingupattack()
    {

    }


    public void unitrevive()
    {
        emenu.SetActive(false);
        menu.SetActive(false);
        currentplayer.GetComponent<Unitrevive>().onactivate();
        currentplayer.GetComponent<Unitrevive>().active = true;
    }
    public void unitattack()
    {
        emenu.SetActive(false);
        menu.SetActive(false);
        currentplayer.GetComponent<AttackScript>().onactivate();
        currentplayer.GetComponent<AttackScript>().active = true;
    }
    public void rest()
    {
        emenu.SetActive(false);
        menu.SetActive(false);
        StartCoroutine(currentplayer.GetComponent<UnitInformation>().rest());
        currentplayer.GetComponent<UnitInformation>().active = true;
    }





    ///Early build of turn progression

    //public void endplayerturn()
    //{
    //    turns = 2;
    //    phasenumber++;
    //    currentplayer.GetComponent<Light>().enabled = false;
    //    if (phasenumber > players.Capacity + Enemies.Capacity-1) 
    //    {
    //        print("New rotation");
    //        phasenumber = 0;
    //        currentplayer = players[phasenumber];

    //        currentplayer.GetComponent<UnitInformation>().UpdatePlayerHealthGUI();
    //    }
    //    else
    //    {
    //        if (phasenumber < players.Capacity)
    //        {
    //            print("Player's turn " + phasenumber);
    //            currentplayer = players[phasenumber];

    //            currentplayer.GetComponent<UnitInformation>().UpdatePlayerHealthGUI();
    //        }

    //            if (phasenumber >= players.Capacity)
    //            {
    //                print("Enemy's turn " + phasenumber);
    //                currentplayer = Enemies[phasenumber - players.Capacity];

    //                currentplayer.GetComponent<UnitInformation>().UpdatePlayerHealthGUI();
    //            }

    //    }

    //}

}
