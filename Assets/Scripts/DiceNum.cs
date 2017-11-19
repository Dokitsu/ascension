using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNum : MonoBehaviour {

    public LayerMask diecoll = -1;
    public int value = 1;
    public int nvalue = 0;


    /// <summary>
    /// Finds the upward facing die face
    /// </summary>

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, diecoll))
        {
            value = hit.collider.GetComponent<DiceVal>().value;
            nvalue = hit.collider.GetComponent<DiceVal>().nvalue;
        }
    }



    void OnGUI()
    {
        //GUILayout.Label(value.ToString());
    }
}
