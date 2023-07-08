using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Losuje s�owo zale�nie od wybranego poziomu trudno�ci
Obs�uguje przypadek �eby nie wylosowa�o sie to samo s�owo pod rz�d w grze, dzieje si� to w WordCheck()



----------------------------------------------------------------------------------------------------------- */

public class GameManager : MonoBehaviour
{

    private int numberOfLines;
    private int randomNumber;
    public static string choosenWord;
    public static string difficulty;


    public string word;

    public bool endGame=false;

    public void Start()
    {

        difficulty = DownloadWord.difficulty;

        if(difficulty == "Easy")
        { 
            EasyWord();
        }
        else if (difficulty == "Medium")
        {
            MediumWord();
        }
        else if (difficulty == "Hard")
        {
            HardWord();
        }

    }

    public void EndGameByButton()
    {
        endGame= true;
    }


    public void EasyWord()
    {

        TextAsset textEasy = Resources.Load<TextAsset>("Easy");

        string[] linesEasy = textEasy.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        numberOfLines = linesEasy.Length;
        randomNumber = UnityEngine.Random.Range(0, numberOfLines);
        choosenWord = linesEasy[randomNumber];

        Debug.Log("INFORMACYJNIE S�owo w grze to: " + choosenWord);
        Debug.Log("INFORMACYJNIE SDlugosc slowa to: " + choosenWord.Length);
        word = choosenWord;

        WordCheck();

        
        

    }


    public void MediumWord()
    {
        TextAsset textEasy = Resources.Load<TextAsset>("Medium");
        
        string[] linesEasy = textEasy.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        numberOfLines = linesEasy.Length;


        randomNumber = UnityEngine.Random.Range(0, numberOfLines);

        choosenWord = linesEasy[randomNumber];
        Debug.Log("INFORMACYJNIE S�owo w grze to: " + choosenWord);
        Debug.Log("INFORMACYJNIE Dlugosc slowa to: " + choosenWord.Length);
        word = choosenWord;
       // PlayerPrefs.SetString("LastWord", word);
        WordCheck();
    }

    public void HardWord()
    {
        TextAsset textEasy = Resources.Load<TextAsset>("Hard");
        string[] linesEasy = textEasy.text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        numberOfLines = linesEasy.Length;


        randomNumber = UnityEngine.Random.Range(0, numberOfLines);
        choosenWord = linesEasy[randomNumber];
        Debug.Log("INFORMACYJNIE S�owo w grze to: " + choosenWord);
        Debug.Log("INFORMACYJNIE Dlugosc slowa to: " + choosenWord.Length);
        word = choosenWord;
       // PlayerPrefs.SetString("LastWord", word);
        WordCheck();
    }


    private void WordCheck()
    {
        if (PlayerPrefs.GetString("LastWord") == word)
        {
            Start();
        }
        else PlayerPrefs.SetString("LastWord", word);
    }


}
