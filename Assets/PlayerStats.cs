using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float air;
    public float maxAir;
    public float weight;
    public float maxWeight;
    public float health;
    public float maxHealth;
    
    private float airPrivate;
    private float weightPrivate;
    private float healthPrivate;

    public bool inWater;

    private float weightSpeedMultiplier;

    private void Awake()
    {
        if (!inWater)
        {
            air = maxAir;
        }

        inWater = EventBus.Current.ReturnInWaterBool();
    }

    private void Update()
    {
        if (air != airPrivate)
        {
            UpdateAir();
            airPrivate = air;
        }
        if (weight != weightPrivate)
        {
            UpdateWeight();
            weightPrivate = weight;
        }
        if (health != healthPrivate)
        {
            UpdateHealth();
            healthPrivate = health;
        }
        if (inWater)
        {
            air -= Time.deltaTime;
            if (air <= 0)
            {
                //you drowned...
            }
        }
        else
        {
            air = maxAir;
        }


        if (weight <= maxWeight / 3)
        {
            weightSpeedMultiplier = 1f;
        }
        else if (weight >= (maxWeight / 6)*5 && weight <= maxWeight)
        {
            weightSpeedMultiplier = 0.40f;
        }
        else if(weight > maxWeight)
        {
            weightSpeedMultiplier = 0.10f;
        }
        else
        {
            weightSpeedMultiplier = 0.70f;
        }
    }

    public float ReturnWeightSpeedMultiplier()
    {
        return weightSpeedMultiplier;
    }
    
    public delegate void UpdateAirAmount();
    public event UpdateAirAmount UpdateAirAmountEvent;
    public void UpdateAir()
    {
        UpdateAirAmountEvent?.Invoke();
    }

    public float ReturnAirAmount()
    {
        var airValue = air / maxAir;
        return airValue;
    }
    public delegate void UpdateHealthAmount();
    public event UpdateHealthAmount UpdateHealthAmountEvent;
    public void UpdateHealth()
    {
        UpdateHealthAmountEvent?.Invoke();
    }

    public float ReturnHealthAmount()
    {
        var healthValue = health / maxHealth;
        return healthValue;
    }
    public delegate void UpdateWeightAmount();
    public event UpdateWeightAmount UpdateWeightAmountEvent;
    public void UpdateWeight()
    {
        UpdateWeightAmountEvent?.Invoke();
    }

    public float ReturnWeightAmount()
    {
        return weight;
    }

    public void ChangeWeightValue(float value)
    {
        weight += value;
    }
}
