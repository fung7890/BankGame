using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Selected1 : MonoBehaviour {

    private Button bakeryBut;
    private Button cafeBut;
    private Button carwashBut;
    private Button pharmBut;
    private Button pizzaBut;
    SavedProfile saved;


    private void Start()
    {
        saved = GameObject.Find("SavedProfile").GetComponent<SavedProfile>();

        bakeryBut = GameObject.Find("Bakery").GetComponent<Button>();
        cafeBut = GameObject.Find("Cafe").GetComponent<Button>();
        carwashBut = GameObject.Find("Carwash").GetComponent<Button>();
        pharmBut = GameObject.Find("Pharmacy").GetComponent<Button>();
        pizzaBut = GameObject.Find("Pizza").GetComponent<Button>();

        bakeryBut.onClick.AddListener(BakeryClicked);
        cafeBut.onClick.AddListener(CafeClicked);
        carwashBut.onClick.AddListener(CarwashClicked);
        pharmBut.onClick.AddListener(PharmClicked);
        pizzaBut.onClick.AddListener(PizzaClicked);

    }
    // Update is called once per frame
    void Update () {
      
      
    }

    public void BakeryClicked()
    {
        saved.bakery = true;
        LevelChange();
    }

    public void CafeClicked()
    {
        saved.cafe = true;
        LevelChange();
    }

    public void CarwashClicked()
    {
        saved.carwash = true;
        LevelChange();
    }

    public void PharmClicked()
    {
        saved.pharmacy = true;
        LevelChange();
    }

    public void PizzaClicked()
    {
        saved.pizza = true;
        LevelChange();
    }

    public void LevelChange()
    {
        SceneManager.LoadScene("ProfileCollection2");
    }
}
