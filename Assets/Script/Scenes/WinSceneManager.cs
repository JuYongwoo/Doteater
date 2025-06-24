using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WinSceneManager : MonoBehaviour
{
    private void Start()
    {
        Animator anim = GameObject.Find("unitychan").GetComponent<Animator>();
        anim.SetBool("Win", true);
        anim.SetBool("Lose", false);
        ManagerObject.Input.ConfirmKeyAction -= Regame;
        ManagerObject.Input.ConfirmKeyAction += Regame;
    }

    void Regame()
    {
        ManagerObject.Scene.LoadScene(Define.Scene.Title);
    }
}
