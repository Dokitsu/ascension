using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    private byte health; //lose all your health, you're removed from the game
    private enum equipment {Longsword, Bow, LeatherArmour,Magicstaff} //
    private equipment mygear; //ONLY ONE
    private byte defense; //Numbeer of die to roll
    private byte truemovement;
    public byte movement;
                          // Use this for initialization
    private string myname = "This will lead to a method, MAKE SURE YOU MAKE 0 MISTAKES";
    
   //For methods to create: One method (e.g. void longsword) for a piece of equipment

	void Start ()
    {

	}

    public void minushp(byte healthdelete)
    {
        health -= healthdelete;
    }
	
    public void rest()
    {
        health += (byte)Random.Range(1, 4);
        
    }

	// Update is called once per frame
	void Update ()
    {
		
	}

    public byte defensereturn()
    {
        return defense;
    }

    public byte attackereturn()
    {
        switch (mygear)
        {
            case equipment.Longsword:
                {
                    return 3;
                    
                }
            case equipment.Magicstaff:
                {
                    return 3;

                }
            case equipment.Bow:
                {
                    return 3;

                }
            default:
                {
                    return 1;
                }
        }

    }

    public byte movereturn()
    {
        return movement;
    }
    public void setmove(Vector3 newlocation)
    {
        transform.position = newlocation;
        movement--;
    }
}
