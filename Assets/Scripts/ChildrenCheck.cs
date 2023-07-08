using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:



Sprawdza czy wszytskie literki zosta³y u³o¿one na odpowiednim miejscu
Jeœli tak to allChildrenAreOn = true;


----------------------------------------------------------------------------------------------------------- */

public class ChildrenCheck : MonoBehaviour
{
    public bool allChildrenAreOn;

    void Update()
    {
        CheckIfAllChildrenAreOn();
    }


    private void CheckIfAllChildrenAreOn()
    {
        allChildrenAreOn = true;

        foreach (Transform child in transform) 
        {
            ClickController childScript = child.GetComponent<ClickController>();


            if (childScript != null && !childScript.inOnRightPosition)
            {
            allChildrenAreOn= false;
                break;
            }
        
        }
        if (allChildrenAreOn)
        {
            Debug.Log("Wszystkie dzieci maj¹ inOnRightPosition = true.");

            DisableChildren();

        }
        else
        {
            Debug.Log("Nie wszystkie dzieci maj¹ inOnRightPosition = true.");
        }



    }

    public void DisableChildren()
    {
            foreach(Transform child in transform)
            {
                
                BoxCollider2D boxCollider2d = child.GetComponent<BoxCollider2D>();
                boxCollider2d.enabled = false;
              
            }
    }
}
