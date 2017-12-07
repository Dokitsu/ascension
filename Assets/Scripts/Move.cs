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
                    if (currentmovement == maxmovement)
                    {

                    }

                }
                else
                {
                    if (mapPlane.distance < 20)
                    {
                        if(currentmovement < maxmovement)
                        {
                            endmove();
                        }
                        active = false;
                        GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
                    }
                    if (mapPlane.distance < 80)
                    {
                        MovePlayer();
                    }
                }
            }
        }
    }


    private IEnumerator movingplayer()
    {
        float tempfl = 0;
        Vector3 temppos = transform.position;
        Vector3 temptargetpos = targetpos;
        for (tempfl = 0; tempfl <1; tempfl+=0.05f)
        {
           transform.position = Vector3.Lerp(temppos, temptargetpos + new Vector3(0,15,0), tempfl);
            yield return new WaitForSeconds(0.05f);
            print(tempfl);
        }
        currentpos = transform.position;
        mapPlane.currentpos = currentpos;
        RaycastHit hitman;
        Physics.Raycast(transform.position, Vector3.down, out hitman);
        switch (hitman.transform.gameObject.GetComponent<mapPlane>().mytype)
        {
            case 0:
                {
                    currentmovement--;
                    break;
                }
            case (mapPlane.tiletype)1:
                {
                    currentmovement-=2;
                    break;
                }
            default:
                {
                    currentmovement--;
                    break;
                }
        }

        yield return null;
    }

    //Moves player to slected plane and updates current position
    void MovePlayer()
    {
        if (currentmovement > 0)
        {
            StartCoroutine(movingplayer());

           // transform.position = new Vector3(targetpos.x, targetpos.y + 15, targetpos.z);
           //currentpos = transform.position;
           
           
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
        //GameObject.FindObjectOfType<GameMaster>().menu.SetActive(true);
        active = false;

        //Debug.Log("moved");
    }


}
