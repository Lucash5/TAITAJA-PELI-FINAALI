using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour
{
    public Button[] builds;
    private Sprite selectedbuilding;
    // Start is called before the first frame update
    void Start()
    {
        selectedbuilding = builds[2].image.sprite;
        builds[0].onClick.AddListener(apartmentbuilding);
        builds[1].onClick.AddListener(park);
        builds[2].onClick.AddListener(road);
    }
    private void apartmentbuilding() { switchbuilding(builds[0].image.sprite); }
    private void park() { switchbuilding(builds[1].image.sprite); }
    private void road() { switchbuilding(builds[2].image.sprite); }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            Debug.Log(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.transform.position, Camera.main.ScreenToWorldPoint(Input.mousePosition));

            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.transform.position);

                hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = selectedbuilding;
            }
        }
        

    }

    private void switchbuilding(Sprite build)
    {
        Debug.Log("Selected");
        selectedbuilding = build;
    }

}
