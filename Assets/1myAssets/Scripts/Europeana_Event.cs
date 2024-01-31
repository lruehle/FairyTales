using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//general Reuse interaction with Objects from Europeana and Aggregators (manual and auto-Input possible)
public class Europeana_Event : MonoBehaviour
{
    public enum Auto_or_Manual {manual, auto};
    private Europeana_Item_get_Data europeana_data;
    private Manual_Reuse_Instance manual_data;
    private bool panel_status;
    [SerializeField] private KeyCode interaction_Key;
    public bool playerIsClose;
    public UnityEvent europeana_interaction;
    public Auto_or_Manual auto_or_manual;

    [SerializeField] private GameObject Europeana_Panel;
    private Item_Panel_Handle panel_handler;

    void Start()
    {
        interaction_Key = KeyCode.E;
        if(auto_or_manual==Auto_or_Manual.auto) europeana_data = gameObject.GetComponent<Europeana_Item_get_Data>();
        else if (auto_or_manual== Auto_or_Manual.manual) manual_data = gameObject.GetComponent<Manual_Reuse_Instance>();
        panel_status = false;
        panel_handler = Europeana_Panel.GetComponent<Item_Panel_Handle>();
    }

    void Update()
    {
        if(playerIsClose)
        {
            if(Input.GetKeyDown(interaction_Key))
            {
                panel_status = !panel_status; 
                europeana_interaction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("rose collision");
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = false;
            //europeana_data.Unset_Europeana_Panel();
            Unset_Europeana_Panel();
        }
    }

    //writes the Objects XML_Info into the Panel 
    public void Interaction_event()
    {
        //if(panel_status) europeana_data.Write_to_Panel();
        Debug.Log("event fire");
        if(panel_status) 
        {   
            Debug.Log("fire with panel");
            Write_to_Panel(europeana_data.Get_Final_Text(),europeana_data.Get_Europeana_link(), europeana_data.Get_Manually_Set_img());
            Set_Europeana_Panel(true);
        }
        //else europeana_data.Unset_Europeana_Panel();
        else Unset_Europeana_Panel();
    }

    //writes the manually filled Info into the Panel
    public void Interaction_Manual_Event()
    {
        if(panel_status) 
        {
            Write_to_Panel(manual_data.Get_Full_Text(), manual_data.Get_Origin_Link(), manual_data.Get_Obj_Sprite());
            Set_Europeana_Panel(true);
        }
        else Unset_Europeana_Panel();
    }

    public void Write_to_Panel(string body_text, string body_link, Sprite image)
    {
        //check Ressources for lists vs arrays if this is triggered often
        //Europeana_Panel_txt.text = Create_Final_Text();
        panel_handler.Set_Body(body_text);
        panel_handler.Set_Link(body_link);
        panel_handler.Set_Display_Image(image);
    }

    private void Set_Europeana_Panel(bool state)
    {
        Europeana_Panel.SetActive(state);
    }
    public void Unset_Europeana_Panel()
    {
        Set_Europeana_Panel(false);
    }
}
