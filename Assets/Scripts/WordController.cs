using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Odpowiada za klonowanie prefabów i przypisania im
1.Randomowego miejsca na kole jeœli jest to kwadrat z literk¹
2.Miejsca pustego prefabu na kwadracie na którym uk³ada siê literki




----------------------------------------------------------------------------------------------------------- */

public class WordController : MonoBehaviour
{
    [SerializeField] string chosenWord2;
    private char[] chosenLetters;
    private int wordLenght;

    //Prefaby do klonowania
    [SerializeField] private GameObject wordSquarePrefab;
    [SerializeField] private GameObject wordSquareForLettersPrefab;

    //Kontenerydla sklonowanych prefabów
    [SerializeField] private GameObject ContainerForSquaresWithLetters;
    [SerializeField] private GameObject ContainerForSquaresWithoutLetters;
    private float areaSize;
    private float wordSquareSize;
    private float radius; // Promieñ okrêgu
   // public int[] randomPosition;
    public bool[] positionOnCircle;








    void Start()
    {
        
        //Znajdowanie obiektów na których bêd¹ nasze klony
        GameObject lettersArea = GameObject.Find("AreaForLetters");
        GameObject spawnArea = GameObject.Find("Circle");



        Renderer renderer = lettersArea.GetComponent<Renderer>();
       // Vector3 rightmostPoint = renderer.bounds.min;

        Renderer wordSquare = wordSquareForLettersPrefab.GetComponent<Renderer>();
        Renderer spawnAreaSize = spawnArea.GetComponent<Renderer>();

        radius = spawnAreaSize.bounds.size.x / 2f;
        wordSquareSize = wordSquare.bounds.size.x;


        Debug.Log("Szerokoœæ prefabu" + wordSquareSize);
        //Debug.Log("pkt wysuniêty na lewo: " + rightmostPoint);



        areaSize = renderer.bounds.size.x;
        Debug.Log("D³ugoœæ Areny: " + areaSize);


        
        SplitWord();
        DuplicatePrefab(GetChoosenLetters());
       
    }



    private void SplitWord()
    {

        //Pobieranie s³owa wybranego w GameManagerze
        chosenWord2 = GameManager.choosenWord;
        Debug.Log("Slowo wybrane w GameManagerze to " + chosenWord2);

        //Podzia³ s³owa na litery i wyœwietlenie ich na konsoli
        chosenLetters = chosenWord2.ToCharArray();

        foreach(char c in chosenLetters) 
        {
            Debug.Log(c);
        }

        
        wordLenght = chosenWord2.Length;

        
        // deklarowanie wieloœci tablicy i ustawianie wszytskich wartoœci na false
        positionOnCircle = new bool[wordLenght];
        for (int i=0; i<wordLenght; i++) 
        { 
            positionOnCircle[i] = false;
        }
       

    }

    private char[] GetChoosenLetters()
    {
        return chosenLetters;
    }

    private void DuplicatePrefab(char[] choosenLetters)
    {
        for (int i = 1; i <= wordLenght; i++)
        {
           
            //Generowanie randomowego po³o¿enia klonu prefabu z literk¹
           int randomNumber = RandomIndex();
           Debug.Log("Wylosowana liczba to: " + randomNumber);

            //okreœlanie wektorów do klonów
            Vector3 circlePosition = PositionOnCircle(randomNumber);
            Vector3 lettersPosition = GetLetterPositionOnSquare(i); // Przekazanie wartoœci i
            

            //klonowanie prefabów
            GameObject PrefabCloneForLetters = Instantiate(wordSquareForLettersPrefab, lettersPosition, wordSquareForLettersPrefab.transform.rotation, ContainerForSquaresWithoutLetters.transform);
            GameObject PrefabClone = Instantiate(wordSquarePrefab, circlePosition, wordSquarePrefab.transform.rotation, ContainerForSquaresWithLetters.transform);

             

            //przypisywanie indeksu do klonów

            PrefabCloneForLetters.GetComponent<SquareForLetters>().sequence = i;
            PrefabClone.GetComponent<Sequence>().sequence = i;
            PrefabClone.GetComponent<ClickController>().squareSequence = i;


            //przypisywanie literki do TMP i sortinglayer
            PrefabClone.transform.GetChild(0).GetComponent<TMP_Text>().text = choosenLetters[i - 1].ToString();
            PrefabCloneForLetters.transform.GetChild(1).GetComponent<TMP_Text>().text = choosenLetters[i - 1].ToString();
            PrefabClone.transform.GetChild(0).GetComponent<TMP_Text>().gameObject.GetComponent<Renderer>().sortingOrder = 2;

            Debug.Log("Zostal wygenerowany klon");
        }
    }

    private int RandomIndex()
    {
        int randomValue;

        do
        {
            randomValue = Random.Range(0, wordLenght);

            if (positionOnCircle[randomValue] == false)
            {
                positionOnCircle[randomValue] = true;
                break; 
            }

        }
        while (true);

        return randomValue;
    }

    private Vector3 GetLetterPositionOnSquare(int index) // Dodanie parametru `int index`
    {
        GameObject lettersArea = GameObject.Find("AreaForLetters");


        Vector3 squareSizeMin = lettersArea.GetComponent<Renderer>().bounds.min;
        Vector3 squareSizeCenter = lettersArea.GetComponent<Renderer>().bounds.center;

        //Debug.Log("Min" + squareSizeMin);
       // Debug.Log("Max" + squareSizeCenter);
        

        float positionY = squareSizeCenter.y ;
        float positionX = squareSizeMin.x;

        float partsOfAreaSize = areaSize / (wordLenght*2);

       // Debug.Log("odleg³oœæ" + partsOfAreaSize);

        Vector3 lettersPosition = new Vector3(positionX + ((index-1) * (partsOfAreaSize*2)) + partsOfAreaSize, positionY , 0);

       // Debug.Log("wektor: " + lettersPosition);



        return lettersPosition;
    }


    // Vektor do ustalania pozycji na kole
    private Vector3 PositionOnCircle(int index)
    {

        Vector3 spawnPosition;
        GameObject spawnArea = GameObject.Find("Circle");

            float angleStep = 360.0f / wordLenght;
       
            float angle = (index) * angleStep;
            float radians = angle * Mathf.Deg2Rad; // Zamiana na radiany

            float x = Mathf.Cos(radians) * radius; // Obliczenie wspó³rzêdnej x
            float y = Mathf.Sin(radians) * radius; // Obliczenie wspó³rzêdnej y

            spawnPosition = spawnArea.transform.position + new Vector3(x, y, -1f);
            positionOnCircle[index] = true;


        return spawnPosition;
    }

}
