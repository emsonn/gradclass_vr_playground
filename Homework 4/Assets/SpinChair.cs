using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinChair : MonoBehaviour
{
    private const int StartingRestingPosition = 29;
    private const int FinalRestingRotation = 326;
    private const int DegreeChange = 3;

    GameObject officeChair;
    public Transform target;
    public bool chairTuckedIn = false;
    public float smoothing = 1f;
    private int totalDegreesRotated = 0;

    public void spinChair()
    {
        StartCoroutine(MyCoroutine(target));
    }

    IEnumerator MyCoroutine(Transform target)
    {
        officeChair = GameObject.Find("Office Chair");

        if (!chairTuckedIn)
        {
            while (Vector3.Distance(transform.position, target.position) > 1.4f)
            {
                transform.position = Vector3.Lerp(transform.position, target.position, smoothing * 0.3f * Time.deltaTime);
                
                if (totalDegreesRotated < FinalRestingRotation)
                {
                    transform.Rotate(Vector3.up, DegreeChange);
                    totalDegreesRotated += DegreeChange;
                }

                yield return new WaitForSeconds(0.01f);
            }

            chairTuckedIn = true;
        }
    }
}
