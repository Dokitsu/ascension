using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPivot : MonoBehaviour
{
    public int SpeedOfCamera;

	void Update ()
    {
        transform.Rotate(0, SpeedOfCamera*Time.deltaTime, 0);
	}
}
