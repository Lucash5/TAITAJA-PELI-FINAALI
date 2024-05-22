using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ImageHoverOverScript : MonoBehaviour
{
    public Image img;
    public TMP_Text information;
    public string heldinformation;
    void Update()
    {
        if (Vector2.Distance(transform.position, Input.mousePosition) < 90f)
        {
            information.text = heldinformation;
            img.enabled = true;
            
        }


        
    }
}
