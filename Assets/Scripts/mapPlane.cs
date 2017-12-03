using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPlane : MonoBehaviour {

    public Renderer rend;
    public static Vector3 Target;
    public static float distance;
    public static Vector3 currentpos;
    public bool active;

    public GameObject thit;

    Vector3 Raycheck;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {




    }

    //Sets render colour
    //Calcs distance of current player position to highlighted tile
    void OnMouseOver()
    {

        RaycastHit hit;
        //Display tooltip
        Target = transform.position;
        distance = Vector3.Distance(transform.position, currentpos);


       
            if (Physics.Raycast(currentpos, Raycheck, out hit))
            {
                thit = hit.transform.gameObject;

                if (distance > 80 || thit.tag == "Block")
                {

                    rend.material.color = Color.red;
                }
                else
                {
                    rend.material.color = Color.yellow;
                }
            }
       
    }

    //Reverts colour change when cursor leaves the tile
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

   
    
    // Update is called once per frame
    void Update ()
    {
        Raycheck = Target - currentpos;
    }

    void Playertransform()
    {

    }


}
