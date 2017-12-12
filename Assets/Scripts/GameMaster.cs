using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class GameMaster : MonoBehaviour
{
    private enum turn { Start, Movement, Action, End }
    [SerializeField]
    private turn currentphase = turn.Start;
    public List<GameObject> players;
    [SerializeField]
    public List<GameObject> Enemies;
    [SerializeField]
    public bool setMonsters;

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
    public GameObject Syndrael;
    public GameObject Jain;
    public GameObject Avric;
    public GameObject Ashrian;
    public GameObject Grisbane;
    public GameObject Leoric;
    public GameObject Tomble;
    public GameObject Widow;

    //Game Enemies
    public GameObject Zomb;
    public GameObject Spider;
    public GameObject fleshmol;

    public Vector3[] spawnlocation;
    public Vector3[] Espawnlocation;

    //for SQL
    private string link;

    //for wintext
    public GameObject Restartbtn;
    public GameObject Quitbtn;
    public GameObject Menubtn;
    public GameObject GameOverText;
    public GameObject Heroeswins;
    public GameObject Enemieswin;
    public GameObject SideMenu;

    //for Number of dead allies
    public int deadAllies;

    /// <summary>
    /// Used to handle the games turn system
    /// Is boss alive?
    /// no (Unlock Gate)
    /// all enemies dead?
    /// auto win
    /// </summary>

    //this will pull the first class
    //SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 0;

    public void settype(ref int valuetoset,int num)
    {

        link = "URI=file:" + Application.dataPath + "/Plugins/Descent.sqlite";
        //Debug.Log(link);
        IDbConnection database;
        database = (IDbConnection)new SqliteConnection(link);
        database.Open();

        GameObject playerset;

        switch (valuetoset)
        {

            case (0):
                {
                    players.Add(playerset = Instantiate(Syndrael, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 0"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                              //  print(reader.GetInt16(3));
                            }
                            database.Close();
                            reader.Close();
                        }

                    }


                    break;

                }
            case (1):
                {
                    players.Add(playerset = Instantiate(Jain, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 1"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                              //  print(reader.GetInt16(3));

                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (2):
                {
                    players.Add(playerset = Instantiate(Avric, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 2"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                             //   print(reader.GetInt16(3));
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (3):
                {
                    players.Add(playerset = Instantiate(Tomble, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 3"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (4):
                {
                    players.Add(playerset = Instantiate(Grisbane, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 4"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (5):
                {
                    players.Add(playerset = Instantiate(Widow, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 5"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (6):
                {
                    players.Add(playerset = Instantiate(Leoric, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 6"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
            case (7):
                {
                    players.Add(playerset = Instantiate(Ashrian, spawnlocation[num], Quaternion.identity));
                    using (IDbCommand read = database.CreateCommand())
                    {
                        string sqlque = "SELECT * FROM Class ORDER BY rowid LIMIT 1 OFFSET 7"; // change the offset for different characters
                        read.CommandText = sqlque;
                        using (IDataReader reader = read.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                UnitInformation selectedunit = playerset.GetComponent<UnitInformation>();
                                selectedunit.myname = reader.GetString(0);
                                selectedunit.maxHP = reader.GetInt16(1);
                                selectedunit.currHP = reader.GetInt16(1);
                                selectedunit.range = reader.GetBoolean(2);
                                selectedunit.truemovement = reader.GetInt16(3);
                            }
                            database.Close();
                            reader.Close();
                        }

                    }

                    break;
                }
        }
    }

     public IEnumerator setplayer()
    {
        //for (int i = 0; i < LoadScene.players; i++)
        //{
        //        GameObject enemyname;
        //        UnitInformation actualenemy;
        //        //Enemies.Add(Instantiate(Zomb, Espawnlocation[i], Quaternion.identity));
        //        switch (i)
        //        {
        //            case (0):
        //                {
        //                    Enemies.Add(Instantiate(enemyname = Zomb, Espawnlocation[i], Quaternion.identity));
        //                    actualenemy = enemyname.GetComponent<UnitInformation>();
        //                    actualenemy.myname = "Zombie";
        //                    settype(ref LoadScene.classval1, i);
        //                    break;
        //                }
        //            case (1):
        //                {
        //                    Enemies.Add(Instantiate(enemyname = Spider, Espawnlocation[i], Quaternion.identity));
        //                    actualenemy = enemyname.GetComponent<UnitInformation>();
        //                    actualenemy.myname = "Cave Spider";
        //                    settype(ref LoadScene.classval2, i);
        //                    break;
        //                }
        //            case (2):
        //                {
        //                    Enemies.Add(Instantiate(enemyname = fleshmol, Espawnlocation[i], Quaternion.identity));
        //                    actualenemy = enemyname.GetComponent<UnitInformation>();
        //                    actualenemy.myname = "Flesh Molder";
        //                    settype(ref LoadScene.classval3, i);
        //                    break;
        //                }
        //            case (3):
        //                {

        //                    Enemies.Add(Instantiate(enemyname = Zomb, Espawnlocation[i], Quaternion.identity));
        //                    actualenemy = enemyname.GetComponent<UnitInformation>();
        //                    actualenemy.myname = "Zombie2";
        //                    settype(ref LoadScene.classval4, i);
        //                    break;
        //                }
        //        }
            

        //}
        Enemies.Add(GameObject.Find("Boss"));
        currentplayer = players[0];
        menu.SetActive(true);
        playersturn = true;
        yield return null;
     }


    void Start()
    {
        deadAllies = 0;

        players.Capacity = LoadScene.players;
        Enemies.Capacity = LoadScene.players + 1;
       // StartCoroutine(setplayer());


    }
    
	

	void Update ()
    {
        if(deadAllies == players.Capacity)
        {
            Debug.Log("win game");
            SideMenu.SetActive(false);
            GameOverText.SetActive(true);
            Quitbtn.SetActive(true);
            Restartbtn.SetActive(true);
            Menubtn.SetActive(true);
            Enemieswin.SetActive(true);
        }
        // checks if the enemy has been defeated and will skip thier turn
        if (currentplayer == null)
        {
            phasenumber--;
            endplayerturn();
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
                Enemies.Capacity = Enemies.Capacity -1;
            }
            Debug.Log("cap");
            Debug.Log(Enemies.Capacity);
        }

        if (Enemies.Capacity <= 0)
        {
            Debug.Log("win game");
            SideMenu.SetActive(false);
            GameOverText.SetActive(true);
            Quitbtn.SetActive(true);
            Restartbtn.SetActive(true);
            Menubtn.SetActive(true);
            Heroeswins.SetActive(true);

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
        else if (playersturn == false)
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


    
    public void DeadAllies(int add)
    {
        deadAllies += add;
    }
}
