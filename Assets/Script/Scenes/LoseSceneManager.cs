using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoseSceneManager : MonoBehaviour
{
    private void Start()
    {
        Animator anim = GameObject.Find("unitychan").GetComponent<Animator>();
        anim.SetBool("Win", false);
        anim.SetBool("Lose", true);
        ManagerObject.Input.ConfirmKeyAction -= Regame;
        ManagerObject.Input.ConfirmKeyAction += Regame;
    }

    void Regame()
    {
        SceneManager.LoadScene("Title");
    }
}
