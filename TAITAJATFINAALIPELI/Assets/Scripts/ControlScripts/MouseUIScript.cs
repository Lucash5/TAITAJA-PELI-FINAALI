using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MouseUIScript : MonoBehaviour
{
    private bool clearbool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y + 90);
        if (!clearbool) { StartCoroutine(Clear()); }
    }

    IEnumerator Clear()
    {
        clearbool = true;
        yield return new WaitForSeconds(1f);
        GetComponentInChildren<TMP_Text>().text = "";
        GetComponent<Image>().enabled = false;
        clearbool = false;
    }
}
