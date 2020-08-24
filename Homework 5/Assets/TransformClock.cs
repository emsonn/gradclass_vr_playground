using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformClock : MonoBehaviour
{
    private const float MaxClockSize = 0.0015f; 

    GameObject deskClock;
    private Vector3 scaleChange = new Vector3(0.00025f, 0.00025f, 0.00025f);
    private Vector3 defaultClockSize = new Vector3(0.0005245652f, 0.0005245652f, 0.0005245652f);

    public void growClock() 
    {
        deskClock = GameObject.Find("Desk Area/Clock");
        
        deskClock.transform.localScale += scaleChange;

        if (deskClock.transform.localScale.x >= MaxClockSize)
            deskClock.transform.localScale = defaultClockSize;
    }
}
