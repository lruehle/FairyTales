using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

//This script has to be attached to all Places, that respond to the players movement
public class Move_interaction : MonoBehaviour
{
    //reference Game Object which displays the interaction text here
    private TMP_Text text_output_Panel;
    private Story_Teller story_teller_script;

    [SerializeField] GameObject obj_with_state_manager;
    private State_Manager_Player state_Manager;

    // This is a TextArea with the Text for this Place, that is send to to StoryPanel
    [TextArea(10,10)]
    [SerializeField] private string content;
    [SerializeField] private string exit_content;

    //these are possible states for the Places. Each Place has only one state
    [SerializeField] private State_Manager_Player.Available_States place_State;

    public bool playerIsClose;
    public bool in_state;

    void Start()
    {
        story_teller_script = GameObject.Find("Canvas/BG/Story_Teller_Object").GetComponent<Story_Teller>();
        state_Manager = obj_with_state_manager.GetComponent<State_Manager_Player>();
        in_state = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // if Player is in Range, set tag and send responding Text to StoryPanel
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //last state has to be != ,
        if(collision.CompareTag("Player"))
        {
            playerIsClose = true;
            // checks if previous and current state are different from this Place_state, so that Players don't trigger the same Text right after each other 
            if(state_Manager.Get_Current_State()!=place_State && state_Manager.Get_Previous_State()!=place_State)
            {
                in_state = true;
                Debug.Log(content);
                story_teller_script.Add_to_Panel_txt(content);
                state_Manager.Set_Current_State(place_State);
            }
        }
    }

    // If Player leaves Range, change tag
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = false;
            //display exit_content only if enter content has been shown
            if(state_Manager.Get_Current_State() == place_State && in_state)
            {
                if(exit_content!="")story_teller_script.Add_to_Panel_txt(exit_content);
                in_state = false;
            }
        }
    }
}
