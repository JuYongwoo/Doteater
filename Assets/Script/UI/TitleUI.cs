using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUI : MonoBehaviour
{
    private enum UIs
    {
        Start,
        Settings,
        Quit
    }

    private Dictionary<UIs, GameObject> TitleMap;


    private void Awake()
    {
        childsmapping();
        addListner();
    }

    void childsmapping()
    {
        TitleMap = new Dictionary<UIs, GameObject>();

        Transform[] TitleUIs = gameObject.GetComponentsInChildren<Transform>();

        foreach (Transform t in TitleUIs)
        {
            if (t.name == "Start")
            {
                TitleMap.Add(UIs.Start, t.gameObject);
            }
            if (t.name == "Settings")
            {
                TitleMap.Add(UIs.Settings, t.gameObject);
            }
            if (t.name == "Quit")
            {
                TitleMap.Add(UIs.Quit, t.gameObject);
            }
        }
    }

    void addListner()
    {
        Button StartButton = TitleMap[UIs.Start].GetComponent<Button>();
        Button SettingsButton = TitleMap[UIs.Settings].GetComponent<Button>();
        Button QuitButton = TitleMap[UIs.Quit].GetComponent<Button>();

        StartButton.onClick.AddListener( () => { SceneManager.LoadScene("Main"); });
        SettingsButton.onClick.AddListener( () => { Application.Quit(); });
        QuitButton.onClick.AddListener( () => { Application.Quit(); });

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
