using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TitleSceneManager : MonoBehaviour
{
    [HideInInspector]
    public bool gameWin;
    [HideInInspector]
    public bool gameLose;
    [SerializeField]
    GameObject StartButton;
    [SerializeField]
    GameObject SettingButton;
    [SerializeField]
    GameObject QuitButton;
    // Start is called before the first frame update
    void Start()
    {
        setResolution();
#region UI 버튼 할당

        StartButton.GetComponent<Button>().onClick.AddListener(Nextscene);
        SettingButton.GetComponent<Button>().onClick.AddListener(SettingPanel);
        QuitButton.GetComponent<Button>().onClick.AddListener(QuitGame);
#endregion
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setResolution()
    {
        Screen.SetResolution(1600, 900, false);

    }
    public void Nextscene()
    {
        ManagerObject.Scene.LoadScene(Define.Scene.Main);

    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void SettingPanel()
    {
        Application.Quit();
    }
}
