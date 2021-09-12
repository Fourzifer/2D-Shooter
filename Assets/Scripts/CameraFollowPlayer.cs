using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public Transform playerShip;
    void LateUpdate()
    {
        transform.position = playerShip.position;
    }

}
