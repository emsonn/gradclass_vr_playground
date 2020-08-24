using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFireplace : MonoBehaviour
{
    private const float ExtinguishedFireplace = 1.0f;
    private const float BrightFireplace = 0.128f;
    private const int NoLight = 0;
    private const int BrightLight = 25;

    private GameObject fire;
    private GameObject lightObject;
    private AudioSource fireplaceAudio;
    private Light light;
    private Material fireMaterial;
    private float fireMaterialValue;

    public void Toggle()
    {
        fire = GameObject.Find("Fireplace/Fire");
        lightObject = GameObject.Find("LIGHT Fireplace");

        fireplaceAudio = fire.GetComponent<AudioSource>();
        light = lightObject.GetComponent<Light>();

        fireMaterial = fire.GetComponent<Renderer>().sharedMaterial;
        fireMaterialValue = fireMaterial.GetFloat("_Metallic");
        
        // Logic for toggling fireplace.
        if (fireMaterialValue < ExtinguishedFireplace)
        {
            fireMaterial.SetFloat("_Metallic", ExtinguishedFireplace);
            light.range = NoLight;
            fireplaceAudio.Pause();
        } 
        
        else
        {
            fireMaterial.SetFloat("_Metallic", BrightFireplace);
            light.range = BrightLight;
            fireplaceAudio.Play();
        }
    }
}
