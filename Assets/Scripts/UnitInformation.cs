﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UnitInformation : MonoBehaviour {

    [SerializeField]
    private byte currHP; //lose all your health, you're removed from the game
    private enum equipment {Longsword, Bow, LeatherArmour,Magicstaff} //
    private equipment mygear; //ONLY ONE
    private byte defense; //Numbeer of die to roll
    private byte truemovement;
    public byte movement;
    // Use this for initialization
    
    public string myname = "This will lead to a method, MAKE SURE YOU MAKE 0 MISTAKES";

    public Text HPvalue;
    //public int currHP;

    //For methods to create: One method (e.g. void longsword) for a piece of equipment



    void Start ()
    {

        // Current HP assignment for debug only
        currHP = 15;
        
    }
	
    public void takedamage(int damage)
    {
        currHP -= (byte)damage;
        UpdateHealth();
    }

    public void rest()
    {
        currHP += (byte)Random.Range(1, 4);
        UpdateHealth();
        
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

    public void setmove(Vector3 newlocation)
    {
        transform.position = newlocation;
        movement--;
    }

    void UpdateHealth()
    {
        HPvalue.text = myname + " || HP: " + currHP;
    }
}
