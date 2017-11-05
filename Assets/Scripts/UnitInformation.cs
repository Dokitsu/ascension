using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    public DiceManager Dice;
    public static int blkval;

    public int currHP;//lose all your health, you're removed from the game
    private enum equipment {Longsword, Bow, LeatherArmour,Magicstaff} //
    private equipment mygear; //ONLY ONE
    private byte defense; //Numbeer of die to roll
    private byte truemovement;
    public byte movement;
                          // Use this for initialization
    private string myname = "This will lead to a method, MAKE SURE YOU MAKE 0 MISTAKES";

    public bool alive;

    public Text HPvalue;
    public Text EHPvalue;
    //public int currHP;

    //For methods to create: One method (e.g. void longsword) for a piece of equipment

    void Start()
    {
        //StartCoroutine(HitTaken);
        // Current HP assignment for debug only

        //Pulls HP stat from assigned class
        //Player-Tank ,Player-Range, Player-Healer

        if (gameObject.tag.Contains("Player-Tank"))
        {
            currHP = 15;
        }
        else
        {
            if (gameObject.tag.Contains("Player-Range"))
            {
                currHP = 8;
            }
            else
            {
                if (gameObject.tag.Contains("Player-Heal"))
                {
                    currHP = 10;
                }
                else
                {
                    currHP = 6;
                }
            }

            UpdatePlayerHealthGUI();
        }
    }
	
    public void rest()
    {
        currHP += (byte)Random.Range(1, 4);
        UpdatePlayerHealthGUI();
        
    }

    public void healthchange(int forcedvalue)
    {
        currHP -= forcedvalue;
    }

	// Update is called once per frame
	void Update ()
    {
        //UpdateHealth();
        if (currHP <= 0)
        {
            if (gameObject.tag == "Player")
            {

            }
            else
            {
                GameObject gm = GameObject.FindObjectOfType<GameMaster>().gameObject;
                gm.GetComponent<GameMaster>().removingenemy(this);
                Destroy(gameObject);
            }
        }
    }

    public byte defensereturn()
    {
        return defense;
    }

    public byte movereturn()
    {
        return movement;
    }

//<<<<<<< HEAD
//=======
//>>>>>>> origin/HEAD
    public int healthreturn()
    {
        return currHP;
    }

    public void setmove(Vector3 newlocation)
    {
        transform.position = newlocation;
        movement--;
    }


    public IEnumerator HitTaken(UnitInformation enemyunit)
    {
        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(enemyunit);
        Dice.rollBlk();
        yield return new WaitForSeconds(8f);
        blkval = DiceManager.blkval;
        Debug.Log(blkval);
        enemyunit.healthchange(blkval);
        Debug.Log(enemyunit.healthreturn());
        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(enemyunit);

        yield return null;
    }


    public void UpdatePlayerHealthGUI()
    {
        HPvalue.text = "HP: " + currHP;
    }

    public void UpdateEnemyHealthGUI(UnitInformation enemy)
    {
        EHPvalue.text = "Enemy HP: " + enemy.healthreturn();
    }
}
