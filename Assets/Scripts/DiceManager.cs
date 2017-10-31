using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public DiceKick Kick;

    public GameObject BlkDie;
    public GameObject RedDie;

    public string buttonName = "Fire1";

    public Vector3 Blkpoint;

    public bool cankick = false;

    public int blkval;
    public int redval;


    void Start()
    {
        Blkpoint = BlkDie.transform.position;
    }

    void Update()
    {
        blkval = BlkDie.GetComponent<DiceNum>().value;
        redval = RedDie.GetComponent<DiceNum>().value;


        //For Debug purpose "b"
        if (Input.GetButtonDown("RollBlk"))
        {
            rollBlk();
            Debug.Log("Blk reset");
        }

        if (Input.GetButtonDown(buttonName) && cankick == true)
        {
            Kick.KickDie();
        }

        //if (GetComponent<Rigidbody>().velocity == new Vector3(0, 0, 0) && cankick == false)
        //{
        //    //If it's already kicked
        //    cankick = true;
        //}

    }



    void rollBlk()
    {
        if (cankick == true)
        {
            BlkDie.transform.position = (Blkpoint);
            Kick.KickDie();
        }

        
        BlkDie.transform.position = (Blkpoint);
        Kick.KickDie();
    }

    void rollRed()
    {

    }
}
