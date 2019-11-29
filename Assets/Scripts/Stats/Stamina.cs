using UnityEngine;
using UnityEngine.UI;

public class Stamina : MonoBehaviour
{
    public Image staminaFill;
    public static float curStamina = 100f, maxStamina = 100f;

    bool staminaUsed;
    public float staminaPerSecond = 1f;

    private void Start()
    {
        //repeatadly invokes the method
        InvokeRepeating("Timer", 1, 1f);
    }

    void StaminaChange()
    {
        //clamps the value between cur and max stamina
        float amount = Mathf.Clamp01(curStamina / maxStamina);
        staminaFill.fillAmount = amount;
    }

    void Update()
    {
        StaminaChange();

        //if left shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            //than current stamina is minused by 1
            curStamina -= 0.5f;
        }

        //caps the max health
        if (curStamina > 100)
        {
            curStamina = 100;
        }

        //caps the minimum health
        if (curStamina < 0)
        {
            curStamina = 0;
        }
    }
    private void Timer()
    {
        curStamina += staminaPerSecond;
    }
}

