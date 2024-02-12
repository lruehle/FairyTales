using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menue_function : MonoBehaviour
{
    [SerializeField] private GameObject save_load_story;
    [SerializeField] private GameObject function_panel;
    private Save_Story save_load_script;

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
        SceneManager.LoadScene(1);
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

    public void Funktion_Panel_Interaktion()
    {
        if(function_panel)
        {
            function_panel.SetActive(!function_panel.activeSelf);
        }
    }
}
