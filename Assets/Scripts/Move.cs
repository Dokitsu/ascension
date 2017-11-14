using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public bool active;
    public Vector3 targetpos;
    public static Vector3 currentpos;

    public int maxmovement;
    [SerializeField]
    private int currentmovement;

    Vector3 Raycheck;

    public GameObject Target;


    private void OnEnable()
    {
        currentmovement = maxmovement;
    }
    // Use this for initialization
    void Start()
    {
        //currentpos = transform.position;



    }

    public void onactivate()
    {
        currentmovement = maxmovement;
        currentpos = transform.position;
        mapPlane.currentpos = currentpos;

}

    // Update is called once per frame
    void Update()
    {
        Raycheck = mapPlane.Target - currentpos;
        // Activates the player move script on LMB
        if (Input.GetMouseButtonDown(0) && active == true)
        {
            SetTarget();
        }
    }

    void SetTarget()
    {
        //Sets the target to the selected plane
        targetpos = mapPlane.Target;
        RaycastHit hit;
        // Checks if the player is currently active and if the move was valid
        if (active)
        {
            if (Physics.Raycast(currentpos, Raycheck, out hit))
            {
                Target = hit.transform.gameObject;
                Debug.Log(Target);
                if (Target.tag == "Player" || Target.tag == "Enemy" || Target.tag == "Block")
                {
                    Debug.Log("hitmebby");
                }
                else
                {
                    if (mapPlane.distance < 80)
                    {
                        MovePlayer();
                    }
                }
            }
        }
    }


    //Moves player to slected plane and updates current position
    void MovePlayer()
    {
        if (currentmovement > 0)
        {
            transform.position = new Vector3(targetpos.x, targetpos.y + 15, targetpos.z);
            currentpos = transform.position;
            mapPlane.currentpos = currentpos;
            currentmovement--;
            //print(currentmovement);
        }
        if (currentmovement == 0)
        {
            endmove();
        }
    }

    void endmove()
    {
        GameObject.FindObjectOfType<GameMaster>().changephase();
        GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
        active = false;

        //Debug.Log("moved");
    }


}
