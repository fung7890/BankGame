using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavedProfile : MonoBehaviour {

    public bool bakery = false;
    public bool cafe = false;
    public bool carwash = false;
    public bool pharmacy = false;
    public bool pizza = false;

    public bool smallMoney = false;
    public bool mediumMoney = false;
    public bool largeMoney = false;


    // Use this for initialization
    void Start () {
        DontDestroyOnLoad(this.gameObject);
    }
	

}
