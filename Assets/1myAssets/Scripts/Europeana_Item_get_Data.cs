using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using TMPro;
using UnityEngine;

public class Europeana_Item_get_Data : MonoBehaviour
{
    // xml Data
    [SerializeField] private string f_name;
    [SerializeField] private List<string> creator_list;
    [SerializeField] private List<string> title_list;
    [SerializeField] private List<string> medium_list;
    [SerializeField] private List<string> description_list;
    [SerializeField] private List<string> subject_list;
    [SerializeField] private List<string> format_list;
    [SerializeField] private List<string> rights_list;
    [SerializeField] private List<string> year_list;
    [SerializeField] private List<string> this_empty_list;
    [SerializeField] private string europeana_link;
    [SerializeField] private GameObject xml_handler;
    private Read_xml read_xml_script;
    private XmlElement root;
    // 
    //[SerializeField] private TextMeshProUGUI Europeana_Panel_txt;
    //[SerializeField] private GameObject Europeana_Panel;
    //private Item_Panel_Handle panel_handler;
    [SerializeField] private Sprite manual_img;
    
    
    void Start()
    {
        read_xml_script = xml_handler.GetComponent<Read_xml>();
        root = read_xml_script.Get_File_Root(f_name);
        //panel_handler = Europeana_Panel.GetComponent<Item_Panel_Handle>();
        Set_Creator_Names();
        Set_Titles();
        Set_Medium();
        Set_Descriptions();
        Set_Subjects();
        Set_Formats();
        Set_Rights();
        Set_Links();
        Set_Years();
        //Set_this_empty_error();
        //Write_to_Panel();
    }

    /*public void Write_to_Panel()
    {
        //check Ressources for lists vs arrays if this is triggered often
        //Europeana_Panel_txt.text = Create_Final_Text();
        panel_handler.Set_Body(Create_Final_Text());
        panel_handler.Set_Link(europeana_link);
        Set_Europeana_Panel(true);
    }*/
    public string Get_Europeana_link()
    {
        return europeana_link;
    }

    private void Set_Creator_Names()
    {
        creator_list= read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:creator");
        //Print_List_Names(creator_list);
    }
    private void Set_Titles()
    {
        title_list= read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:title[@xml:lang='de']");
        //Print_List_Names(title_list);
    }
    private void Set_Medium()
    {
        medium_list= read_xml_script.Get_Nodes_by_Name(root, "descendant::dcterms:medium[@xml:lang='de']");
        //Print_List_Names(medium_list);
    }

    private void Set_Descriptions()
    {
        description_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:description[@xml:lang='de']");
        //Print_List_Names(description_list);
    }
    private void Set_Subjects()
    {
        subject_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:subject[@xml:lang='de']");
        //Print_List_Names(subject_list);
    }
    private void Set_Formats()
    {
        format_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:format[@xml:lang='de']");
        //Print_List_Names(format_list);
    }
    private void Set_Rights()
    {
        rights_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:rights[@xml:lang='de']");
        //Print_List_Names(rights_list);
    }

    private void Set_Years()
    {
        year_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dcterms:created[@xml:lang='en']");
        //if(!year_list.Any()) //Debug.Log("empty");
        //Print_List_Names(year_list);
    }

    private void Set_this_empty_error()
    {
        this_empty_list = read_xml_script.Get_Nodes_by_Name(root, "descendant::dc:this_is_not_available");
        //Print_List_Names(this_empty_list);
    }

    private void Set_Links()
    {
        if(string.IsNullOrEmpty(read_xml_script.Get_a_Node_by_Name(root, "descendant::edm:landingPage/@rdf:resource")))
        {
            //Debug.Log("Link is empty");
        }
        else{
            europeana_link = read_xml_script.Get_a_Node_by_Name(root, "descendant::edm:landingPage/@rdf:resource");
            //Debug.Log("this:" + europeana_link);
        } 
    }

    public string Get_Final_Text()
    {
        string final_txt = "";
        final_txt += "<b>Titel:</b>  "+ StrList_to_String(title_list)+"<br>";
        final_txt += "<b>Urheber:</b>  "+ StrList_to_String(creator_list)+"<br>";
        final_txt += "<b>Material/Technik:</b>  "+ StrList_to_String(medium_list)+"<br>";
        final_txt += "<b>Beschreibung:</b>  "+ StrList_to_String(description_list)+"<br>";
        final_txt += "<b>Schlagworte:</b>  "+ StrList_to_String(subject_list)+"<br>";
        final_txt += "<b>Datum:</b>  "+ StrList_to_String(year_list)+"<br>";
        final_txt += "<b>Rechte:</b>  "+ StrList_to_String(rights_list)+"<br>";
        return final_txt;
    }
    
    
    private void Print_List_Names(List<string> list)
    {
        foreach( var x in list) {
            Debug.Log("Value: "+ x);
        }
    }

    private string StrList_to_String(List<string> str_list)
    {
        string list_text="";
        foreach(string x in str_list)
        {
            //if(i == 1)list_text += "<indent=10%>" + x + "<br>";
            list_text += x+"; ";
        } 
        //if (i >= 1)list_text +="</indent>";
        return list_text;
    }
/*
    private void Set_Europeana_Panel(bool state)
    {
        Europeana_Panel.SetActive(state);
    }
    public void Unset_Europeana_Panel()
    {
        Set_Europeana_Panel(false);
    }
*/
    public Sprite Get_Manually_Set_img()
    {
        return manual_img;
    }
    
}
