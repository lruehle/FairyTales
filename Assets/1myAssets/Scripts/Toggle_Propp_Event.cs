using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Propp_Event : MonoBehaviour
{

    public static Toggle_Propp_Event current;
    public event Action<int> on_Toggle_Action;
    // Start is called before the first frame update
    private void Awake()
    {
        current = this;
    }
    
    //Event an Interaction_Place Objects can listen to
    //id == Propp Funktion Object with the Collider which is to be turned off
    public void ToggleAction(int id)
    {
        if(on_Toggle_Action != null)
        {
            on_Toggle_Action(id);
        }
    }

}   
