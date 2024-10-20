using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public Health health;
    public float health_max = 100;
    public Image ui_fuel_indicator;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ui_fuel_indicator.fillAmount = health.health/health_max;
    }
}
