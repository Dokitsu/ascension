using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public int SpeedOfCamera;

    void Start()
    {
        //StartCoroutine(speedswitch());
    }

	void Update ()
    {
        transform.Rotate(0, SpeedOfCamera*Time.deltaTime, 0);
	}

    /*
    public IEnumerator speedswitch()
    {
        while (true)
        {
            SpeedOfCamera = Random.Range(2, 6);
            yield return new WaitForSeconds(2f);
            SpeedOfCamera = 4;
            yield return new WaitForSeconds(5f);
        }
    }
    */
}
