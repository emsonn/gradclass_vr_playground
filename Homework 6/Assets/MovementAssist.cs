using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAssist : MonoBehaviour
{
    // Not good code section below - would've preferred to use a list with child components, but had issues with getting it to work. 
    // Starting position for Robot Kyle.
    private Vector3 robotKyleOriginalPosition;

    private Quaternion leftThigh = Quaternion.Euler(-180.0f, -1.525879e-05f, 80.16599f);
    private Quaternion leftKnee = Quaternion.Euler(0.0f, 0.0f, -86.43101f);
    private Quaternion rightThigh = Quaternion.Euler(0.0f, 0.0f, 99.983f);
    private Quaternion rightKnee = Quaternion.Euler(180.0f, 0.0f, -86.43101f);
    private Quaternion neck = Quaternion.Euler(0.0f, 0.0f, -17.396f);

    private GameObject robotKyleLeftThigh;
    private GameObject robotKyleLeftKnee;
    private GameObject robotKyleRightThigh;
    private GameObject robotKyleRightKnee;
    private GameObject robotKyleNeck;

    // Allows us to access the Animate field from the ForwardKinematics script.
    public ForwardKinematics playerScript;
    
    // Code below from Unity's Documentation for Lerp. 
    // https://docs.unity3d.com/ScriptReference/Vector3.Lerp.html
    //
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0f;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    // Check to see if the animation has played before.
    private bool firstTimeAnimation = true;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);

        robotKyleOriginalPosition = new Vector3(-1.81f, -0.9f, -3.22f);

        robotKyleLeftThigh = GameObject.Find("Robot Kyle/Root/Hip/Left_Thigh_Joint_01");
        robotKyleLeftKnee = GameObject.Find("Robot Kyle/Root/Hip/Left_Thigh_Joint_01/Left_Knee_Joint_01");
        robotKyleRightThigh = GameObject.Find("Robot Kyle/Root/Hip/Right_Thigh_Joint_01");
        robotKyleRightKnee = GameObject.Find("Robot Kyle/Root/Hip/Right_Thigh_Joint_01/Right_Knee_Joint_01");
        robotKyleNeck = GameObject.Find("Robot Kyle/Root/Ribs/Neck");

        transform.position = robotKyleOriginalPosition;

    }

    // Move to the target end position.
    void Update()
    {
        if (playerScript.animate)
        {            
            // Distance moved equals elapsed time times speed.
            float distCovered = (Time.time - startTime) * speed;

            // Fraction of journey completed equals current distance divided by total distance.
            float fractionOfJourney = distCovered / journeyLength;

            // Set our position as a fraction of the distance between the markers.
            transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        }

        // Put Robot Kyle back into the char if this is unchecked.
        else 
        {
            transform.position = robotKyleOriginalPosition;
            robotKyleLeftThigh.transform.localRotation = leftThigh; 
            robotKyleLeftKnee.transform.localRotation = leftKnee;
            robotKyleRightThigh.transform.localRotation = rightThigh;
            robotKyleRightKnee.transform.localRotation = rightKnee;
            robotKyleNeck.transform.localRotation = neck;
        }
    }
}

