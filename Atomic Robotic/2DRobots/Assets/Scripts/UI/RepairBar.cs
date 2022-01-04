using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RepairBar : MonoBehaviour
{

    public Slider slider;
    //public Text displayText;
    public Boolean active;
    public int MAX = 1;
    float MaxTime = 3f;
    public float ActiveTime = 0f;

    private float currentValue = 0f;
    public float CurrentValue
    {
        get
        {
            return currentValue;
        }
        set
        {
            currentValue = value;
            slider.value = currentValue;
           // displayText.text = (slider.value * 100).ToString("0.00") + "%";
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        CurrentValue = 0f;
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = currentValue;
        fill();
    }

    public void fill()
    {
        if ((CurrentValue <= MAX))
        {
         ActiveTime += Time.deltaTime;
         float percent = ActiveTime / MaxTime;
         CurrentValue = Mathf.Lerp(0, 1, percent);
            //Debug.Log("CurrentValue is " + CurrentValue);
            //Update();
        }
        if(ActiveTime >= MaxTime)
        {
            ActiveTime = 0;
        }
    }

    public void setActive(Boolean set)
    {
        active = set;
    }

    public void setInactive()
    {
        active = false;
    }
}
