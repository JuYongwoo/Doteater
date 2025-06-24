using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpStamina : MonoBehaviour
{
    [SerializeField]
    GameObject HPbarObj;
    [SerializeField]
    GameObject StaminabarObj;
    float nowhp;
    float nowstamina;
    Slider HPbar;
    Slider Staminabar;

    // Start is called before the first frame update
    void Start()
    {
        HPbar = HPbarObj.GetComponent<Slider>();
        Staminabar = StaminabarObj.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        nowhp = GetComponent<Player>().hp;
        HPbar.value= nowhp / 100 + 0.01f;

        nowstamina = GetComponent<Player>().stamina;
        Staminabar.value = nowstamina / 100;

    }
}
