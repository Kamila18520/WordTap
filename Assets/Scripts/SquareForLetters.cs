using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:
Przypisuje warto�ci do prefabu na kt�ry b�dzie wskakiwa� prefab z Literk�






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
