using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 



public class PurchaseItems : MonoBehaviour {

    private Text desc;
    private Text money;
    private Text rover;
    private Text marketing;
    private Text insurance;
    private Text solar;

    private Money moneyClass;
    private Days daysClass;
    private Scenarios scenariosClass;

    public float smallShopPrice = 100f;
    public float medShopPrice = 400f;
    public float largeShopPrice = 1000f;

    public float roverPrice = 1000f;
    public float insurancePrice = 1200f;
    public float marketingPrice = 1400f;
    public float solarPrice = 400f;

    public GameObject shop1;
    public GameObject shop2;
    public GameObject shop3;
    public GameObject tier;

    public float tier1 = 0f;
    public float tier2 = 0f;
    public float tier3 = 0f;

    public float roverAddDays = 15f;
    public float insuranceAddDays = 20f;
    public float marketingAddDays = 15f;
    public float solarAddDays = 20f;

    public float roverDays;
    public float insuranceDays;
    public float marketingDays;
    public float solarDays;

    public float roverEffect = 1;
    public float marketingEffect = 1;
    public float solarEffect = -3;
    public float insuranceEffect = 1;

    private List<float> takenLocations;
    private float randomNum;

    // Use this for initialization
    void Start () {
        moneyClass = GameObject.Find("Scripts").GetComponent<Money>();
        daysClass = GameObject.Find("Scripts").GetComponent<Days>();
        scenariosClass = GameObject.Find("Scripts").GetComponent<Scenarios>();

        money = GameObject.Find("Money").GetComponent<Text>();
        desc = GameObject.Find("Description").GetComponent<Text>();
        rover = GameObject.Find("RoverDaysLeft").GetComponent<Text>();
        marketing = GameObject.Find("MarketingDaysLeft").GetComponent<Text>();
        solar = GameObject.Find("SolarDaysLeft").GetComponent<Text>();
        insurance = GameObject.Find("InsuranceDaysLeft").GetComponent<Text>();

        takenLocations = new List<float>();
    }

    private void Update()
    {
        ItemDecay(ref roverDays, ref rover);
        ItemDecay(ref marketingDays, ref marketing);
        ItemDecay(ref solarDays, ref solar);
        ItemDecay(ref insuranceDays, ref insurance);

        ItemEffect(roverDays, "rover");
        ItemEffect(marketingDays, "marketing");
        ItemEffect(solarDays, "solar");
        ItemEffect(insuranceDays, "insurance");
    
    }

    public void Exit()
    {
        desc.text = "";
    }

    public void Shop()
    {

        Debug.Log(this.gameObject.name);
        switch (this.gameObject.name)
        {
            case "Shop1":
                desc.text = "Price: $" + smallShopPrice.ToString() + "\nSmall Sized Shop";
                break;

            case "Shop2":
                desc.text = "Price: $" + medShopPrice.ToString() + "\nMedium Sized Shop";
                break;

            case "Shop3":
                desc.text = "Price: $" + largeShopPrice.ToString() + "\nLarge Sized Shop";
                break;

            case "Rover":
                desc.text = "Price: $" + roverPrice.ToString() + "\nSpace Rover to help you move inventory around";
                break;

            case "Insurance":
                desc.text = "Price: $" + insurancePrice.ToString() + "\nInsurance for your shops and equipment";
                break;

            case "Solar":
                desc.text = "Price: $" + solarPrice.ToString() + "\nSolar Panels to decrease your utility costs";
                break;

            case "Marketing":
                desc.text = "Price: $" + marketingPrice.ToString() + "\nIncrease customers for a short period";
                break;
        }

    }

