using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDice : MonoBehaviour {

   public int diceRoll;
	// Use this for initialization
	void Start () {
        Roll();
	}
	
	// Update is called once per frame
	void Update () {      

    }

    public void Roll()
    {
       diceRoll = Random.Range(1, 6);
    }
}
