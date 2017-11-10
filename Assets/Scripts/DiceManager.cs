using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public DiceKick Kick;

    public GameObject BlkDie;
    public GameObject RedDie;
    public GameObject BluDie;
    public GameObject BrwnDie;
    public GameObject YlwDie;
    public GameObject GryDie;

    public string buttonName = "Fire1";

    public Vector3 Blkpoint;
    public Vector3 Redpoint;
    public Vector3 Blupoint;
    public Vector3 Brwnpoint;
    public Vector3 Ylwpoint;
    public Vector3 Grypoint;

    public bool cankick = false;

    public static int blkval;
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

    void disabledie()
    {
        BlkDie.gameObject.SetActive(false);
    }



    public void rollBlk()
    {
        disabledie();
        //if (cankick == true)
        //{
        //    BlkDie.transform.position = (Blkpoint);
        //    Kick = BlkDie.GetComponent<DiceKick>();
        //    Kick.KickDie();
        //}
        BlkDie.transform.position = (Blkpoint);
        BlkDie.gameObject.SetActive(true);
        Kick = BlkDie.GetComponent<DiceKick>();
        Kick.KickDie();

    }

    void rollRed()
    {
        if (cankick == true)
        {
            RedDie.transform.position = (Redpoint);
            Kick = RedDie.GetComponent<DiceKick>();
            Kick.KickDie();
        }


        RedDie.transform.position = (Redpoint);
        Kick = RedDie.GetComponent<DiceKick>();
        Kick.KickDie();
    }
}
