using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class NPC_Interaction_event : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject obj_with_state_manager;
    private State_Manager_Player state_Manager;
    private Story_Teller story_teller_script;
    [SerializeField] private KeyCode interaction_Key;
    [SerializeField] private string content;
    [SerializeField] private GameObject info_txt;
    public UnityEvent npc_event;
    private bool playerIsClose;
    void Start()
    {
        //fought_evil == State_Manager_Player.Get_Fought_Evil();
        state_Manager = obj_with_state_manager.GetComponent<State_Manager_Player>();
        story_teller_script = GameObject.Find("Canvas/BG/Story_Teller_Object").GetComponent<Story_Teller>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerIsClose)
        {
            if(Input.GetKeyDown(interaction_Key))
            {
                npc_event.Invoke();
            }
        }
        
    }
     private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("npc collision");
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = false;
            if(info_txt) info_txt.SetActive(false);
        }
    }

    private void Write_to_Panel(string txt)
    {
        story_teller_script.Add_to_Panel_txt(txt);
    }

    public void Spawn_Companion_event()
    {
        if(!state_Manager.Get_Has_Companion())
        {
            Write_to_Panel(content);
        } 
        state_Manager.Instantiate_Companion();
    }

    public void Fight_Evil_event(){
        if(!state_Manager.Get_Fought_Evil())
        {
            Write_to_Panel(content);
        }
        state_Manager.Fight_Evil();
    }

    public void Free_Princess()
    {
        if(!state_Manager.Get_Free_Princess())
        {
            Write_to_Panel(content);
        }
        state_Manager.Free_Princess();
    }

    public void Marry_Someone()
    {
        if(!state_Manager.Get_Free_Princess())
        {
            info_txt.SetActive(true);
        }
        if(state_Manager.Get_Free_Princess() && !state_Manager.Get_Has_Married())
        {
            Write_to_Panel(content);
        }
        state_Manager.Get_Married();
    }
}
