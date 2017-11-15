using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKick : MonoBehaviour {

    public float force = 10.0f;
    public ForceMode forceMode;
    public float angforce;

    /// <summary>
    /// Kicks the dice
    /// Dice kick checks now handled by DiceManager
    /// </summary>


	void Update ()
    {
        //For Debug perpose "k" to kick the dice
        if (Input.GetButtonDown("Kick"))
        {
            KickDie();
        }

    }

    /// <summary>
    /// Adds random force to the dice
    /// </summary>
    public void KickDie()
    {
        Rigidbody die = GetComponent<Rigidbody>();
        die.AddForce(Random.onUnitSphere * force, forceMode);
        die.AddTorque(Random.onUnitSphere * angforce, forceMode);
    }
}
