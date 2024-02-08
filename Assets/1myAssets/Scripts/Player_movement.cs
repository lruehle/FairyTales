using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    //public Vector2 forceToApply;
    public Vector2 player_input;
    private SpriteRenderer player_rend;
    private Animator player_anim;
    private enum Animation_states {idle, walk};

    void Start()
    {
        player_anim = GetComponent<Animator>();
        player_rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //negative values for left/up, positive values for right/down
        player_input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
    }
    void FixedUpdate()
    {
        Vector2 moveForce = player_input * moveSpeed;
        /* apply this if force is supposed to be applied to character (hits, pushes etc.)
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if (Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }*/
        rb.velocity = moveForce;
        Animation_update();
    }
    
    private void Animation_update()
    {
        Animation_states anim_state = 0;
        if(player_input.x!=0 || player_input.y !=0f)
        {
            anim_state = Animation_states.walk;
            if(player_input.x > 0f) player_rend.flipX = false;
            else if(player_input.x < 0f) player_rend.flipX=true;
        }
        else anim_state = Animation_states.idle;
        player_anim.SetInteger("anim_state", (int)anim_state);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided");
    }
}
