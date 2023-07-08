using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:
przypisuje wartoœci dla prefabu z literk¹

póŸniej obs³ugiwane w:
WordController




----------------------------------------------------------------------------------------------------------- */

public class Sequence : MonoBehaviour
{
    public bool isActive = true;
    public int sequence;
    public string letter;

    private void Start()
    {
        TextMeshPro childScript = transform.GetChild(0).GetComponent<TextMeshPro>();

        letter = childScript.text;

    }


}
