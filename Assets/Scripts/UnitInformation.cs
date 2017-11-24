using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    public DiceManager Dice;

    public static int blkval;
    public static int redval;
    public static int redval2;
    public static int bluval;
    public static int brwnval;
    public static int ylwval;
    public static int ylwval2;
    public static int gryval;
    public static int gryval2;

    public int currHP;//lose all your health, you're removed from the game
    public enum equipment {Longsword, Bow, LeatherArmour,Magicstaff} //
    public equipment mygear; //ONLY ONE
    public byte defense; //Number of die to roll
    public int truemovement;
    public byte movement;
    public bool range;
                          // Use this for initialization
    public string myname = "This will lead to a method, MAKE SURE YOU MAKE 0 MISTAKES";

    public bool alive;

    public Text HPvalue;
    public Text EHPvalue;

    public int maxHP;

    public bool active;

    //For methods to create: One method (e.g. void longsword) for a piece of equipment

    void Start()
    {
        HPvalue = GameObject.Find("HPtxt").GetComponent<Text>();
        EHPvalue = GameObject.Find("EHPtxt").GetComponent<Text>();
        Dice = GameObject.Find("Dieman").GetComponent<DiceManager>();
    
        GetComponent<Move>().maxmovement = truemovement;
        //StartCoroutine(HitTaken);
        // Current HP assignment for debug only

        //Pulls HP stat from assigned class
        //Player-Tank ,Player-Range, Player-Healer

        //if (gameObject.tag.Contains("Player-Tank"))
        //{
        //    currHP = 15;
        //}
        //else
        //{
        //    if (gameObject.tag.Contains("Player-Range"))
        //    {
        //        currHP = 8;
        //    }
        //    else
        //    {
        //        if (gameObject.tag.Contains("Player-Heal"))
        //        {
        //            currHP = 10;
        //        }
        //        else
        //        {
        //            currHP = 6;
        //        }
        //    }

        UpdatePlayerHealthGUI();
        //}
    }

    public IEnumerator rest()
    {
        Debug.Log("rest");
        Dice.rollrest();
        yield return new WaitForSeconds(8f);
        redval = DiceManager.redval;
        Debug.Log(redval);

        heal(redval);

        UpdatePlayerHealthGUI();

        endmove();
    }

    public void heal(int forcedvalue)
    {
        Debug.Log("resting");
        currHP += forcedvalue;
    }

    public void healthchange(int forcedvalue)
    {
        currHP -= forcedvalue;
    }

	// Update is called once per frame
	void Update ()
    {
        if (currHP > 0)
        {
            alive = true;
        }
            //UpdateHealth();
            if (currHP <= 0)
        {
            if (gameObject.tag == "Player")
            {
                alive = false;
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


    public int healthreturn()
    {
        return currHP;
    }

    public void setmove(Vector3 newlocation)
    {
        transform.position = newlocation;
        movement--;
    }

    public IEnumerator revivePlayer(UnitInformation playerunit)
    {
        int healroll;
        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(playerunit);
        Dice.rollrevive();
        yield return new WaitForSeconds(8);
        healroll = DiceManager.damroll;
        print(healroll);
        playerunit.healthchange(-healroll);

        yield return null;
    }

    public IEnumerator HitTaken(UnitInformation enemyunit)
    {
        int def;
        int damroll;
        int dam;

        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(enemyunit);
        StartCoroutine(Dice.rollmelee(enemyunit));
        StartCoroutine(Dice.rolldef(enemyunit));
        yield return new WaitForSeconds(8f);
        damroll = DiceManager.damroll;
        def = DiceManager.defroll;

        Debug.Log("dam" + damroll);
        Debug.Log("def" + def);

        if (damroll <= def || damroll < 0)
        {
            dam = 0;
        }
        else
        {
            dam = damroll - def;
        }

        enemyunit.healthchange(dam);
        Debug.Log(enemyunit.healthreturn());
        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(enemyunit);
        yield return null;

    }

    public IEnumerator rHitTaken(UnitInformation enemyunit)
    {
        int def;
        int rangeroll;
        int damroll;
        int dam;
        int range;

        UpdatePlayerHealthGUI();
        UpdateEnemyHealthGUI(enemyunit);
        StartCoroutine(Dice.rollranged(enemyunit));
        StartCoroutine(Dice.rolldef(enemyunit));
        yield return new WaitForSeconds(8f);
        damroll = DiceManager.damroll;
        def = DiceManager.defroll;
        rangeroll = DiceManager.rangeroll;
        range = rangeroll * 90;

        Debug.Log("dam" + damroll);
        Debug.Log("def" + def);
        Debug.Log("rangerol" + rangeroll);
        Debug.Log("range" + range);
        Debug.Log("target distance" + AttackScript.Targetdis);

        if (damroll <= def || damroll < 0 || AttackScript.Targetdis > range)
        {
            dam = 0;
        }
        else
        {
            dam = damroll - def;
        }

        enemyunit.healthchange(dam);
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


    void endmove()
    {
        GameObject.FindObjectOfType<GameMaster>().changephase();
        //GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
        active = false;

        //Debug.Log("moved");
    }
}
