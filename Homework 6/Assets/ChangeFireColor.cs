using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeFireColor : MonoBehaviour
{
    // All colors are light versions, except for Orange.  Blue, Red, Green, Purple, Orange
    Color[] availableColors = {
                                new Color32(51, 153, 255, 255), new Color32(255, 153, 153, 255), 
                                new Color32(178, 255, 102, 255), new Color32(255, 102, 255, 255), new Color32(255, 128, 0, 255)
                            };
    Light light;

    public void changeColor()
    {
        int generatedNumber = Random.Range(0, 5);
      
        light = GameObject.Find("LIGHT Fireplace").GetComponent<Light>();

        light.color = availableColors[generatedNumber];
    }
}
