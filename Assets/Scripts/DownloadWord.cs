using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Dzia³a w Menu

zarz¹dza przypisaniem trybu i poziomu trudnoœci pobieranych w nastêpnej scenie

wyœwietla najwy¿szy osiagniety lvl zale¿nie od wybranego trybu




----------------------------------------------------------------------------------------------------------- */

public class DownloadWord : MonoBehaviour
{
    public static string difficulty;
    public static string mode;
    [SerializeField] private Button[] LvlButtons;


    public void ChallengeMode()
    {
        mode = "Challenge";
        Debug.Log("Tryb: CHALLENGE");

            LvlButtons[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("ChallengeEasy"); ;
            LvlButtons[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("ChallengeMedium");
            LvlButtons[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("ChallengeHard");


    }


    public void PeacefulMode()
    {
        mode = "Peaceful";
        Debug.Log("Tryb: Peaceful"); 
        
            LvlButtons[0].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("PeacefulEasy");
            LvlButtons[1].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("PeacefulMedium");
            LvlButtons[2].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "highest lvl: " + PlayerPrefs.GetInt("PeacefulHard");
    }

    public void EasyWord()
    { 

        difficulty = "Easy";
        

    }


    public void MediumWord()
    {

        difficulty = "Medium";
        

    }

    public void HardWord()
    {

        difficulty = "Hard";
        
    }


}
