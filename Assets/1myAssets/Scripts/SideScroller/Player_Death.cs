using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{
    private Animator player_anim;
    // Start is called before the first frame update
    void Start()
    {
        player_anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("trap"))
        {
            
            Death();
        }
    }

    private void Death()
    {
        Debug.Log("death");
        player_anim.SetTrigger("death");
        //player_anim.SetBool("death_bool", true);
        //Display Text
        Load_main_Scene();
    }
    private void Load_main_Scene()
    {
        SceneManager.LoadScene(0);
    }
}
