using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statistics : MonoBehaviour
{
    public float PoliticalDecisionPower;

    public float Funds;
    public float TaxRate;

    public float AmountOfBuildings;

    public float Popularity;

    private bool TaxBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TaxBool) { StartCoroutine(TaxCoolDown()); }
    }

    IEnumerator TaxCoolDown()
    {
        TaxBool = true;
        yield return new WaitForSeconds(5);
        Funds += AmountOfBuildings * 100 * TaxRate;
        TaxBool = false;
    }
}
