using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class Spawner : MonoBehaviour
{
    [SerializeField]
    GameObject Enemy;
    float count = 0;
    [SerializeField]
    float[] spawntime = new float[10];
    int spawncount = 0;
    [SerializeField]
    GameObject[] spawnplace = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {   
        
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;
        if(count>spawntime[spawncount]) {
            GameObject go = ManagerObject.Resource.Instantiate("enemy");
            Vector3 rd_position = spawnplace[Random.Range(0,3)].transform.position;
            go.transform.position = rd_position; 
            
            spawncount += 1;
        }
        if(spawncount>=3) {
            spawncount=0;
            count=0;
        }

        
    }
}
