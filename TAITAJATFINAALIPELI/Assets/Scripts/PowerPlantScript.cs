using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantScript : MonoBehaviour
{
    public Statistics statistics;
    private float powerplantrange;
    private Transform map;
    // Start is called before the first frame update 1.75
    void Start()
    {
        if (gameObject.name == "WindPowerPlant")
        {
            powerplantrange = 1.75f;
        }

        map = transform.parent;

        for (int i = 0; i < map.transform.childCount; i++)
        {
            Debug.Log(Vector2.Distance(transform.position, map.transform.GetChild(i).transform.position));
            if (map.transform.GetChild(i).gameObject.name == "ApartmentBuilding" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < powerplantrange && map.transform.GetChild(i).name != "ApartmentBuildingActive")
            {
                map.transform.GetChild(i).gameObject.name = "ApartmentBuildingActive";
                statistics.AmountOfBuildings += 1;
            }
        }
    }

// Update is called once per frame && Vector2.Distance(transform.position, map.transform.GetChild(i).transform.position) < powerplantrange &&
void Update()
    {
        
    }
}
