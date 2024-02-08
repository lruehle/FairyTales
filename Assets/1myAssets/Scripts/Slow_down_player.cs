using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slow_down_player : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float slow_down_value;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
         {
           other.GetComponent<Player_movement>().moveSpeed = other.GetComponent<Player_movement>().moveSpeed -slow_down_value;
         }
        else if(other.CompareTag("Companion"))
         {
            other.GetComponent<Follow_Script>().move_speed = other.GetComponent<Follow_Script>().move_speed -slow_down_value;
         }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
         {
           other.GetComponent<Player_movement>().moveSpeed = other.GetComponent<Player_movement>().moveSpeed +slow_down_value;
         }
        else if(other.CompareTag("Companion"))
         {
           other.GetComponent<Follow_Script>().move_speed = other.GetComponent<Follow_Script>().move_speed +slow_down_value;
         }
    }
}
