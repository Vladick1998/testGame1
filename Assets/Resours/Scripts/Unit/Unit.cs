using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Скрипт содержит основные атрибуты живых объектов
public class Unit : MonoBehaviour
{
    public UnitScriptableObject unitData;

    public float currentMoveSpeed;
    public float currentHealth;
    public float CurrentHealth
    {
        get
        {
            return currentHealth;
        }
        set
        {
            if (value > unitData.MaxHealth) 
                currentHealth = unitData.MaxHealth;
            else
                currentHealth = value;
            currentHealthSlider.value = currentHealth;
        }
    }
    public float currentDamage;
    public Slider currentHealthSlider;

    void Awake()
    {
        currentMoveSpeed = unitData.MoveSpeed;
        currentHealth = unitData.MaxHealth;
        currentDamage = unitData.Damage;
        currentHealthSlider.maxValue = unitData.MaxHealth;
        currentHealthSlider.value = currentHealth;
    }
    public virtual void TakeDamage(float damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0) 
        {
            Kill();
            if (TryGetComponent<DropController>(out DropController drop))
            {
                drop.Drop();
            }
        }
        
    }

    public virtual void Kill()
    {
        Destroy(gameObject);
    }
}
