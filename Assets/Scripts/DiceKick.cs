using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceKick : MonoBehaviour {

    public string buttonName = "Fire1";
    public float force = 10.0f;
    public ForceMode forceMode;
    public float angforce;

    //public GameObject die;

	// Use this for initialization
	void Start ()
    {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown(buttonName))
        {
            KickDie();
        }
	}

    void KickDie()
    {
        Rigidbody die = GetComponent<Rigidbody>();
        die.AddForce(Random.onUnitSphere * force, forceMode);
        die.AddTorque(Random.onUnitSphere * angforce, forceMode);
    }
}
