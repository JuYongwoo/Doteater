using System;
using UnityEngine;
using UnityEngine.UI;

public class InGameChapter : MonoBehaviour
{

    public static int remainingcoins = -1;
    public static event Action<int> refreshUI;

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