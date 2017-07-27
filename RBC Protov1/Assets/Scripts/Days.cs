using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Days : MonoBehaviour {

    public float timeMultiplier = 0.3f;
    private Text days;
    public float timeLeft = 0f;

	// Use this for initialization
	void Start () {
        days = GameObject.Find("Days").GetComponent<Text>();
	
	}
	
	// Update is called once per frame
	void Update () {

    
        timeLeft += Time.deltaTime * timeMultiplier;
        days.text = ((int)timeLeft).ToString();


    }
}
