using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerPlantScript : MonoBehaviour
{
    public Statistics statistics;
    public float powerplantrange;
    private Transform map;


    bool coal;

    private bool Refresh;

    private float powerproduction;
    // Start is called before the first frame update 1.75
    private void OnDestroy()
    {
        statistics.PowerProduction -= powerproduction;
        if (coal == true)
        {
            statistics.EmissionAmount -= 100;
        }
    }
    void Start()
    {
        if (gameObject.name == "WindPowerPlant")
        {
            powerplantrange = 1.75f;
            statistics.PowerProduction += 320;
            statistics.CleanPowerProduction += 320;
            powerproduction = 320;
        }
        else if (gameObject.name == "CoalPowerPlant")
        {
            coal = true;
            powerplantrange = 2.85f;
            statistics.EmissionAmount += 100;
            statistics.PowerProduction += 1000;
            statistics.DirtyPowerProduction += 1000;
            powerproduction = 1000;
        }
        else if (gameObject.name == "SolarPowerPlant")
        {
            powerplantrange = 1.01f;
            statistics.PowerProduction += 160;
            statistics.CleanPowerProduction += 160;
            powerproduction = 160;
        }


        map = transform.parent;

        for (int i = 0; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).gameObject.name == "ApartmentBuilding" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < powerplantrange)
            {
                map.transform.GetChild(i).gameObject.name = "ApartmentBuildingPowered";
                //statistics.AmountOfBuildings += 1;
            }
        }
    }

// Update is called once per frame && Vector2.Distance(transform.position, map.transform.GetChild(i).transform.position) < powerplantrange &&
    void Update()
    {
        if (!Refresh) {StartCoroutine(CheckForBuildings());}
    }

    IEnumerator CheckForBuildings()
    {
        Refresh = true;
        yield return new WaitForSeconds(5);
        for (int i = 0; i < map.transform.childCount; i++)
        {
            if (map.transform.GetChild(i).gameObject.name == "ApartmentBuilding" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < powerplantrange && map.transform.GetChild(i).name != "ApartmentBuildingActive")
            {
                map.transform.GetChild(i).gameObject.name = "ApartmentBuildingPowered";
                //statistics.AmountOfBuildings += 1;
            }
        }
        Refresh = false;
    }
}
