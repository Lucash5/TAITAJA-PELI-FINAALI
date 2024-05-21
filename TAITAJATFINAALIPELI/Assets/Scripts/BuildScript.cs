using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour
{
    public Statistics statistics;
    public Button[] builds;
    private Sprite selectedbuilding;
    // Start is called before the first frame update
    void Start()
    {
        //  if (Olli.watching == true) {hide.code == true}
        selectedbuilding = builds[2].image.sprite;
        builds[0].onClick.AddListener(apartmentbuilding);
        builds[1].onClick.AddListener(park);
        builds[2].onClick.AddListener(road);
        builds[3].onClick.AddListener(windpowerplant);
    }
    private void apartmentbuilding() { switchbuilding(builds[0].image.sprite); }
    private void park() { switchbuilding(builds[1].image.sprite); }
    private void road() { switchbuilding(builds[2].image.sprite); }
    private void windpowerplant() { switchbuilding(builds[3].image.sprite); }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = selectedbuilding;
                if (selectedbuilding.name == "ApartmentBuilding")
                {
                    //statistics.AmountOfBuildings += 1;
                    hit.collider.gameObject.name = selectedbuilding.name;
                }
                else if (selectedbuilding.name == "WindPowerPlant")
                {
                    //selectedbuilding.GetComponent<GameObject>().AddComponent<PowerPlantScript>();
                    hit.collider.gameObject.name = "WindPowerPlant";
                    hit.collider.AddComponent<PowerPlantScript>();
                    hit.collider.GetComponent<PowerPlantScript>().statistics = statistics;
                }
            }
        }
        

    }

    private void switchbuilding(Sprite build)
    {
        Debug.Log("Selected");
        selectedbuilding = build;
    }

}
