using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{
    public float PoliticalDecisionPower;

    public float Funds;
    public float TaxRate;

    public float EmissionAmount;
    public float PollutionDissapationRate;

    public float PowerProduction;

    public float AmountOfBuildings;

    public float Popularity;

    public float Pollution;
    public float SelfSustainability;

    private bool TaxBool;
    private bool PollutionBool;
    private bool PopularityBool;
    private bool PDPBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!TaxBool) { StartCoroutine(TaxCoolDown()); }
        if (!PollutionBool) { StartCoroutine(PollutionCoolDown()); }
        if (!PopularityBool) { StartCoroutine(PopularityCoolDown());}
        if (!PDPBool) { StartCoroutine(PDPCoolDown());}

        if (Funds >= 1000000 && Pollution <= 0 && SelfSustainability >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    IEnumerator TaxCoolDown()
    {
        TaxBool = true;
        yield return new WaitForSeconds(5);
        Funds += AmountOfBuildings * 1000 * TaxRate * Popularity;
        TaxBool = false;
    }
    IEnumerator PollutionCoolDown()
    {
        PollutionBool = true;
        yield return new WaitForSeconds(5);
        Pollution += EmissionAmount;
        if (Pollution > 0)
        {
        Pollution -= PollutionDissapationRate;
        }
        else if (Pollution < 0)
        {
            Pollution = 0;
        }
        PollutionBool = false;
    }

    IEnumerator PopularityCoolDown()
    {
        PopularityBool = true;
        yield return new WaitForSeconds(5);
        if (Popularity > 0.1)
        {
        Popularity = Popularity - Pollution * 0.00001f + SelfSustainability * 0.01f;
        }
        else if(Popularity < 0.1)
        {
            Popularity = 0.1f;
        }
        PopularityBool = false;
    }

    IEnumerator PDPCoolDown()
    {
        PDPBool = true;
        yield return new WaitForSeconds(5);
        PoliticalDecisionPower += SelfSustainability * Popularity;
        PDPBool = false;
    }


}
