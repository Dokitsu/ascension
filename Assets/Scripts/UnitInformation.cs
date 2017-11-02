using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    public DiceManager Dice;
    public static int blkval;

    private int currHP; //lose all your health, you're removed from the game
    private enum equipment {Longsword, Bow, LeatherArmour,Magicstaff} //
    private equipment mygear; //ONLY ONE
    private byte defense; //Numbeer of die to roll
    private byte truemovement;
    public byte movement;
                          // Use this for initialization
    private string myname = "This will lead to a method, MAKE SURE YOU MAKE 0 MISTAKES";

    public Text HPvalue;
    //public int currHP;

    //For methods to create: One method (e.g. void longsword) for a piece of equipment

    void Start ()
    {
        //StartCoroutine(HitTaken);
        // Current HP assignment for debug only
        currHP = 15;
        UpdateHealthGUI();
    }
	
    public void rest()
    {
        currHP += (byte)Random.Range(1, 4);
        UpdateHealthGUI();
        
    }

	// Update is called once per frame
	void Update ()
    {
        //UpdateHealth();
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


    public void setmove(Vector3 newlocation)
    {
        transform.position = newlocation;
        movement--;
    }


    public IEnumerator HitTaken()
    {
        Dice.rollBlk();
        yield return new WaitForSeconds(8f);
        blkval = DiceManager.blkval;
        Debug.Log(blkval);
        currHP = currHP - blkval;
        Debug.Log(currHP);
        UpdateHealthGUI();
    }


    void UpdateHealthGUI()
    {
        HPvalue.text = "HP: " + currHP;
    }
}
