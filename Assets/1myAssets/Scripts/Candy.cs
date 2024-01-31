using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{
    [SerializeField] GameObject obj_with_state_manager;
    private State_Manager_Player state_Manager;
    private Story_Teller story_teller_script;
    //private bool followed;
    [SerializeField] private string first_encounter;
    [SerializeField] private string follow_encounter;
    
    // Start is called before the first frame update
    void Start()
    {
        state_Manager = obj_with_state_manager.GetComponent<State_Manager_Player>();
        story_teller_script = GameObject.Find("Canvas/BG/Story_Teller_Object").GetComponent<Story_Teller>();
        //followed =false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            state_Manager.candy++;
            //if(state_Manager.candy >= 3){return;}
            if(state_Manager.candy == 1)
            {
                story_teller_script.Add_to_Panel_txt(first_encounter);
            }
            else if(state_Manager.candy ==2)
            {
                story_teller_script.Add_to_Panel_txt(follow_encounter);
                //followed = true;
            }
            
            //float timer delay
            Destroy(gameObject,0.2f);
           
        }

    }
}
