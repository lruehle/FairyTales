using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;

public class Save_Story : MonoBehaviour 
{

    private Story_Teller story_teller_script;
	//private string save_load_text;
    
    void Start()
	{
        //save_load_text ="this is a text";
        Debug.Log(Application.persistentDataPath);
        story_teller_script = gameObject.GetComponent<Story_Teller>();
	}

    private string Read_StoryTeller_txt()
    {
        return story_teller_script.Get_Panel_txt();
    }

    private void Set_StoryTeller_txt(string txt)
    {
        story_teller_script.Set_Panel_txt(txt);
    }

    //if Save is called in menue
    public void Save_this_Story()
    {
        string path = Application.persistentDataPath + "/Story_save.txt"; //+dateTime?
        //true = append
        StreamWriter writer = new StreamWriter(path, false);
        writer.Write(Read_StoryTeller_txt());
        writer.Close();
        StreamReader reader = new StreamReader(path);
        reader.Close();
    }

    //if Load is called in Menu
    public void Load_Story()
    {
        string path = Application.persistentDataPath + "/Story_save.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        Set_StoryTeller_txt(reader.ReadToEnd());
        reader.Close();
    }

}
