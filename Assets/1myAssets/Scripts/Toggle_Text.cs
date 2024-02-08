using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toggle_Text : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    void Start()
    {   
        //alternative if Function should not be set via Editor: 
        //GetComponent<Toggle> ().onValueChanged.AddListener((id)=> Trigger_this_Toggle());
    }

    public void Trigger_this_Toggle()
    {
        Toggle_Propp_Funkts.current.ToggleAction(id);
    }
}
