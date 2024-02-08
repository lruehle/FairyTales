using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toggle_Listener : MonoBehaviour
{
    // Start is called before the first frame update
    public int id;
    void Start()
    {
        Toggle_Propp_Funkts.current.on_Toggle_Action += Toggle_On;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Toggle_On(int id)
    {
        if(id== this.id)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = !gameObject.GetComponent<BoxCollider2D>().enabled;
        }
    }

    private void OnDestroy()
    {
        Toggle_Propp_Funkts.current.on_Toggle_Action -=Toggle_On;
    }
}
