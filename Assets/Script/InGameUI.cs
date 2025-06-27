using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUI : MonoBehaviour
{

    public enum UIName
    {
        HP,
        Stamina,
        Remaining,
        Mission
    }
    private Dictionary<UIName, GameObject> UIMap;


    // Start is called before the first frame update
    void Awake()
    {
        UIMap = new Dictionary<UIName, GameObject>();

        foreach(Transform t in GetComponentsInChildren<Transform>())
        {
            if(t.name == "HPBar")
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

        }

        mapping();
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

        InGameChapter.refreshUI += (coincount) =>
        {
            if (coincount < 1)
            {
                ManagerObject.Scene.LoadScene(Define.Scene.Win);
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
        
    }
}
