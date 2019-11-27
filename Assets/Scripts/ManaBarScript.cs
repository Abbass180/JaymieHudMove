using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
    private Image manaImage;

    private void Awake()
    {
        //reference to mana image
        manaImage = transform.Find("ManaBar").GetComponent<Image>();

        manaImage.fillAmount = .4f;
    }
}

public class Mana
{
    public const int mana_max = 100;

    private float manaAmount;
    private float manaRegenAmount;

    public Mana()
    {
        manaAmount = 0;
        manaRegenAmount = 30f;
    }

    public void Update()
    {
        manaAmount += manaRegenAmount * Time.deltaTime;
    }
}
