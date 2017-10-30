using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKick : MonoBehaviour {

    public string buttonName = "Fire1";
    public float force = 10.0f;
    public ForceMode forceMode;
    public float angforce;
    public bool cankick = false;

    //Kicks the dice

    // Use this for initialization
    void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown(buttonName) && cankick == true)
        {
            KickDie();
        }

        if (GetComponent<Rigidbody>().velocity == new Vector3(0,0,0) && cankick == false)
        {
            //If it's already kicked
            cankick = true;
        }
	}

    void KickDie()
    {
        if (cankick == true)
        {
            Rigidbody die = GetComponent<Rigidbody>();
            die.AddForce(Random.onUnitSphere * force, forceMode);
            die.AddTorque(Random.onUnitSphere * angforce, forceMode);
            cankick = false;
        } 
    }
}
