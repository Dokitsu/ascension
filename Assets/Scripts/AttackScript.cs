using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public bool active;

    public UnitInformation Unit;
    //public GameObject Attacker;
    public GameObject Target;
    //public Vector3 Atkcoor;
    //public Vector3 Tarcoor;
    //public Vector3 targetpos;
    public static Vector3 currentpos;
    float Targetdis;
    Vector3 Targetpos;

    int damage;

    void Start ()
    {
		
	}

    private void OnMouseDown()
    {
        
    }

    void Update()
    {
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

        if (active == true)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 1000))
                {
                    Target = hit.transform.gameObject;
                    //Debug.Log(hit.transform.gameObject.name);
                    if (Target.tag == "Player")
                    {
                        Debug.Log("Enemy detected");
                        DistanceCheck();
                    }

                }
                else
                {
                    Debug.Log("Target invalid or out of bounds");
                } 
                
            }
        }
    }

    public void onactivate()
    {
        currentpos = transform.position;
        mapPlane.currentpos = currentpos;
        Debug.Log(currentpos);
    }



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


    void DistanceCheck()
    {
        Targetpos = Target.transform.position;
        Targetdis = Vector3.Distance(currentpos,Targetpos);
        if (Targetdis < 60)
        {
            Attack();
        }
        else
        {
            Debug.Log("Target too far");
        }
    }

    public void Attack()
    {

        Debug.Log(Target);
        Unit = GetComponent<UnitInformation>();
        StartCoroutine(Unit.HitTaken());

    }

    void DefRoll()
    {

    }
}
