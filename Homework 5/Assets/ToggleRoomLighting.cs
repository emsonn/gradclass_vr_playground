using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleRoomLighting : MonoBehaviour
{
    Light light;

    public void toggleRoomLighting()
    {
        light = GameObject.Find("LIGHT Fireplace Right Sconce").GetComponent<Light>();

        float lightRange = light.range;
        
        if (lightRange != 0)
            light.range = 0;
        else
            light.range = 18;
    }
}
