using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:
Przypisuje wartoœci do prefabu na który bêdzie wskakiwa³ prefab z Literk¹






----------------------------------------------------------------------------------------------------------- */

public class SquareForLetters : MonoBehaviour
{
    public bool isSTHOn = false;
    public int sequence;
    public string letter;

    private void Start()
    {
        TextMeshPro childScript = transform.GetChild(1).GetComponent<TextMeshPro>();

        letter = childScript.text;

    }

}
