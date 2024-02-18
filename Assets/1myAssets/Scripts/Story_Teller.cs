using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Story_Teller : MonoBehaviour
{
    // Start is called before the first frame update
    private string default_txt;
    [SerializeField] private TextMeshProUGUI text_output_Panel;

    void Start()
    {
        default_txt = "This is a default Text.... Looks like something went wrong!";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Use_Default_txt()
    {
        text_output_Panel.text = default_txt;
    }

    public void Set_Panel_txt(string new_txt)
    {
        text_output_Panel.text = new_txt;
    }

    public void Add_to_Panel_txt(string addition)
    {
        text_output_Panel.text += addition;
    }
    public string Get_Panel_txt()
    {
        Debug.Log(text_output_Panel.text);
        return text_output_Panel.text;
    }
}
