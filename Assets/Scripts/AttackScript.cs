using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

    public bool active;

    public GameObject Attacker;
    public GameObject Target;
    public Vector3 Atkcoor;
    public Vector3 Tarcoor;
    public Vector3 targetpos;
    public static Vector3 currentpos;



    void Start ()
    {
		
	}
	
	void Update ()
    {
        if(Input.GetMouseButtonDown(0) && active == true)
        {
            
        }

    }

    public void onactivate()
    {
        currentpos = transform.position;
        mapPlane.currentpos = currentpos;
        Debug.Log(currentpos);
    }

    void AttackerRange()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        Vector3 bck = transform.TransformDirection(Vector3.back);
        Vector3 lft = transform.TransformDirection(Vector3.left);
        Vector3 rht = transform.TransformDirection(Vector3.right);

        if (Physics.Raycast(transform.position, fwd, 10))
        {
            Debug.Log("fwd");
        }
        if (Physics.Raycast(transform.position, bck, 10))
        {
            Debug.Log("bck");
        }
        if (Physics.Raycast(transform.position, lft, 10))
        {
            Debug.Log("lft");
        }
        if (Physics.Raycast(transform.position, rht, 10))
        {
            Debug.Log("rht");
        }
    }

    void AttackerDam()
    {

    }

    void DefRoll()
    {

    }
}
