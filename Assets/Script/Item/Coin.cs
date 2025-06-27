using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour {



    private void Update()
    {
        transform.Rotate(Vector3.forward*Time.deltaTime*100);

    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.transform.tag == "Player")
        {
            gameObject.SetActive(false);
            InGameManager.coinget();
            


        }
    }
}