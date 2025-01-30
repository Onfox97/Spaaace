using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthIndicator : MonoBehaviour
{
    public Health health;
    
    public Image ui_fuel_indicator;
    void Update()
    {
        ui_fuel_indicator.fillAmount = health.health/(float)health.health_max;
    }
}
