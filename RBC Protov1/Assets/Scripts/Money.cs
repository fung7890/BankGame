using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Money : MonoBehaviour {

    public float startMoney = 100f;
    private Text money;
    private Text utilties;

    public int smallShop;
    public int medShop;
    public int largeShop;

    public float moneyMultiplier;
    public float feeMultiplier;
    public float utilitiyCost;

    PurchaseItems purchaseClass;

    

    // Use this for initialization
    void Start () {
        money = GameObject.Find("Money").GetComponent<Text>();
        utilties = GameObject.Find("Cost").GetComponent<Text>();
        purchaseClass = GameObject.Find("Scripts").GetComponent<PurchaseItems>();
        utilitiyCost = Int32.Parse(utilties.text);
    }

    // Update is called once per frame
    void Update () {

        moneyMultiplier = (smallShop * 1.4f) + (medShop * 1.8f) + (largeShop * 2.3f);

        //effects of items
        moneyMultiplier *= purchaseClass.marketingEffect;
        utilitiyCost = purchaseClass.solarEffect;
        utilties.text = ((int)utilitiyCost).ToString();


        
        //increase money based off shops and type of shop
        startMoney += (Time.deltaTime * moneyMultiplier * (largeShop + smallShop + medShop)) ;

        //reduce money based off utility cost, multiplier, and amount of shops
        startMoney += (feeMultiplier * utilitiyCost * (smallShop + medShop + largeShop));

        money.text = ((int)startMoney).ToString();

    }


}
