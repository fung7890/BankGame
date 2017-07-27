using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scenarios : MonoBehaviour {


    public bool solarOnce = true;
    public bool marketingOnce = true;
    public bool roverOnce = true;
    public bool insuranceOnce = true;
    public bool onOff = true;

    public GameObject solarPanel;
    public GameObject marketingPanel;
    public GameObject roverPanel;
    public GameObject insurancePanel;
    public GameObject stormNoInsurPanel;
    public GameObject stormYesInsurPanel;

    public float countdown;

    PurchaseItems purchaseClass;
    Money moneyClass;


    public void Awake()
    {
        solarPanel = GameObject.FindGameObjectWithTag("solar");
        marketingPanel = GameObject.FindGameObjectWithTag("marketing");
        roverPanel = GameObject.FindGameObjectWithTag("rover");
        insurancePanel = GameObject.FindGameObjectWithTag("insurance");
        stormNoInsurPanel = GameObject.FindGameObjectWithTag("cStormNoInsur");
        stormYesInsurPanel = GameObject.FindGameObjectWithTag("cStormYesInsur");

        purchaseClass = GameObject.Find("Scripts").GetComponent<PurchaseItems>();
        moneyClass = GameObject.Find("Scripts").GetComponent<Money>();


        solarPanel.SetActive(false);
        marketingPanel.SetActive(false);
        roverPanel.SetActive(false);
        insurancePanel.SetActive(false);
        stormNoInsurPanel.SetActive(false);
        stormYesInsurPanel.SetActive(false);

        countdown = Random.Range(15, 25);
    }
    private void Update()
    {
        Storm();
            
    }
   
    public void Links(ref bool openOnce, GameObject panel)
    {
        if (openOnce == true)
        {
            Time.timeScale = 0;
            panel.SetActive(true);
            openOnce = false;
        }
    }

    public void Continue(GameObject panel)
    {
        Time.timeScale = 1;
        panel.SetActive(false);

    }

    public void Storm()
    {
        if (countdown >= 0)
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);

        }
        
        if (countdown <= 0 && onOff)
        {
            if (purchaseClass.insuranceDays > 0)
            {
                Time.timeScale = 0;
                stormYesInsurPanel.SetActive(true);
                onOff = false;

            }
            else
            {
                Time.timeScale = 0;
                stormNoInsurPanel.SetActive(true);
                moneyClass.startMoney *= 0.5f;
                onOff = false;

            }
        }       
    }
}
