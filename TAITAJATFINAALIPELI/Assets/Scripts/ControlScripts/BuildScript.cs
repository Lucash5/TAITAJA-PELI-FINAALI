using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BuildScript : MonoBehaviour
{
    private float price;

    private Transform map;
    public Statistics statistics;
    public Button[] builds;
    private Sprite selectedbuilding;
    public Sprite GrassPlain;
    // Start is called before the first frame update
    void Start()
    {
        map = gameObject.transform;
        //  if (Olli.watching == true) {hide.code == true}
        selectedbuilding = builds[2].image.sprite;
        builds[0].onClick.AddListener(apartmentbuilding);
        builds[1].onClick.AddListener(park);
        builds[2].onClick.AddListener(road);
        builds[3].onClick.AddListener(windpowerplant);
        builds[4].onClick.AddListener(coalpowerplant);
        builds[5].onClick.AddListener(grassplain);
    }
    private void apartmentbuilding() { switchbuilding(builds[0].image.sprite); }
    private void park() { switchbuilding(builds[1].image.sprite); }
    private void road() { switchbuilding(builds[2].image.sprite); }
    private void windpowerplant() { switchbuilding(builds[3].image.sprite); }
    private void coalpowerplant() { switchbuilding(builds[4].image.sprite); }
    private void grassplain() { switchbuilding(GrassPlain); }
    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            
            if (hit.collider != null)
            {
                if (selectedbuilding.name == "CoalPowerPlant") {price = 10500;}
                if (selectedbuilding.name == "WindPowerPlant") { price = 9750; }
                if (selectedbuilding.name == "SolarPowerPlant") { price = 6000; }
                if (selectedbuilding.name == "Road") { price = 2500; }
                if (selectedbuilding.name == "ApartmentBuilding") { price = 15000; }

                if (selectedbuilding.name == "GrassPlain")
                {
                    if (hit.collider.gameObject.name == "CoalPowerPlant") { price = 10500 * 0.25f; }
                    if (hit.collider.gameObject.name == "WindPowerPlant") { price = 9750 * 0.25f; }
                    if (hit.collider.gameObject.name == "SolarPowerPlant") { price = 6000 * 0.25f; }
                    if (hit.collider.gameObject.name == "Road") { price = 2500 * 0.25f; }
                    if (hit.collider.gameObject.name == "ApartmentBuilding") { price = 15000 * 0.25f; }
                }


                if (statistics.Funds >= price && hit.collider.gameObject.name != selectedbuilding.name)
                {
                    statistics.Funds -= price;
                hit.collider.gameObject.GetComponent<SpriteRenderer>().sprite = selectedbuilding;

                if(hit.collider.GetComponent<RoadScript>() != null)
                {
                    Destroy(hit.collider.gameObject.GetComponent<RoadScript>());

                    for (int i = 0; i < map.transform.childCount; i++)
                    {
                        if (map.transform.GetChild(i).gameObject.name == "ApartmentBuildingActive" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < 1.05f)
                        {
                            map.transform.GetChild(i).gameObject.name = "ApartmentBuildingPowered";
                            statistics.AmountOfBuildings -= 1;
                        }
                    }
                }
                else if (hit.collider.GetComponent<PowerPlantScript>() != null)
                {

                    for (int i = 0; i < map.transform.childCount; i++)
                    {
                        if ((map.transform.GetChild(i).gameObject.name == "ApartmentBuildingActive" || map.transform.GetChild(i).gameObject.name == "ApartmentBuildingPowered") && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < hit.collider.gameObject.GetComponent<PowerPlantScript>().powerplantrange)
                        {
                            map.transform.GetChild(i).gameObject.name = "ApartmentBuilding";
                            statistics.AmountOfBuildings -= 1;
                        }
                    }
                    Destroy(hit.collider.gameObject.GetComponent<PowerPlantScript>());
                }


                    if (selectedbuilding.name == "ApartmentBuilding")
                    {
                        //statistics.AmountOfBuildings += 1;
                        hit.collider.gameObject.name = selectedbuilding.name;
                    }
                    else if (selectedbuilding.name == "WindPowerPlant")
                    {
                        //selectedbuilding.GetComponent<GameObject>().AddComponent<PowerPlantScript>();
                        hit.collider.gameObject.name = selectedbuilding.name;
                        hit.collider.AddComponent<PowerPlantScript>();
                        hit.collider.GetComponent<PowerPlantScript>().statistics = statistics;
                    }
                    else if (selectedbuilding.name == "Road")
                    {
                        hit.collider.gameObject.name = selectedbuilding.name;
                        hit.collider.AddComponent<RoadScript>();
                        hit.collider.GetComponent<RoadScript>().statistics = statistics;
                    }
                    else if (selectedbuilding.name == "CoalPowerPlant")
                    {
                        hit.collider.gameObject.name = selectedbuilding.name;
                        hit.collider.AddComponent<PowerPlantScript>();
                        hit.collider.GetComponent<PowerPlantScript>().statistics = statistics;
                    }
                    else if (selectedbuilding.name == "GrassPlain")
                    {
                        hit.collider.gameObject.name = selectedbuilding.name;
                    }
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
