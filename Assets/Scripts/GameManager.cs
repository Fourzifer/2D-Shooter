using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Vector3 lastCheckpoint;

    public Vector3 LastCheckpoint
    {
        get { return lastCheckpoint; }
        set { lastCheckpoint = value;  }
    }
        
}
