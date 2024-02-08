using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_Movement_Animation : MonoBehaviour
{
    private GameObject player;
    //private Follow_Script.Move_states npc_move_state;
    private Transform target_transform;
    private SpriteRenderer npc_rend;
    private Follow_Script follow_Script;
    private Animator npc_anim;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target_transform = player.GetComponent<Transform>();
        npc_rend = GetComponent<SpriteRenderer>();
        npc_anim = GetComponent<Animator>();
        follow_Script = GetComponent<Follow_Script>();
    }

    void FixedUpdate()
    {
        Sprite_Update();
        //Animation_Update();
    }
    private void Sprite_Update()
    {
        if(target_transform.position.x > transform.position.x) npc_rend.flipX = false;
        else if(target_transform.position.x < transform.position.x) npc_rend.flipX=true;
    }

    /*private void Animation_Update()
    {
        if(Vector2.Distance(transform.position, target_transform.position) > distance) npc_anim.SetBool("move", true);//npc_anim.SetInteger("anim_state", 1);
        //if(follow_Script.is_moving)npc_anim.SetInteger("anim_state", 1);
        //else npc_anim.SetInteger("anim_state", 0);
        else npc_anim.SetBool("move", false);
        //npc_anim.SetInteger("anim_state", (int)follow_Script.move_state);
    }*/
}
