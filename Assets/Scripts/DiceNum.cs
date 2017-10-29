using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceNum : MonoBehaviour {

    public LayerMask diecoll = -1;
    public int value = 1;

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.up, out hit, Mathf.Infinity, diecoll))
        {
            value = hit.collider.GetComponent<DiceVal>().value;
        }
    }

    void OnGUI()
    {
        GUILayout.Label(value.ToString());
    }
}
