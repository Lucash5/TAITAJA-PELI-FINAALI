using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public Button ReturnButton;
    public Button Guide;
    public Image GuidePanel;
    public Image MainMenuPanel;
    // Start is called before the first frame update
    void Start()
    {
        Guide.onClick.AddListener(OpenGuide);
        ReturnButton.onClick.AddListener(CloseGuide);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OpenGuide()
    {
        GuidePanel.gameObject.SetActive(true);
        MainMenuPanel.gameObject.SetActive(false);
    }
    private void CloseGuide()
    {
        GuidePanel.gameObject.SetActive(false);
        MainMenuPanel.gameObject.SetActive(true);
    }
}
