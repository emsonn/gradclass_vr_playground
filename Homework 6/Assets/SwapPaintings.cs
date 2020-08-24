using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapPaintings : MonoBehaviour
{
    GameObject leftPainting;
    GameObject rightPainting;
    private Vector3 tempPosition;

    public void swapPaintings()
    {
        leftPainting = GameObject.Find("LeftPainting");
        rightPainting = GameObject.Find("RightPainting");

        tempPosition = leftPainting.transform.position;
        leftPainting.transform.position = rightPainting.transform.position;
        rightPainting.transform.position = tempPosition;
    }
}
