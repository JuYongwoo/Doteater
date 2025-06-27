using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {


    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            gameObject.SetActive(false);
            InGameChapter.coinget();
            


        }
    }
}