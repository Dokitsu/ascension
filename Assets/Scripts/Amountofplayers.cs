using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Amountofplayers : MonoBehaviour {

    private int amountofplayerstrue;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (SceneManager.GetActiveScene().name != "TitleScreen")
        {
            GameObject.FindObjectOfType<GameMaster>().players.Capacity = amountofplayerstrue;
        }
	}

    public void setplayers(int number)
    {
        amountofplayerstrue = number;
    }

    
}
