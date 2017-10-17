using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event : MonoBehaviour
{

    int turncount;
    public int playercount;


    void Start()
    {
        playerturn();
        enemyturn();
        turncount = turncount + 1;
    }

    void playerturn()
    {

    }

    void enemyturn()
    {

    }

}
