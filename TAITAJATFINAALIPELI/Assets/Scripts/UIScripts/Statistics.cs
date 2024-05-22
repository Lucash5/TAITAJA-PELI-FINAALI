using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Statistics : MonoBehaviour
{
    public TMP_Text popularity;
    public TMP_Text funds;
    public TMP_Text pollution;
    public TMP_Text decisionpower;
    public TMP_Text emissions;
    public TMP_Text powerproduction;
    public TMP_Text sustainability;
    public TMP_Text buildings;

    public float PoliticalDecisionPower;

    public float Funds;
    public float TaxRate;

    public float EmissionAmount;
    public float PollutionDissapationRate;

    public float PowerProduction;
    public float CleanPowerProduction;

    public float AmountOfBuildings;

    public float Popularity;

    public float Pollution;
    public float SelfSustainability;

    private bool TaxBool;
    private bool PollutionBool;
    private bool PopularityBool;
    private bool PDPBool;
    private bool aaaa;
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
        if (!aaaa) { StartCoroutine(SustainabilityCooldown()); }

        if (Funds >= 1000000 && Pollution <= 0 && SelfSustainability >= 1)
        {
            SceneManager.LoadScene("EndScene");
        }

        popularity.text = "Popularity : " + Popularity.ToString();
        funds.text = "Funds : " + Funds.ToString();
        emissions.text = "Emissions : " + EmissionAmount.ToString() + "/s";
        powerproduction.text = "PowerP : " + PowerProduction.ToString();
        buildings.text = "Buildings : " + AmountOfBuildings.ToString();
        sustainability.text = "Sustainability : " + (SelfSustainability * 100).ToString() + "%";
        decisionpower.text = "DecisionPower : " + PoliticalDecisionPower.ToString();
        pollution.text = "Pollution : " + Pollution.ToString();

    }

    IEnumerator TaxCoolDown()
    {
        TaxBool = true;
        yield return new WaitForSeconds(5);
        Funds += AmountOfBuildings * 10000 * TaxRate * Popularity;
        TaxBool = false;
        Funds = Mathf.Round(Funds);
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

    IEnumerator SustainabilityCooldown()
    {
        aaaa = true;
        yield return new WaitForSeconds(5);
        SelfSustainability = CleanPowerProduction / PowerProduction;
        aaaa = false;
    }

}
