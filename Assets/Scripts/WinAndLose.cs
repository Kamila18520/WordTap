using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:


Sprawdza czy w skrypt ChildrenCheck znajduj¹cy siê w Checker (który sprawdza czy s³owo jest poprawnie u³o¿one) posiada bool allChildrenAreOn == true
jesli tak, gracz wygrywa gre


----------------------------------------------------------------------------------------------------------- */

public class WinAndLose : MonoBehaviour
{
    [SerializeField] GameObject Checker;
   [SerializeField] GameObject Screen;
    [SerializeField] GameObject Buttons;
    [SerializeField] private GameObject Timer;



    public bool isWin = false;
    void Start()
    {
        

        if (Screen != null) 
        {
        Screen.SetActive(false);
        }
        
    }

    void Update()
    {
         Win();

    }

    private void Win()
    {        
        if (Checker.GetComponent<ChildrenCheck>().allChildrenAreOn == true)
        {
          Screen.SetActive(true);
            Buttons.SetActive(false);
            Timer.SetActive(false);
            

            isWin = true;


            Invoke("ReloadScene", 2f);
            

            Debug.Log("Gracz wygra³ gre");
           

            
        }
        else Debug.Log("Gra nadal trwa");
    }

    public void ReloadScene()
    {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);

    }


}
