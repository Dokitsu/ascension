using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour {

    public GameObject BlkDie;
    public GameObject RedDie;

    public int blkval;
    public int redval;


    void Update()
    {
        blkval = BlkDie.GetComponent<DiceNum>().value;
        redval = RedDie.GetComponent<DiceNum>().value;
    }


}
