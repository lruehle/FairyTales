using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Npc_Interaction : MonoBehaviour
{
    public bool playerIsClose;
    public GameObject interaction_Panel;

    void Update()
    {
        if(playerIsClose)
        {
            interaction_Panel.SetActive(true); //muss doch nicht jedes Update sein, einmal bei enter reicht?
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            playerIsClose = false;
            interaction_Panel.SetActive(false);
        }
    }

    public void choice_fight()
    {
        Debug.Log("fight");
    }

    public void choice_give()
    {
        Debug.Log("give");
    }

    public void choice_receive()
    {
        Debug.Log("receive");
    }
}
