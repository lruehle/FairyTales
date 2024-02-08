using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Object follows Player Character with move_speed keeping distance
public class Follow_Script : MonoBehaviour
{
    public float distance; 
    public float move_speed; 
    private Transform target_transform;
    private GameObject player;
    private Player_movement player_movement_script;
    //public enum Move_states {idle, walk};
    public bool is_moving;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player_movement_script = player.GetComponent<Player_movement>();
        target_transform = player.GetComponent<Transform>();
        move_speed = player_movement_script.moveSpeed + 1;
    }

    // Update is called once per frame
    void Update()
    {
        Follow_Character();
    }

    public void Follow_Character()
    {
        if(Vector2.Distance(transform.position, target_transform.position) > distance)
        {
            is_moving = true;
            transform.position = Vector2.MoveTowards(transform.position, target_transform.position, move_speed * Time.deltaTime);
        }
        else is_moving = false; 
    }
}
