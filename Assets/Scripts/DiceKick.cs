using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKick : MonoBehaviour {

    public float force = 10.0f;
    public ForceMode forceMode;
    public float angforce;

    //Kicks the dice

    //Dice kick checks now handled by DiceManager
        
        
    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {

        //For Debug perpose "k" to kick the dice
        if (Input.GetButtonDown("Kick"))
        {
            KickDie();
        }

    }

    public void KickDie()
    {
        Rigidbody die = GetComponent<Rigidbody>();
        die.AddForce(Random.onUnitSphere * force, forceMode);
        die.AddTorque(Random.onUnitSphere * angforce, forceMode);
    }
}
