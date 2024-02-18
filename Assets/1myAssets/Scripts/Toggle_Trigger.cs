using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Trigger : MonoBehaviour
{
    //this is connected to the Toggle-Panel
    //id is value for each toggle
    //id of toggle and id of Object to be turned off with toggle must be identical 
    public int id;
    void Start()
    {   
        //alternative if Function should not be set via Editor: 
        //GetComponent<Toggle> ().onValueChanged.AddListener((id)=> Trigger_this_Toggle());
    }

    public void Trigger_this_Toggle()
    {
        Toggle_Propp_Event.current.ToggleAction(id);
    }
}
