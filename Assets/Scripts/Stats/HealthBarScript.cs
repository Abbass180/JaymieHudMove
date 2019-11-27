using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBarScript : MonoBehaviour
{
    public Image HealthFill;
    public float maxHealth = 100f;
    public float curHealth = 100f;


    bool HealthUsed;
    public float HealthPerSecond = 1f;

    private void Start()
    {
        //invokes method name
        InvokeRepeating("Timer", 1, 1f);
        //current health is equal to maxhealth
        curHealth = maxHealth;
    }

    void HealthChange()
    {
        //clamping value between curhealth and maxhealth 
        float amount = Mathf.Clamp01(curHealth / maxHealth);
        HealthFill.fillAmount = amount;
    }
    void Update()
    {
        HealthChange();

        //caps the max health
        if (curHealth > 100)
        {
            curHealth = 100;
        }

        //caps the minimum health
        if (curHealth < 0)
        {
            curHealth = 0;
        }

    }
    public void TakeDamage(int damage)
    {
        curHealth -= damage;
    }
        
    private void Timer()
    {
        curHealth += HealthPerSecond;
    }
}
