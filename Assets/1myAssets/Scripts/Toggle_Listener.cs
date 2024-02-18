using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Listener : MonoBehaviour
{
    public int id;
    void Start()
    {
        //add this objects toggle_on Funtcion to List of eventlisteners
        Toggle_Propp_Event.current.on_Toggle_Action += Toggle_On;
    }

    // listen to event
    private void Toggle_On(int id)
    {
        if(id== this.id)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;
        }
    }

    //unsubscribe from listening when object is destroyed
    private void OnDestroy()
    {
        Toggle_Propp_Event.current.on_Toggle_Action -=Toggle_On;
    }
}
