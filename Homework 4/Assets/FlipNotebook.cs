using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipNotebook : MonoBehaviour
{
    private const int DegreeChange = 5;
    private const int OpenBook = 180;
    private const int ClosedBook = 0;
    
    private GameObject notebook;
    private int totalDegreesRotated = 0;
    private bool bookOpen = false;

    public void flipNotebook()
    {
        StartCoroutine(MyCoroutine());
    }

    IEnumerator MyCoroutine()
    {   
        notebook = GameObject.Find("notepad_top");

        // Note: Vector3.back = (0, 0, -1)
        if (!bookOpen) 
        {
            while (totalDegreesRotated < OpenBook)
            {
                transform.Rotate(Vector3.back, DegreeChange);
                totalDegreesRotated += DegreeChange;
                
                yield return new WaitForSeconds(0.01f);
            }

            bookOpen = true;
        } 
        
        // Note: Vector3.forward = (0, 0, 1)
        else if (bookOpen)
        {
            while (totalDegreesRotated > ClosedBook)
            {
                transform.Rotate(Vector3.forward, DegreeChange);
                totalDegreesRotated -= DegreeChange;
                
                yield return new WaitForSeconds(0.01f);
            }

            bookOpen = false;
        }
    }
}
