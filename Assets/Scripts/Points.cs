using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:


Obs³uguje czy zmieni³ siê rekord danego levelu
Oraz zarz¹dza informacjami o obecnym lvlu oraz ostatnim lvlu potrzebnym do wyœwietlania info na GameOver screen


----------------------------------------------------------------------------------------------------------- */

public class Points : MonoBehaviour
{
    public int currentLvl;
    public int highestLvl;
    public int lastLvl;

    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject WinCheck;
    [SerializeField] private GameObject CanvasText;

    public static string difficulty;
    public static string chosenMode;



    // Start is called before the first frame update
    void Start()
    {

        difficulty = DownloadWord.difficulty;
        chosenMode = DownloadWord.mode;


        lastLvl = PlayerPrefs.GetInt("LastLvl");
        currentLvl = lastLvl + 1;




        // ustawianie highest lvl na podstawie trybu i poziomu trudnoœci
        if(chosenMode == "Peaceful")
        {       
              if (difficulty == "Easy")
             {
                      highestLvl = PlayerPrefs.GetInt("PeacefulEasy");
             }
             else if (difficulty == "Medium")
              {
                      highestLvl = PlayerPrefs.GetInt("PeacefulMedium");
            }
              else if (difficulty == "Hard")
             {
                     highestLvl = PlayerPrefs.GetInt("PeacefulHard");
            }
        }
        else if (chosenMode =="Challenge")
        {
            if (difficulty == "Easy")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeEasy");
            }
            else if (difficulty == "Medium")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeMedium");
            }
            else if (difficulty == "Hard")
            {
                highestLvl = PlayerPrefs.GetInt("ChallengeHard");
            }
        }

        if(currentLvl > highestLvl) 
        {
            CanvasText.GetComponent<TextMeshProUGUI>().text = "You're beating new record right now!" + "\r\n New Top Level: " + currentLvl.ToString();

        }
        else if(currentLvl < highestLvl)
        { 
        CanvasText.GetComponent<TextMeshProUGUI>().text = "Last highest Lvl: " + highestLvl + "\r\nCurrent Lvl: " + currentLvl.ToString();
        }
        else if( currentLvl == highestLvl)
        {
            CanvasText.GetComponent<TextMeshProUGUI>().text = "Last level to beat your old record! ";
        }

        Debug.Log("Najwy¿szy osi¹gniety lvl: " + highestLvl);


    }

    void Update()
    {
        PointsManager();
        if (lastLvl >= highestLvl)
        {

            highestLvl = lastLvl;
            SetHighestLevel();

        }

    }

    public void PointsManager()
    {
        if (GameManager.GetComponent<GameManager>().endGame == true) 
        { 
            
            PlayerPrefs.SetInt("LastLvl", 0);

        }
        //tu DOME
        else if (WinCheck.GetComponent<WinAndLose>().isWin == true)
        {
            PlayerPrefs.SetInt("LastLvl", currentLvl);

        }
       
    }

    private void SetHighestLevel()
    {
        if (chosenMode == "Peaceful")
        {
            if (difficulty == "Easy")
            {
                
                PlayerPrefs.SetInt("PeacefulEasy", highestLvl);
            }
            else if (difficulty == "Medium")
            {
               
                PlayerPrefs.SetInt("PeacefulMedium", highestLvl);
            }
            else if (difficulty == "Hard")
            {
                PlayerPrefs.SetInt("PeacefulHard", highestLvl);
            }
        }
        else if(chosenMode=="Challenge")
        {
            if (difficulty == "Easy")
            {
                PlayerPrefs.SetInt("ChallengeEasy", highestLvl);
            }
            else if (difficulty == "Medium")
            {
              
                PlayerPrefs.SetInt("ChallengeMedium", highestLvl);
            }
            else if (difficulty == "Hard")
            {

                PlayerPrefs.SetInt("ChallengeHard", highestLvl);
            }
        }
    }


    public void PlayAgain()
    {
       
        PlayerPrefs.SetInt("LastLvl", 0);

    }
}
