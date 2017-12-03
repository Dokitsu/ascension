using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public bool active;

    public UnitInformation Unit;
    public GameObject Target;
    public static Vector3 currentpos;
    public static float Targetdis;
    Vector3 Targetpos;

    public bool inrange;
    
    int damage;
    bool range;


    /// <summary>
    /// Handles targeting and distance checks
    /// </summary>
    
    void Start()
    {

        Unit = GetComponent<UnitInformation>();
    }

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
                    //Debug.Log(hit.transform.gameObject.name);
                    // Prevents player attack themselves
                    if (Target != gameObject)
                    {
                        // Check if its player or an enemy
                        if (Target.tag.Contains ("Player") || Target.tag == "Enemy")
                        {
                            //Debug.Log("Enemy detected");
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

    void endmove()
    {
        GameObject.FindObjectOfType<GameMaster>().changephase();

        active = false;

     
    }

    void DistanceCheck()
    {
        //check from player location to target position
        Targetpos = Target.transform.position;
        Targetdis = Vector3.Distance(currentpos,Targetpos);
        if (Unit.GetComponent<UnitInformation>().range)
        {
            Debug.Log("range attack");
            // calculation to see if the angle is valid
            inrange = true;
        }
        else
        {
            if (Targetdis > 90)
            {
                Debug.Log("Target too far");
                inrange = false;
            }
            else
            {
                inrange = true;
            }
        }

        if (inrange == true)
        {
            StartCoroutine(Attack());
            active = false;
        }
    }

    IEnumerator Attack()
    {
        Debug.Log(Target);
        Unit = GetComponent<UnitInformation>();
        if (Unit.range)
        {
            StartCoroutine(Unit.rHitTaken(Target.GetComponent<UnitInformation>()));
        }
        else
        {
            StartCoroutine(Unit.HitTaken(Target.GetComponent<UnitInformation>()));
        }
        yield return new WaitForSeconds(8);
        endmove();
    }


    
}
