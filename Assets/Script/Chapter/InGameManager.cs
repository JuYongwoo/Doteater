using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameManager : MonoBehaviour
{

    public static int remainingcoins = -1;
    public static event Action<int> refreshUI;
    public static GameObject Player = null;
    private void Awake()
    {
        SceneManager.sceneLoaded += (sc, sce)=> { Player = GameObject.Find("Player"); };

    }
    private void Start()
    {
        GameObject[] remainingcoinarray = GameObject.FindGameObjectsWithTag("Coin");
        remainingcoins = remainingcoinarray.Length;
        refreshUI(remainingcoins);


    }

    static public void coinget()
    {
        remainingcoins -= 1;
        refreshUI?.Invoke(remainingcoins);


    }
}