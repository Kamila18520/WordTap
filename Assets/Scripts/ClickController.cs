using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Zmienia pozycjê naciœniêtego Kwadratu na pierwszy wolny prefab na polu do uk³adania s³owa. 
Jeœli naciœnie go spowrotem, kwadratz literk¹ wraca na kó³ko




----------------------------------------------------------------------------------------------------------- */

public class ClickController : MonoBehaviour
{
    public bool inOnRightPosition = false;
    private bool isSet = false;
    private Vector3 actualPosition;
    private Vector3 newPosition;

    private int childCount;
    private int childSequence = 0;
    public int squareSequence;
    public string char1;
    public string char2;

    private void Start()
    {
        actualPosition = transform.position;
        GameObject squareWithoutLetters = GameObject.Find("ContainerForSquaresWithoutLetters");
        childCount = squareWithoutLetters.transform.childCount;
    }

    public void OnMouseDown()
    {
        if (!isSet)
        {
            Debug.Log("Przycisk zosta³ naciœniêty || Nowa pozycja");
            newPosition = DownloadPosition();
            StartCoroutine(MoveToNewPosition(newPosition));
            isSet = true;
        }
        else
        {
            Debug.Log("Przycisk zosta³ naciœniêty || Wraca do starej pozycji");
            StartCoroutine(MoveToNewPosition(actualPosition));
            BackSquareToFalse();
            isSet = false;
        }
    }

    private void BackSquareToFalse()
    {
        GameObject squareWithoutLetters = GameObject.Find("ContainerForSquaresWithoutLetters");
        Transform childTransform = squareWithoutLetters.transform.GetChild(childSequence - 1);
        SquareForLetters sequenceComponent = childTransform.GetComponent<SquareForLetters>();
        sequenceComponent.isSTHOn = false;
        inOnRightPosition = false;
    }

    public Vector3 DownloadPosition()
    {
        GameObject squareWithoutLetters = GameObject.Find("ContainerForSquaresWithoutLetters");
        Vector3 childPosition = Vector3.zero;

        for (int i = 0; i < childCount; i++)
        {
            Transform childTransform = squareWithoutLetters.transform.GetChild(i);
            SquareForLetters letter1 = childTransform.GetComponent<SquareForLetters>();
            char1 = letter1.letter;

            Sequence letter2 = gameObject.GetComponent<Sequence>();
            char2 = letter2.letter;

            SquareForLetters sequenceComponent = childTransform.GetComponent<SquareForLetters>();

            if (sequenceComponent.isSTHOn == false)
            {
                childPosition = childTransform.position;
                sequenceComponent.isSTHOn = true;
                childSequence = sequenceComponent.sequence;
                Debug.Log("Kwadrat wskoczy³ na miejsce nr " + childSequence);

                if (char1 == char2)
                {
                    inOnRightPosition = true;
                }

                break;
            }
        }

        return childPosition;
    }

    private IEnumerator MoveToNewPosition(Vector3 targetPosition)
    {
        float elapsedTime = 0f;
        float moveTime = 0.15f; // Czas trwania animacji przesuniêcia

        Vector3 startingPosition = transform.position;

        while (elapsedTime < moveTime)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / moveTime);

            // Interpolacja liniowa pomiêdzy aktualn¹ pozycj¹ a docelow¹ pozycj¹
            transform.position = Vector3.Lerp(startingPosition, targetPosition, t);

            yield return null;
        }

        transform.position = targetPosition;
    }
}
