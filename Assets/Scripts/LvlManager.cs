using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Zarz¹dza przechodzeniem pomiêdzy scenami oraz w samym menu pomiêdzy Start/Mode/Lvl




----------------------------------------------------------------------------------------------------------- */

public class LvlManager : MonoBehaviour
{

    [SerializeField] GameObject lvls;
    [SerializeField] GameObject start;
    [SerializeField] GameObject mode;

    public void ChoseMode()
    {
        mode.SetActive(true);
        start.SetActive(false);
        lvls.SetActive(false);
        PlayerPrefs.SetInt("LastLvl", 0);
    }

    public void GoLvl()
    {
        mode.SetActive(false);
        lvls.SetActive(true);
        start.SetActive(false);
    }

    public void LoadLvl()
    {
        SceneManager.LoadScene(1);
    }


    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

}
