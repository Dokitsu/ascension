using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public bool active;

    public UnitInformation Unit;
    public GameObject Target;
    public static Vector3 currentpos;
    float Targetdis;
    Vector3 Targetpos;

    int damage;


    /// <summary>
    /// Handles targeting and distance checks
    /// </summary>
    

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
        //Debug.Log(currentpos);
    }

    void endmove()
    {
        GameObject.FindObjectOfType<GameMaster>().changephase();
        //GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
        active = false;

        //Debug.Log("moved");
    }

    void DistanceCheck()
    {
        //check from player location to target position
        Targetpos = Target.transform.position;
        Targetdis = Vector3.Distance(currentpos,Targetpos);
        if (Targetdis > 90)
        {
            Debug.Log("Target too far");
        }
        else
        {
            StartCoroutine(Attack());
            active = false;
        }
    }

    IEnumerator Attack()
    {
        Debug.Log(Target);
        Unit = GetComponent<UnitInformation>();
        StartCoroutine(Unit.HitTaken(Target.GetComponent<UnitInformation>()));
        yield return new WaitForSeconds(8);
        endmove();
    }




    ///
    ///Unused code, Initial code for testing functionality
    ///

    //void Update()
    //{
    //if (active == true)
    //{
    //    if (Input.GetKeyDown(KeyCode.DownArrow))
    //    {
    //        AttackerRange("dwn");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        AttackerRange("fwd");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        AttackerRange("rht");
    //    }
    //    else if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        AttackerRange("lft");
    //    }
    //}
    //}
    //void AttackerRange(string direction)
    //{
    //    Vector3 fwd = Vector3.forward;
    //    Vector3 dwn = Vector3.back;
    //    Vector3 lft = Vector3.left;
    //    Vector3 rht = Vector3.right;
    //    RaycastHit hit;
    //    switch (direction)
    //    {
    //        case ("fwd"):
    //            {
    //                if (Physics.Raycast(transform.position, fwd, out hit, 50f))
    //                {
    //                    print(hit.transform.gameObject.name);
    //                    Target = hit.transform.gameObject;
    //                    Attack();
    //                    active = false;
    //                }
    //                else
    //                {
    //                    Debug.DrawRay(transform.position, fwd * 50f, Color.red, 1f);
    //                    print("Sorry no hit up");
    //                }
    //                return;
    //            }
    //        case ("dwn"):
    //            {
    //                if (Physics.Raycast(transform.position, dwn, out hit,50f))
    //                {
    //                    print(hit.transform.gameObject.name);
    //                    Target = hit.transform.gameObject;
    //                    Attack();
    //                    active = false;
    //                }
    //                else
    //                {
    //                    Debug.DrawRay(transform.position, dwn * 50f, Color.red, 1f);
    //                    print("Sorry no hit down");
    //                }
    //                return;
    //            }
    //        case ("lft"):
    //            {
    //                if (Physics.Raycast(transform.position, lft, out hit,50f))
    //                {
    //                    print(hit.transform.gameObject.name);
    //                    Target = hit.transform.gameObject;
    //                    Attack();
    //                    active = false;
    //                }
    //                else
    //                {
    //                    Debug.DrawRay(transform.position, lft * 50f, Color.red, 1f);
    //                    print("Sorry no hit left");
    //                }
    //                return;
    //            }
    //        case ("rht"):
    //            {
    //                if (Physics.Raycast(transform.position, rht, out hit,50f))
    //                {
    //                    print(hit.transform.gameObject.name);
    //                    Target = hit.transform.gameObject;
    //                    Attack();
    //                    active = false;
    //                }
    //                else
    //                {
    //                    Debug.DrawRay(transform.position, rht * 50f, Color.red, 1f);
    //                    print("Sorry no hit right OR ALL AROUND");
    //                }
    //                return;
    //            }
    //    }
    //}
}
