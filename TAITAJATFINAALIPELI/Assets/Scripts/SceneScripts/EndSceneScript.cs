using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndSceneScript : MonoBehaviour
{
    public Button backtomenu;
    // Start is called before the first frame update
    void Start()
    {
        backtomenu.onClick.AddListener(menu);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
