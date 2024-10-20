using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelIndicator : MonoBehaviour
{
    public RocketController controller;
    public Image ui_fuel_indicator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ui_fuel_indicator.fillAmount = RocketController.fuel_current/controller.fuel_maximal;
    }
}
