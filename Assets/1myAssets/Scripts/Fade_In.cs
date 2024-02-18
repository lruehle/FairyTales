using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade_In : MonoBehaviour
{
    private float desiredAlpha;
    private float currentAlpha;
    private Image fade_img;
    private Color fade_img_clr;
    // Start is called before the first frame update
    void Start()
    {
        fade_img = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
