using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{

    private void FixedUpdate()
    {
        Vector3 playerposition = InGameManager.Player.transform.position;
        transform.position = new Vector3(playerposition.x, playerposition.y + 10, playerposition.z - 5);
    }
}
