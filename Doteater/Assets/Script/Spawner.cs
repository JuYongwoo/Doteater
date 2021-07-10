using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject Enemy;
    float count = 0;
    public float[] spawntime = new float[10];
    int spawncount = 0;
    public GameObject[] spawnplace = new GameObject[3];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        count+=Time.deltaTime;
        if(count>spawntime[spawncount]) {
            Vector3 pos = new Vector3(spawnplace[Random.Range(0,3)].transform.position.x, spawnplace[Random.Range(0,3)].transform.position.z);
            Instantiate(Enemy, pos, transform.rotation);
            spawncount += 1;
        }

        
    }
}
