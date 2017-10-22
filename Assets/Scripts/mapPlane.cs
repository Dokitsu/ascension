using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapPlane : MonoBehaviour {

    public Renderer rend;
    public static Vector3 Target;
    public static float distance;
    public bool active;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void OnMouseEnter()
    {

        //Debug.Log(distance);
        //Debug.Log(transform.position.x + "x");
        //Debug.Log(transform.position.y + "y");
        //Debug.Log(transform.position.z + "z");


    }

    //Sets render colour
    //Calcs distance of current player position to highlighted tile
    void OnMouseOver()
    {
        //Display tooltip
       GameObject temp = GameObject.Find("GameMaster").GetComponent<GameMaster>().returnplayers();
        Target = transform.position; //Target is now the tile.
        distance = Vector3.Distance(transform.position, temp.transform.position); //Distance between this transform and a move class.
        
        //if (active)
        //{
            if (distance < 60)
            {
                rend.material.color = Color.yellow;
            }
            else
            {
                rend.material.color = Color.red;
            }
        //}
    }

    //Reverts colour change when cursor leaves the tile
    void OnMouseExit()
    {
        rend.material.color = Color.white;
    }

   
    
    // Update is called once per frame
    void Update ()
    {
		
	}

    void Playertransform()
    {

    }


}
