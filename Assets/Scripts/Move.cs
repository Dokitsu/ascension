using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public bool active;
    private Vector3 targetpos;
    public static Vector3 currentpos;
    public int maxmovement;
    [SerializeField]
    private int currentmovement;

    private void OnEnable()
    {
        currentmovement = maxmovement;
    }
    // Use this for initialization
    void Start()
    {
        currentpos = transform.position;
    }

    public void onactivate()
    {
        currentmovement = maxmovement;
    }

    // Update is called once per frame
    void Update()
    {
        
        // Activates the player move script on LMB
        if (Input.GetMouseButtonDown(0) && active == true)
            SetTarget();
    }

    void SetTarget()
    {
        //Sets the target to the selected plane
        targetpos = mapPlane.Target;
        // Checks if the player is currently active and if the move was valid
        if (active)
        {
            if (mapPlane.distance < 60)
            {
                MovePlayer();

            }
        }
    }


    //Moves player to slected plane and updates current position
    void MovePlayer()
    {
        if (currentmovement > 0)
        {
            transform.position = new Vector3(targetpos.x, targetpos.y + 10, targetpos.z);
            currentpos = transform.position;
            currentmovement--;
            print(currentmovement);
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
        Debug.Log("moved");
    }


}
