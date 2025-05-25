using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    float countdown = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        countdown += Time.deltaTime;   
    }
    
    private void OnTriggerEnter(Collider col)
    { 
        if (col.name == "Player" && countdown > 3 && name == A.name)
        {
            col.gameObject.SetActive(false);
            col.transform.position = new Vector3( B.transform.position.x , col.transform.position.y,B.transform.position.z);
            Debug.Log("A에서 B로 이동");
            col.gameObject.SetActive(true);
            A.GetComponent<Teleport>().countdown = 0;
            B.GetComponent<Teleport>().countdown = 0;
        }
        else if (col.name == "Player" && countdown > 3 && name == B.name)
        {
            col.gameObject.SetActive(false);
            col.transform.position = new Vector3(A.transform.position.x, col.transform.position.y, A.transform.position.z);
            Debug.Log("B에서 A로 이동");
            col.gameObject.SetActive(true);
            A.GetComponent<Teleport>().countdown = 0;
            B.GetComponent<Teleport>().countdown = 0;
        }

    }
}
