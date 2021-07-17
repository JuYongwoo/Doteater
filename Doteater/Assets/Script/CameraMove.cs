using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerposition = Player.transform.position;
        transform.position = new Vector3(playerposition.x, playerposition.y + 10, playerposition.z - 5);
    }
}
