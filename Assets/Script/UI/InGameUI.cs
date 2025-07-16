using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    private enum UIName
    {
        HP,
        Stamina,
        Remaining,
        Mission,
        HowToPlay
    }
    private Dictionary<UIName, GameObject> UIMap;


    // Start is called before the first frame update
    void Awake()
    {
        childsmapping();
        

        mapping();

        UIMap[UIName.HowToPlay].SetActive(true);
        Time.timeScale = 0;

    }
    private void childsmapping()
    {
        UIMap = new Dictionary<UIName, GameObject>();

        foreach (Transform t in GetComponentsInChildren<Transform>())
        {
            if (t.name == "HPBar")
            {
                UIMap.Add(UIName.HP, t.gameObject);
            }
            if (t.name == "StaminaBar")
            {
                UIMap.Add(UIName.Stamina, t.gameObject);
            }
            if (t.name == "Remaining")
            {
                UIMap.Add(UIName.Remaining, t.gameObject);
            }
            if (t.name == "Mission")
            {
                UIMap.Add(UIName.Mission, t.gameObject);
            }
            if (t.name == "HowToPlay")
            {
                UIMap.Add(UIName.HowToPlay, t.gameObject);
            }

        }
    }
    private void mapping()
    {
        Player.refreshHPBar += (hp) =>
        {
            UIMap[UIName.HP].GetComponent<Slider>().value = hp / 100 + 0.01f;
        };

        Player.refreshStaminaBar += (stm) =>
        {
            UIMap[UIName.Stamina].GetComponent<Slider>().value = stm / 100;
        };

        InGameManager.refreshUI += (coincount) =>
        {
            if (coincount < 1)
            {
                SceneManager.LoadScene("Win");
            }
            else
            {
                UIMap[UIName.Remaining].GetComponent<Text>().text = coincount + "°³ ³²À½";
            }
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (UIMap[UIName.HowToPlay].activeSelf && Input.GetButtonDown("Submit"))
        {
            Time.timeScale = 1;
            UIMap[UIName.HowToPlay].SetActive(false);
        }
    }
}
