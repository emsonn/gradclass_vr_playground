using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStatuesColor : MonoBehaviour
{    
    // Colors: Black, Light Blue, Green, Red, White
    private Color[] availableColors = {
                                new Color32(0, 0, 0, 255), new Color32(0, 255, 255, 255), 
                                new Color32(0, 153, 0, 255), new Color32(204, 102, 255, 255), new Color32(255, 255, 255, 255)
                            };
    GameObject statues;

    public void changeColor()
    {
        int generatedNumber = Random.Range(0, 5);

        statues = GameObject.Find("Lion Statues");

        Material statuesColor = statues.GetComponent<Renderer>().sharedMaterial;

        statuesColor.SetColor("_Color", availableColors[generatedNumber]);
    }
}
