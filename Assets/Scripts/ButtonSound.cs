using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*-----------------------------------------------------------------------------------------------------------
Ten kod:

Odpowiada za dŸwiêk wydawany po naciœniêciu na przycisk




----------------------------------------------------------------------------------------------------------- */

public class ButtonSound : MonoBehaviour
{

    public AudioSource source;
    public Button button;

    public void Awake()
    {
        if(button == null) 
        {
         button = gameObject.GetComponent<Button>();
        }
        button.onClick.AddListener(ClickSound);
        
    }
    public void ClickSound()
    {

        source.Play();
        
    }

}
