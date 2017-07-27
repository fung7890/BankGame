using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Selected2 : MonoBehaviour {

    private Button moneySmallBut;
    private Button moneyMediumBut;
    private Button moneyLargeBut;
   
    SavedProfile saved;

    private void Start()
    {
        saved = GameObject.Find("SavedProfile").GetComponent<SavedProfile>();

        moneySmallBut = GameObject.Find("MoneySmall").GetComponent<Button>();
        moneyMediumBut = GameObject.Find("MoneyMedium").GetComponent<Button>();
        moneyLargeBut = GameObject.Find("MoneyLarge").GetComponent<Button>();

        moneySmallBut.onClick.AddListener(SmallMoneyClicked);
        moneyMediumBut.onClick.AddListener(MediumMoneyClicked);
        moneyLargeBut.onClick.AddListener(LargeMoneyClicked);

    }


    public void SmallMoneyClicked()
    {
        saved.smallMoney = true;
        LevelChange();
    }

    public void MediumMoneyClicked()
    {
        saved.mediumMoney = true;
        LevelChange();
    }

    public void LargeMoneyClicked()
    {
        saved.largeMoney = true;
        LevelChange();
    }


    public void LevelChange()
    {
        SceneManager.LoadScene("GameIntro");
    }
}
