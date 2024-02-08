using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages Information about visited Places, collected items and fought fights
public class State_Manager_Player : MonoBehaviour
{
    //propp state vs place state better
    public enum Available_States {none, home, roses, windmills, city, forest, deepForest, mountains, mountain_pass, magicalHelp, interdiction, violation, trickery, recognition, complicity, difficultTask, wedding}; 
    //public enum Available_Function_States {empty, magicalHelp, interdiction, violation, trickery, recognition, complicity}; 
    [SerializeField] private Available_States current_state;
    [SerializeField] private Available_States prev_state;
   // [SerializeField] private Available_Function_States current_function_state;
    //[SerializeField] private Available_Function_States prev_function_state;
    [SerializeField] private GameObject companion;
    [SerializeField] private GameObject princess;
    [SerializeField] private GameObject princess_tower;
    [SerializeField] private GameObject evil_char;
    //int might be used, if multiple
    private bool fought_evil;
    private bool has_married;
    public bool has_freed_princess;
    private bool has_companion;
    private int candy_amount;
    [SerializeField]private int candy_limit;
    // Start is called before the first frame update
    void Start()
    {
        prev_state=Available_States.home;
        current_state= Available_States.home;
        has_companion = false;
        fought_evil = false;
    }

    public void increase_candy(int amount)
    {
        candy_amount += amount;
    }
    public int Get_Candy_Amount()
    {
        return candy_amount;
    }
     public int Get_Candy_Limit()
    {
        return candy_limit;
    }

    public bool Get_Has_Companion()
    {
        return has_companion;
    }

    public void Set_Companion(bool companion_state)
    {
        has_companion = companion_state;
    }
    
    public bool Get_Free_Princess()
    {
        return has_freed_princess;
    }
    public void Set_Free_Princess(bool free_bool)
    {
        has_freed_princess = free_bool;
    }
    public bool Get_Has_Married()
    {
        return has_married;
    }
    public void Set_Has_Married(bool marry_state)
    {
        has_married = marry_state;
    }

    public void Set_Fought_Evil( bool fight_bool)
    {
        fought_evil = fight_bool;
    }
    public bool Get_Fought_Evil()
    {
        return fought_evil;
    }

    // sets current Location state to current variable
    //current should contain the sending Objects Location state
    public void Set_Current_State(Available_States current)
    {
        Set_Previous_State(current_state);
        current_state = current;
    }

    public Available_States Get_Current_State()
    {
        return current_state;
    }
    
    public void Set_Previous_State(Available_States previous)
    {
        prev_state = previous;
    }

    public Available_States Get_Previous_State()
    {
        return prev_state;
    }


    //needs to be on Player for transform to take on Players position. If not, use Logic used in Follow script to access Player position
    public void Instantiate_Companion()
    {
        if(has_companion)
        {return;}
        Instantiate(companion,new Vector2(transform.position.x+2, transform.position.y+2), transform.rotation);
        Set_Companion(true);
        //NPC_interaction; Function state not necessary here, but might be preferred
    }

    public void Fight_Evil()
    {
        if(fought_evil)
        {return;}
        Set_Fought_Evil(true);
        evil_char.GetComponent<Animator>().Play("disappear");
        StartCoroutine(Wait_for_Death(0.4f));
        //NPC_interaction; Function state not necessary here, but might be preferred
    }

    public void Free_Princess()
    {
        if(has_freed_princess)
        {return;}
        //Instantiate(princess,new Vector2(transform.position.x+2, transform.position.y+2), transform.rotation);
        StartCoroutine(Wait_for_Princess(0.3f));
        Set_Free_Princess(true);
    }

    public void Get_Married()
    {
        if(has_married)
        {return;}
        Set_Has_Married(true);
        //NPC_interaction;Function state not necessary here, but might be preferred
        //do smth; End of game?
    }

    private IEnumerator Wait_for_Death(float seconds_to_wait)
    {
        yield return new WaitForSeconds(seconds_to_wait);
        evil_char.SetActive(false);
    }

    private IEnumerator Wait_for_Princess(float seconds_to_wait)
    {
        yield return new WaitForSeconds(seconds_to_wait);
        princess_tower.SetActive(false);
        yield return new WaitForSeconds(.4f);
        Instantiate(princess,new Vector2(princess_tower.GetComponent<Transform>().position.x-0.4f, princess_tower.GetComponent<Transform>().position.y-1.5f), transform.rotation);
    }


}
