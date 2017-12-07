using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour {

    public bool enemyspawn = true;
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

    private IEnumerator spawning()
    {
        GameMaster gm = gameObject.GetComponent<GameMaster>();
        for (int i = 0; i < LoadScene.players; i++)
        {
          
            GameObject enemyname;
            UnitInformation actualenemy;

            yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

            switch (i)
            {
                case (0):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.Zomb, gm.Espawnlocation[i], Quaternion.identity));
                        actualenemy = enemyname.GetComponent<UnitInformation>();
                        actualenemy.myname = "Zombie";
                        gm.settype(ref LoadScene.classval1, i);
                        break;
                    }
                case (1):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.Spider, gm.Espawnlocation[i], Quaternion.identity));
                        actualenemy = enemyname.GetComponent<UnitInformation>();
                        actualenemy.myname = "Cave Spider";
                        gm.settype(ref LoadScene.classval2, i);
                        break;
                    }
                case (2):
                    {
                        gm.Enemies.Add(Instantiate(enemyname = gm.fleshmol, gm.Espawnlocation[i], Quaternion.identity));
                        actualenemy = enemyname.GetComponent<UnitInformation>();
                        actualenemy.myname = "Flesh Molder";
                        gm.settype(ref LoadScene.classval3, i);
                        break;
                    }
                case (3):
                    {

                        gm.Enemies.Add(Instantiate(enemyname = gm.Zomb, gm.Espawnlocation[i], Quaternion.identity));
                        actualenemy = enemyname.GetComponent<UnitInformation>();
                        actualenemy.myname = "Zombie2";
                        gm.settype(ref LoadScene.classval4, i);
                        break;
                    }
            }
        }
        gm.StartCoroutine(gm.setplayer());
    }
}
