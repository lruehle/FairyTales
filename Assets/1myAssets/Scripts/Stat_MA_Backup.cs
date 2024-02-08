using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Manages Information about visited Places, collected items and fought fights
public class Stat_MA_Backup : MonoBehaviour
{
    //propp state vs place state better
    public enum Available_States {home, roses, windmills, city, forest, deepForest, mountains, mountain_pass, magicalHelper, interdiction, trickery, recognition, complicity}; 
    [SerializeField]private Available_States current_state;
    [SerializeField] private Available_States prev_state;
    [SerializeField] private GameObject companion;
    [SerializeField] private GameObject evil_char;
    //int might be used, if multiple
    private bool fought_evil;
    private bool has_married;
    private bool has_companion;
    private int candy_amount;
    [SerializeField]private int candy_limit;
    // Start is called before the first frame update
    void Start()
    {
        prev_state=0;
        current_state = 0;
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
    }

    public void Fight_Evil()
    {
        if(fought_evil)
        {return;}
        Set_Fought_Evil(true);
        evil_char.GetComponent<Animator>().Play("disappear");
        StartCoroutine(Wait_for_Death(0.4f));
    }

    public void Get_Married()
    {
        if(has_married)
        {return;}
        Set_Has_Married(true);
        //do smth
    }

    private IEnumerator Wait_for_Death(float seconds_to_wait)
    {
        yield return new WaitForSeconds(seconds_to_wait);
        evil_char.SetActive(false);
    }


}
