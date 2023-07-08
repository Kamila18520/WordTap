using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CongratScreen : MonoBehaviour
{
    [SerializeField] private GameObject Points;
    [SerializeField] private GameObject circle;
    private int currentLvl;

    public void Start()
    {
        gameObject.transform.position = circle.transform.localPosition;
       // gameObject.GetComponent<TextMeshPro>().text = Points.GetComponent<Points>().currentLvl.ToString();


    }

    private void Update()
    {
        gameObject.GetComponent<TextMeshPro>().text = Points.GetComponent<Points>().currentLvl.ToString();
    }
}
