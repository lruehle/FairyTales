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

    // Player Character, but can also be Management_object for entire Game
    [SerializeField] GameObject obj_with_state_manager;
    private State_Manager_Player state_Manager;

    // This is a TextArea with the Text for this Place, that is send to to StoryPanel
    [TextArea(10,10)]
    [SerializeField] private string content;
    [SerializeField] private string exit_content;

    //these are possible states for the Places. Each Place has only one state
    [SerializeField] private State_Manager_Player.Available_States place_State;
    //[SerializeField] private State_Manager_Player.Available_Function_States function_State;

    public bool playerIsClose;
    public bool in_state;
    public bool has_condition;
    [SerializeField] private State_Manager_Player.Available_States obligatory_prev_State;
    [SerializeField] private string condition_content;

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
        if(collision.CompareTag("Player"))
        {
            playerIsClose = true;
            //state_Manager = collision.GetComponent<State_Manager_Player>(); // if other Gameobjects get Management Scripts (companions etc.) 

            // checks if previous and current state are different from this Place_state, so that Players don't trigger the same Text twice right after each other 
            if(state_Manager.Get_Current_State() == obligatory_prev_State)
            {
                in_state = true;
                Debug.Log(condition_content);
                story_teller_script.Add_to_Panel_txt(condition_content);
                state_Manager.Set_Current_State(place_State);
            }
            //so far conditions only contain obligatory previous states, so Function should return if condition is not fullfilled
            else if (has_condition) return;
            //normal interaction if no condition is set:
            else if(state_Manager.Get_Current_State()!=place_State && state_Manager.Get_Previous_State()!=place_State)
            {
                //interdiction one and two
                in_state = true;
                Debug.Log(content);
                story_teller_script.Add_to_Panel_txt(content);
                state_Manager.Set_Current_State(place_State);
            }
        }
    }

    // If Player leaves Range, change in_state
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            playerIsClose = false;
            Debug.Log("exit+ "+ place_State);
            
            // Forest fully encapsules Trickery_Gameobject, state should return to forest without additional collider check when leaving Trickery
            //switch for trickery & complicity 
            if(place_State == State_Manager_Player.Available_States.trickery)
            {
                state_Manager.Set_Current_State(State_Manager_Player.Available_States.forest);
            }
            //display exit_content only if enter content has been shown
            else if(in_state)//if(state_Manager.Get_Current_State() == place_State && in_state)
            {
                if(exit_content!="")story_teller_script.Add_to_Panel_txt(exit_content);
                in_state = false;
            }
            else in_state = false;

        }
    }
}
