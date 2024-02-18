using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menue_function : MonoBehaviour
{
    [SerializeField] private GameObject save_load_story;
    [SerializeField] private GameObject function_panel;
    private Save_Story save_load_script;

    //fade
    public GameObject fade;
    public Image fade_img;
    public Animator anim;
    
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Story_world") StartCoroutine(Wait_for_Fade_End());
    }
    public void Open_Main_Menue()
    {
        if(SceneManager.GetActiveScene().name == "Story_world")
        {
            save_load_script = save_load_story.GetComponent<Save_Story>();
            save_load_script.Save_this_Story();
        }
        SceneManager.LoadScene(0);
    }

    public void Start_this_Game()
    {
        if(SceneManager.GetActiveScene().name == "Story_world")
        {
            fade.SetActive(true);
            save_load_script = save_load_story.GetComponent<Save_Story>();
            save_load_script.Save_this_Story();
            StartCoroutine(Fade());
        }
        else SceneManager.LoadScene(1);
    }
    public void Read_Tale()
    {
        SceneManager.LoadScene(2);
    }

    public void Quit_this_Game()
    {
        if(SceneManager.GetActiveScene().name == "Story_world")
        {
            save_load_script = save_load_story.GetComponent<Save_Story>();
            save_load_script.Save_this_Story();
        }
        Application.Quit();
    }

    public void Funktion_Panel_Interaction()
    {
        if(function_panel)
        {
            function_panel.SetActive(!function_panel.activeSelf);
        }
    }

    IEnumerator Fade()
    {
        anim.SetBool("fade", true);
        yield return new WaitForSeconds(1f);//new WaitUntil(()=>fade_img.color.a == 1);
        SceneManager.LoadScene(1);
    }
    IEnumerator Wait_for_Fade_End()
    {
        yield return new WaitForSeconds(1f);
        fade.SetActive(false);
    }
}
