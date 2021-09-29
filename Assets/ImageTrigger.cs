using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageTrigger : MonoBehaviour
{
    public Images imagery;

    public void TriggerImagery()
    {
        FindObjectOfType<ImageManager>().StartImages(imagery);
    }
    void Start()
    {
        TriggerImagery();
    }

}
