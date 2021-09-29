using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    public Image mainImage;
    private Texture2D texture;

    private Queue<Image> images;

    void Start()
    {
        images = new Queue<Image>();
    }

    public void StartImages(Images image)
    {
        foreach (Image help in image.images)
        {
            images.Enqueue(help);
        }

        DisplayNextImage();
    }
    public void DisplayNextImage()
    {
        if (images.Count == 0)
        {
            EndImagery();
            return;
        }
        
        Image help = images.Dequeue();
        mainImage = help;
    }

    public void EndImagery()
    {

    }
}
