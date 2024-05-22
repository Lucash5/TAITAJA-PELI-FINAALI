using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadScript : MonoBehaviour
{
    public Statistics statistics;
    private float RoadReach;
    private Transform map;


    private bool Refresh;
    // Start is called before the first frame update 1.75
    void Start()
    {
        
        RoadReach = 1.05f;
        



        map = transform.parent;

        for (int i = 0; i < map.transform.childCount; i++)
        {
           
            if (map.transform.GetChild(i).gameObject.name == "ApartmentBuildingPowered" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < RoadReach)
            {
                map.transform.GetChild(i).gameObject.name = "ApartmentBuildingActive";
                statistics.AmountOfBuildings += 1;
            }
        }
    }

    // Update is called once per frame && Vector2.Distance(transform.position, map.transform.GetChild(i).transform.position) < powerplantrange &&
    void Update()
    {
        if (!Refresh) { StartCoroutine(CheckForBuildings()); }
    }

    IEnumerator CheckForBuildings()
    {
        Refresh = true;
        yield return new WaitForSeconds(10);
        for (int i = 0; i < map.childCount; i++)
        {
            if (map.transform.GetChild(i).gameObject.name != "GrassPlain" && map.transform.GetChild(i).gameObject.name == "ApartmentBuildingPowered" && Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position) < RoadReach)
            {
                Debug.Log(Vector2.Distance(map.transform.GetChild(i).transform.position, transform.position));
                map.transform.GetChild(i).gameObject.name = "ApartmentBuildingActive";
                statistics.AmountOfBuildings += 1;
            }
        }
        Refresh = false;
    }
}
