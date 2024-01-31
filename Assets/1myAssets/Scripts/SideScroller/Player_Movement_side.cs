using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement_side : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator player_anim;
    private SpriteRenderer player_rend;
    private BoxCollider2D coll;

    private float move_x = 0f;
    private enum Animation_states {idle, walk, jump, fall};

    [SerializeField] private LayerMask ground_layer;

    public float moveSpeed =6f;
    public float jumpForce =14f;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player_anim = GetComponent<Animator>();
        player_rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move_x * moveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump")&& Is_grounded())
        {
            rb.velocity = new Vector3(rb.velocity.x,jumpForce); 
        }
        Animation_update();
    }

    private bool Is_grounded(){
        //boxcast improvemment to collision check, as the sides won't be detected
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, ground_layer);
    }

    private void Animation_update()
    {
        Animation_states anim_state = 0;
        if(move_x >0f)
        {
            //player_anim.SetBool("is_walking", true);
            anim_state = Animation_states.walk;
            player_rend.flipX = false;
        }
        else if(move_x<0f)
        {
            anim_state = Animation_states.walk;//har_anim.SetBool("is_walking", true);
            player_rend.flipX=true;
        }
        else anim_state = Animation_states.idle;
        if(rb.velocity.y >0.09f) anim_state = Animation_states.jump;
        else if(rb.velocity.y <-0.09f) anim_state = Animation_states.fall;
        player_anim.SetInteger("anim_state", (int)anim_state);
    }

   
}
