using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unitrevive : MonoBehaviour
{

    public bool active;

    public UnitInformation Unit;
    public GameObject Target;
    public static Vector3 currentpos;
    float Targetdis;
    Vector3 Targetpos;

    int damage;

    // Use this for initialization
    void Start ()
    {
		
	}



    // Update is called once per frame
    void Update()
    {
        // Checks if the player is active
        if (active == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                // Casts Raycast on mouse location to set target
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    Target = hit.transform.gameObject;
                    // Prevents player attack themselves
                    if (Target != gameObject)
                    {
                        // Check if its player or an enemy
                        if (Target.tag.Contains("Player") || Target.tag == "Enemy")
                        {
                            Debug.Log("LIVE");
                            // Check to see if target is within range (melee)
                            DistanceCheck();
                        }
                    }
                    else
                    {
                        // Returns to the menu if the player clicks on an invalid target or themselves
                        Debug.Log("Target invalid or out of bounds");
                        active = false;
                        GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
                    }
                }
            }
        }
    }

    public void onactivate()
    {
        // updates current position vector from previous player
        currentpos = transform.position;
        mapPlane.currentpos = currentpos;
    }

    IEnumerator Revive()
    {
        Debug.Log(Target);
        Unit = GetComponent<UnitInformation>();
        StartCoroutine(Unit.revivePlayer(Target.GetComponent<UnitInformation>()));
        yield return new WaitForSeconds(8);
        endmove();
    }

    void endmove()
    {
        GameObject.FindObjectOfType<GameMaster>().changephase();
        active = false;
    }


    void DistanceCheck()
    {
        //check from player location to target position
        Targetpos = Target.transform.position;
        Targetdis = Vector3.Distance(currentpos, Targetpos);
        if (Targetdis > 90)
        {
            Debug.Log("Target too far");
        }
        else
        {
            StartCoroutine(Revive());
            active = false;
        }
    }
}