    public void Buy()
    {
        int moneyNum = Int32.Parse(money.text);

        switch (this.gameObject.name)
        {
            case "Shop1":
                BuyingStores(smallShopPrice, ref moneyClass.smallShop, shop1);
                break;

            case "Shop2":
                BuyingStores(medShopPrice, ref moneyClass.medShop, shop2);
                break;

            case "Shop3":
                BuyingStores(largeShopPrice, ref moneyClass.largeShop, shop3);
                break;

            case "Rover":
                Items(roverPrice, ref rover, roverAddDays, ref roverDays, ref scenariosClass.roverOnce, scenariosClass.roverPanel);              
                break;

            case "Insurance":
                Items(insurancePrice, ref insurance, insuranceAddDays, ref insuranceDays, ref scenariosClass.insuranceOnce, scenariosClass.insurancePanel);
                break;

            case "Solar":
                Items(solarPrice, ref solar, solarAddDays, ref solarDays, ref scenariosClass.solarOnce, scenariosClass.solarPanel);            
                break;

            case "Marketing":
                Items(marketingPrice, ref marketing, marketingAddDays, ref marketingDays, ref scenariosClass.marketingOnce, scenariosClass.marketingPanel);
                break;
        }
    }


    public void BuyingStores(float itemPrice, ref int storeCount, GameObject store)
    {
        int moneyNum = Int32.Parse(money.text);

        if (moneyNum < itemPrice)
        {
            desc.text = "You Don't Have Enough Money";
        }
        
        
        else if (tier1 < 10)
        {
            Debug.Log(storeCount);
            moneyClass.startMoney -= itemPrice;
            Build(store, ref storeCount, ref tier1, -4.42f);

            if (tier1 == 10)
            {
                Instantiate(tier, new Vector3(0, -3f, 0), Quaternion.identity);
                takenLocations.Clear();
            }

        }
        else if (tier2 < 10)
        {
            Debug.Log("REACHES TIER2");
            moneyClass.startMoney -= itemPrice;
            Build(store, ref storeCount, ref tier2, -2.55f);

            if (tier2 == 10)
            {
                Instantiate(tier, new Vector3(0, -1.15f, 0), Quaternion.identity);
                takenLocations.Clear();
            }

        }

        else if (tier3 < 10)
        {
            Debug.Log("REACHES TIER3");
            moneyClass.startMoney -= itemPrice;
            Build(store, ref storeCount, ref tier3, -0.65f);

            if (tier3 == 10)
            {
                //DONE, MAXED STORES
            }

        }

    }

    public void Build(GameObject store, ref int storeCountRef, ref float tierRef, float storeY)
    {

       randomNum = UnityEngine.Random.Range(-5, 5);
        while (takenLocations.Contains(randomNum))
        {
            randomNum = UnityEngine.Random.Range(-5, 5);
        }
        //store
        Instantiate(store, new Vector3(randomNum, storeY, 0), Quaternion.identity);
        takenLocations.Add(randomNum);
        tierRef += 1;
        storeCountRef += 1;
       
    }


    public void Items(float itemPrice, ref Text daysLeftRef, float daysAdded, ref float currentDaysLeft, ref bool onOff, GameObject panel)
    {
        int moneyNum = Int32.Parse(money.text);

        if (moneyNum < itemPrice)
        {
            desc.text = "You Don't Have Enough Money";
        }
        else
        {
            moneyClass.startMoney -= itemPrice;
            currentDaysLeft += daysAdded;

            daysLeftRef.text = ((int)currentDaysLeft).ToString();
            scenariosClass.Links(ref onOff, panel);

        }
    }

    public void ItemDecay(ref float daysLeft, ref Text daysLeftRef)
    {
        if (daysLeft > 0)
        {
            daysLeft -= Time.deltaTime * daysClass.timeMultiplier;
            daysLeftRef.text = ((int)daysLeft).ToString();
        }
    }

    public void ItemEffect(float daysLeft, string item)
    {
        if (daysLeft > 0)
        {
            switch (item)
            {
                case "rover":
                    //rover effects
                    Debug.Log("ROVERRRRRR");
                    break;
                case "marketing":
                    //rover effects
                    marketingEffect = 2;
                    break;
                case "solar":
                    solarEffect = 0;
                    break;
                case "insurance":
                    //rover effects
                    break;

            }
        } else
        {
            //back to defaults after time runs out
            switch (item)
            {
                case "marketing":
                    marketingEffect = 1;
                    break;

                case "solar":
                    solarEffect = -3;
                    break;

            }
        }
    }
}
