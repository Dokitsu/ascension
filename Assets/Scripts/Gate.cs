﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour {

    public static bool Key;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    // check to see if player is at gate



    void OnTriggerEnter(Collider other)
    {
        if (Key)
        {
            Debug.Log(other);
            if (other.tag == "Player")
            {
                Debug.Log("Win game");
            }
        }
        else
        {
            // moves player back
            // play gate clank sound
            other.transform.Translate(0, 0, -50);
        }
    }
}
