using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrastructureScanner : MonoBehaviour
{
    public Statistics statistics;
    bool roadfound;
    bool powerfound;
    bool productivebuildingfound;
    private bool cooldownbool;
    public Transform map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (cooldownbool == false)
        {
            StartCoroutine(cooldown());
        }
    }

    IEnumerator cooldown()
    {
        cooldownbool = true;
        yield return new WaitForSeconds(5);
        cooldownbool = false;
        for (int i = 0; i < map.childCount; i++)
        {
            if (map.GetChild(i).gameObject.name == "ApartmentBuildingActive" || map.GetChild(i).gameObject.name == "ApartmentBuildingPowered")
            {

                if (map.GetChild(i).gameObject.name == "ApartmentBuildingPowered")
                {
                    productivebuildingfound = true;
                }



                for (int o = 0; o < map.childCount; o++)
                {
                    
                    if (map.GetChild(o).gameObject.name == "Road" && Vector2.Distance(map.transform.GetChild(o).transform.position, transform.position) < 1.05f)
                    {
                        roadfound = true;
                    }
                    if ((map.GetChild(o).gameObject.name == "WindPowerPlant" && Vector2.Distance(map.transform.GetChild(o).transform.position, transform.position) < 1.75f) || (map.GetChild(o).gameObject.name == "SolarPowerPlant" && Vector2.Distance(map.transform.GetChild(o).transform.position, transform.position) < 1.01f) || (map.GetChild(o).gameObject.name == "CoalPowerPlant" && Vector2.Distance(map.transform.GetChild(o).transform.position, transform.position) < 2.85f))
                    {
                        powerfound = true;
                    }

                    if (powerfound && roadfound)
                    {
                        map.GetChild(i).gameObject.name = "ApartmentBuildingActive";
                    }
                    else if (powerfound && !roadfound)
                    {
                        map.GetChild(i).gameObject.name = "ApartmentBuildingPowered";
                    }
                    else if (productivebuildingfound)
                    {
                        statistics.AmountOfBuildings -= 1;
                    }
                    else
                    {
                        map.GetChild(i).gameObject.name = "ApartmentBuilding";
                    }

                    roadfound = false;
                    powerfound = false;
                    productivebuildingfound = false;
                }
            }
        }
    }
}
