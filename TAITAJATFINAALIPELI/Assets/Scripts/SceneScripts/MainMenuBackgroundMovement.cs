using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuBackgroundMovement : MonoBehaviour
{
    public Button PlayButton;
    // Start is called before the first frame update
    void Start()
    {
        PlayButton.onClick.AddListener(LoadGame);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2 (transform.position.x + 0.001f, transform.position.y + 0.001f);
    }
    private void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
