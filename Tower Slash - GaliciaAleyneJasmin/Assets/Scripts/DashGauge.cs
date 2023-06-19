using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashGauge : MonoBehaviour
{
    public Slider dashSlider;
    public Gradient gradient;
    public Image fillImage;

    public Player player;

    void Start()
    {
        SetMaxDashBar();
        SetDashBar(0); 
    }

    public void SetMaxDashBar()
    {
        dashSlider.maxValue = 100;
        fillImage.color = gradient.Evaluate(1f);
    }

    public void SetDashBar(int dash)
    {
        if (dashSlider.maxValue < dash)
        {
            dashSlider.value = 100;
        }

        else
        {
            dashSlider.value = dash;
        }
 
        fillImage.color = gradient.Evaluate(dashSlider.normalizedValue);
    }

    

}
