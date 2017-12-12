using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class enemySpawner : MonoBehaviour {

    public bool enemyspawn = true;
    private string link;

    // Use this for initialization
    void Start ()
    { 
	if (enemyspawn == true)
        {
            StartCoroutine(spawning());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private Transform Planeset()
    {
        RaycastHit hit;

        Ray raystart = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raystart, out hit, Mathf.Infinity);

        return hit.transform;
    }

    private bool checkpoint()
    {
        RaycastHit hit;
        
        Ray raystart = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(raystart, out hit, Mathf.Infinity);
        if (hit.transform.GetComponent<mapPlane>() == true)
        {
            if (hit.transform.gameObject.GetComponent<mapPlane>().canspawn == true)
            {
                print(hit.transform.GetComponent<mapPlane>());
                Debug.DrawRay(raystart.origin, raystart.direction * hit.distance, Color.green, Mathf.Infinity);
                return true;
            }
            else
            {
                print(hit.transform.GetComponent<mapPlane>());
                Debug.DrawRay(raystart.origin, raystart.direction * hit.distance, Color.red, Mathf.Infinity);
                return false;
            }
        }
        else
        {
            Debug.DrawRay(raystart.origin, raystart.direction * hit.distance, Color.red, Mathf.Infinity);
            return false;
        }
    }

    private IEnumerator spawning()
    {
        link = "URI=file:" + Application.dataPath + "/Plugins/Descent.sqlite";
        //Debug.Log(link);
        IDbConnection database;
        database = (IDbConnection)new SqliteConnection(link);
        database.Open();
        bool testing = false;

        GameMaster gm = gameObject.GetComponent<GameMaster>();
        for (int i = 0; i < LoadScene.players; i++)
        {
            
            GameObject enemyname;
            UnitInformation actualenemy;
            yield return new WaitUntil(() => Input.GetMouseButtonDown(0) && checkpoint() == true);
            Vector3 newinstancepos = Planeset().position + new Vector3(0,15,0);
            Planeset().GetComponent<mapPlane>().canspawn = false;
            yield return new WaitForSeconds(0.5f);


            print("You pressed left click");

            switch (i)
            {
                case (0):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.Zomb, newinstancepos, Quaternion.identity));
                        using (IDbCommand read = database.CreateCommand())
                        {
                            string sqlque = "SELECT * FROM Enemy ORDER BY rowid LIMIT 1 OFFSET 2"; // change the offset for different characters
                            read.CommandText = sqlque;
                            using (IDataReader reader = read.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    actualenemy = enemyname.GetComponent<UnitInformation>();
                                    actualenemy.myname = reader.GetString(0);
                                    actualenemy.maxHP = reader.GetInt16(1);
                                    actualenemy.currHP = reader.GetInt16(1);
                                    actualenemy.range = reader.GetBoolean(2);
                                    actualenemy.truemovement = reader.GetInt16(3);
                                }
                                //database.Close();
                                reader.Close();
                            }

                        }
                        gm.settype(ref LoadScene.classval1, i);
                        break;
                    }
                case (1):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.Spider, newinstancepos, Quaternion.identity));
                        using (IDbCommand read = database.CreateCommand())
                        {
                            string sqlque = "SELECT * FROM Enemy ORDER BY rowid LIMIT 1 OFFSET 3"; // change the offset for different characters
                            read.CommandText = sqlque;
                            using (IDataReader reader = read.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    actualenemy = enemyname.GetComponent<UnitInformation>();
                                    actualenemy.myname = reader.GetString(0);
                                    actualenemy.maxHP = reader.GetInt16(1);
                                    actualenemy.currHP = reader.GetInt16(1);
                                    actualenemy.range = reader.GetBoolean(2);
                                    actualenemy.truemovement = reader.GetInt16(3);
                                }
                                //database.Close();
                                reader.Close();
                            }

                        }
                        gm.settype(ref LoadScene.classval2, i);
                        break;
                    }
                case (2):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.fleshmol, newinstancepos, Quaternion.identity));
                        using (IDbCommand read = database.CreateCommand())
                        {
                            string sqlque = "SELECT * FROM Enemy ORDER BY rowid LIMIT 1 OFFSET 1"; // change the offset for different characters
                            read.CommandText = sqlque;
                            using (IDataReader reader = read.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    actualenemy = enemyname.GetComponent<UnitInformation>();
                                    actualenemy.myname = reader.GetString(0);
                                    actualenemy.maxHP = reader.GetInt16(1);
                                    actualenemy.currHP = reader.GetInt16(1);
                                    actualenemy.range = reader.GetBoolean(2);
                                    actualenemy.truemovement = reader.GetInt16(3);
                                }
                                //database.Close();
                                reader.Close();
                            }

                        }
                        gm.settype(ref LoadScene.classval3, i);
                        break;
                    }
                case (3):
                    {

                        gm.Enemies.Add(Instantiate(enemyname = gm.Zomb, newinstancepos, Quaternion.identity));
                        using (IDbCommand read = database.CreateCommand())
                        {
                            string sqlque = "SELECT * FROM Enemy ORDER BY rowid LIMIT 1 OFFSET 0"; // change the offset for different characters
                            read.CommandText = sqlque;
                            using (IDataReader reader = read.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    actualenemy = enemyname.GetComponent<UnitInformation>();
                                    actualenemy.myname = reader.GetString(0);
                                    actualenemy.maxHP = reader.GetInt16(1);
                                    actualenemy.currHP = reader.GetInt16(1);
                                    actualenemy.range = reader.GetBoolean(2);
                                    actualenemy.truemovement = reader.GetInt16(3);
                                }
                                //database.Close();
                                reader.Close();
                            }

                        }
                        gm.settype(ref LoadScene.classval4, i);
                        break;
                    }
            }
        }
        
        gm.StartCoroutine(gm.setplayer());
        database.Close();
    }
}
