using System.Collections;
using System.Collections.Generic;
using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Item_Panel_Handle : MonoBehaviour
{
    private string link;
    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private GameObject body_holder;
    [SerializeField] private TextMeshProUGUI body;
    [SerializeField] private Image sprite_display;
    float item_img_aspectRatio;
    // Start is called before the first frame update
    void Start()
    {
        //body = body_holder.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Set_Body(string new_txt)
    {
        body.text = new_txt;
    }
    //this should be accessed by the Europeana Objects to change to their Links
    public void Set_Link(string url)
    {
        if(string.IsNullOrWhiteSpace(url)){}
        else{
            link = url;
        }
    }

    //this should be accessed by the button on UI
    public void OpenLink()
    {
        Application.OpenURL(link);
    }

    public void Set_Display_Image(Sprite sprite_img)
    {
        item_img_aspectRatio = sprite_img.rect.width / sprite_img.rect.height;
        var fitter = sprite_display.GetComponent<UnityEngine.UI.AspectRatioFitter>();
        fitter.aspectRatio =item_img_aspectRatio;
        sprite_display.sprite = sprite_img; 
    }
}
