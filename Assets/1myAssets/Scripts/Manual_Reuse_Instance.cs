using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Reuse_Instance : MonoBehaviour
{
    
    [SerializeField] private Manual_Reuse_struct Instance_data;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string Get_Full_Text()
    {
        string final_txt = "";
        final_txt += "<b>Title:</b>  "+ Instance_data.title+"<br>";
        final_txt += "<b>Urheber:</b>  "+ Instance_data.creator+"<br>";
        final_txt += "<b>Material/Technik:</b>  "+ Instance_data.material+"<br>";
        final_txt += "<b>Beschreibung:</b>  "+ Instance_data.descriptions +"<br>";
        final_txt += "<b>Schlagworte:</b>  "+ Instance_data.subject +"<br>";
        final_txt += "<b>Datum:</b>  "+ Instance_data.creation_year+"<br>";
        final_txt += "<b>Rechte:</b>  "+ Instance_data.rights+"<br>";
        return final_txt;
    }

    public Sprite Get_Obj_Sprite()
    {
        return Instance_data.image;
    }

    public string Get_Origin_Link()
    {
        return Instance_data.origin_link;
    }

}
