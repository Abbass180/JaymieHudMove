using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    //Constant for the total
    public Image manaFill;
    public float mana_Cur = 100f;
    public float mana_max = 100f;

    private float manaAmount;
    private float manaRegenAmount;

    public float manaPerSecond = 10f;

    private void Start()
    {
        //repeatadly invokes the method
        InvokeRepeating("Timer", 1, 1f);
    }
    void ManaChange()
    {
        //clamps the value between cur and max stamina
        float amount = Mathf.Clamp01(mana_Cur / mana_max);
        manaFill.fillAmount = amount;
    }
    public Mana()
    {
        manaAmount = 0;
        manaRegenAmount = 30f;
    }

    public void Update()
    {
        ManaChange();

        manaAmount += manaRegenAmount * Time.deltaTime;
        manaAmount = Mathf.Clamp(manaAmount, 0f, mana_max);

        if (Input.GetKey(KeyCode.M))
        {
            mana_Cur -= 1;
        }

        //caps the max health
        if (mana_Cur > 100)
        {
            mana_Cur = 100;
        }

        //caps the minimum health
        if (mana_Cur < 0)
        {
            mana_Cur = 0;
        }

    }

    public void TrySpendMana(int amount)
    {
        if (manaAmount >= amount)
        {
            manaAmount -= amount;
        }
    }

    public float GetManaNormalised()
    {
        return manaAmount / mana_max;
    }

    private void Timer()
    {
        mana_Cur += manaPerSecond;
    }
}
