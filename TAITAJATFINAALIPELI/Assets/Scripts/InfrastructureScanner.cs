using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfrastructureScanner : MonoBehaviour
{
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
            if (map.GetChild(i).gameObject.name == "ApartmentBuilding" || map.GetChild(i).gameObject.name == "ApartmentBuildingPower" || map.GetChild(i).gameObject.name == "ApartmentBuildingRoad" || map.GetChild(i).gameObject.name == "ApartmentBuildingPower&Road")
            {
                for (int j = 0; j < map.childCount; j++)
                {

                }
            }
        }
    }
}
