using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


/*-----------------------------------------------------------------------------------------------------------
Ten kod:
Obs³uguje ekran GameOver





----------------------------------------------------------------------------------------------------------- */


public class SetHighestLvl : MonoBehaviour
{
    [SerializeField] string chosenWord2;
    [SerializeField] GameObject Points;

    public static string difficulty;
    public static string chosenMode;
    public int pointsLevel;

    void Start()
    {
        Points points = Points.GetComponent<Points>();
        chosenWord2 = GameManager.choosenWord;

        difficulty = DownloadWord.difficulty;
        chosenMode = DownloadWord.mode;


        if (chosenMode == "Peaceful")
        {
            if (difficulty == "Easy")
            {
                pointsLevel = PlayerPrefs.GetInt("PeacefulEasy");
            }
            else if (difficulty == "Medium")
            {
                pointsLevel = PlayerPrefs.GetInt("PeacefulMedium");
            }
            else if (difficulty == "Hard")
            {
                pointsLevel = PlayerPrefs.GetInt("PeacefulHard");
            }
        }
        else
        {
            if (difficulty == "Easy")
            {
                pointsLevel = PlayerPrefs.GetInt("ChallengeEasy");
            }
            else if (difficulty == "Medium")
            {
                pointsLevel = PlayerPrefs.GetInt("ChallengeMedium");
            }
            else if (difficulty == "Hard")
            {
                pointsLevel = PlayerPrefs.GetInt("ChallengeHard");
            }
        }

        if (points.lastLvl > pointsLevel)
        {
            pointsLevel = points.lastLvl;
        }


        gameObject.GetComponent<TextMeshPro>().text = "The word is:\r\n\r\n" + chosenWord2 + "\r\n\r\nYour lvl:\r\n\r\n" + points.lastLvl + "\r\n\r\nYour highest lvl:\r\n\r\n"+ pointsLevel;
        

    }

}
