using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

timer trybu Challenge
jesli czas siê skoñczy to wyœwietla sie GameOver



----------------------------------------------------------------------------------------------------------- */

public class ModeController : MonoBehaviour
{
    [SerializeField] string chosenMode;
    [SerializeField] float countdownTime = 5.0f;
    [SerializeField] int timeInInt;
    [SerializeField] GameObject GameOverScreen;
    [SerializeField] private GameObject GameManager;
    [SerializeField] private GameObject BackToMenuButton;
    [SerializeField] private GameObject Timer;
    [SerializeField] private GameObject ContainerWithLetters;
    [SerializeField] private float initialScaleX;
    [SerializeField] private float initialScaleY;
    [SerializeField] private float targetScaleX = 0f;
    [SerializeField] private float scaleDuration;

    private Vector3 initialScale;
    private float elapsedTime;

    private Transform firstChild;

    void Start()
    {
        initialScaleX = gameObject.transform.GetChild(0).localScale.x;
        initialScaleY = gameObject.transform.GetChild(0).localScale.y;

        scaleDuration = countdownTime;

        GameOverScreen.SetActive(false);
        chosenMode = DownloadWord.mode;
        if (chosenMode == "Peaceful")
        {
            gameObject.SetActive(false);
        }

        initialScale = transform.localScale;
        firstChild = transform.GetChild(0);
    }

    void Update()
    {
        countdownTime -= Time.deltaTime; // Odejmowanie czasu odliczania
        timeInInt = Mathf.RoundToInt(countdownTime);
        gameObject.GetComponent<TextMeshPro>().text = timeInInt.ToString();

        if (countdownTime <= 0f)
        {
            countdownTime = 0f; // Zapobieganie ujemnemu czasowi odliczania
            Debug.Log("CHALLENGE MODE: Czas min¹³!"); // Wyœwietlenie komunikatu po zakoñczeniu odliczania

            GameOverScreen.SetActive(true);
            BackToMenuButton.SetActive(true);
            Timer.SetActive(false);

            // Wy³¹cza collidery dzieci konteneru, ¿eby nie mo¿na by³o ich klikn¹æ
            foreach (Transform child in ContainerWithLetters.transform)
            {
                BoxCollider2D boxCollider2d = child.GetComponent<BoxCollider2D>();
                boxCollider2d.enabled = false;
            }

            GameManager.GetComponent<GameManager>().endGame = true;
        }
        else
        {
            // Skalowanie pierwszego dziecka wzd³u¿ osi X wraz z up³ywem czasu
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / scaleDuration);
            float scaleX = Mathf.Lerp(initialScaleX, targetScaleX, t);
            firstChild.localScale = new Vector3(scaleX, initialScaleY, initialScale.z);
        }
    }
}
