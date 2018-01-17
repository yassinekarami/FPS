using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PanelUI : MonoBehaviour {

    public static Text munitionTxt;
    public static Text chargerTxt;
    public static Text healthTxt;
    public static Image health;
    public static Image bloodScreen;

	// Use this for initialization
	void Start () {

        munitionTxt = GameObject.Find("TxtMunitions").GetComponent<Text>();
        chargerTxt = GameObject.Find("TxtChargeurs").GetComponent<Text>();
        health = GameObject.Find("ImVie").GetComponent<Image>();
        healthTxt = GameObject.Find("TxtVie").GetComponent<Text>();
        bloodScreen = GameObject.Find("BloodScreen").GetComponent<Image>();
	}

	
	// Update is called once per frame
	void Update () {

          
    }

    public static void UpdateMunition(float value)
    {
        munitionTxt.text = "Munitions " + value;
    }

    public static void UpdateCharger(float value)
    {
        chargerTxt.text = "Chargeurs " + value;
    }

    public static void UpdateCharaterHealth()
    {
        if (health.fillAmount == 1)
            return;

        else if (health.fillAmount >= 0.9)
            health.fillAmount += 0.1f;
        
            

        else health.fillAmount += 0.2f;

        healthTxt.text = health.fillAmount * 100 + " %";
    }

    public static void DecreaseCharacterHealth()
    {
        if (health.fillAmount <= 0.15)
        {
            health.fillAmount = 0f;
            Character.isDead = true;
            bloodScreen.enabled = true;
        }
            
        else health.fillAmount -= 0.15f;

        healthTxt.text = health.fillAmount * 100 + " %";
    }


}
