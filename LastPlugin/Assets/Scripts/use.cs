using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class use : MonoBehaviour
{
    public Image Im;

    public AndroidPlugin AP;

    public void ButtonDwon()
    {
        StartCoroutine(AP.ShowGallery(
            (_tex, _spr)=>
            { Im.sprite = _spr; }
            ));   
    }

}
