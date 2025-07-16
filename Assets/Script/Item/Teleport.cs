using System;
using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;
    static public event Action<bool> warpOn;


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (col.gameObject.GetComponent<Player>().canWarp)
            {
                col.gameObject.SetActive(false); // 순간적으로 껐다 켜줘야 이동에 문제가 없음

                col.transform.position = new Vector3(destination.transform.position.x, col.transform.position.y, destination.transform.position.z);

                col.gameObject.SetActive(true);
                StartCoroutine(warpOnCoroutine());

            }

        }
    }

    IEnumerator warpOnCoroutine()
    {
        warpOn(false);
        yield return new WaitForSeconds(3f);
        warpOn(true);

    }
}
