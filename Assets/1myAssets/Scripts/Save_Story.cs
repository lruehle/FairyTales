using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Unity.VisualScripting;
using System.Linq;
using System.IO.Enumeration;

public class Save_Story : MonoBehaviour 
{

    private Story_Teller story_teller_script;
    private DirectoryInfo d_info;
	//private string save_load_text;
    private string tale_txt;
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
    //saves to one of 3 files; if 3 save_files exist already, oldest is overwritten
    public void Save_this_Story()
    {
        d_info = new DirectoryInfo(Application.persistentDataPath);
        string path;
        int files_in_dir = Count_Files_In_Dir(d_info);
        if(!d_info.Exists){return ;}
        switch (files_in_dir)
        {
            case 1:
                path = Application.persistentDataPath + "/Story_save_2"+".txt";
                break;
            case 2:
                path = Application.persistentDataPath + "/Story_save_3"+".txt";
                break;
            case 3:
                //path = Application.persistentDataPath + "/Story_save_2"+".txt";
                string oldest = Return_Oldest_SaveFile(d_info);
                path = oldest;
                break;
            default:
                path = Application.persistentDataPath + "/Story_save_1"+".txt";
                break;
        }
        //else {path = Application.persistentDataPath + "/Story_save_"+DateTime.Now.ToString("ddmmyyyy_HH:mm")+".txt";}
        
        //true = append
        StreamWriter writer = new StreamWriter(path, false);
        tale_txt = Read_StoryTeller_txt();
        writer.Write(tale_txt.Replace("<br>", Environment.NewLine));
        writer.Close();
    }

    //returns count of save_files only
    private int Count_Files_In_Dir(DirectoryInfo dir_info)
    {
        int files_in_dir = 0;
        foreach(var file in dir_info.GetFiles("Story_save*.txt"))
        {
            files_in_dir ++;
            Debug.Log(files_in_dir);
        }
        return files_in_dir;

    }
    private string Return_Oldest_SaveFile(DirectoryInfo dir_info)
    {
        //if more files are in game, OrderBy should be replaced
        FileSystemInfo file_sys_info = dir_info.GetFileSystemInfos().OrderBy(file =>file.LastWriteTime).Skip(2).FirstOrDefault();//FirstOrDefault();
        string file_name = file_sys_info.FullName;
        //foreach(var file in dir_info.GetFiles("Story_save*.txt"))
        return file_name;
    }

    //if Load is called in Menu
    /*
    public void Load_Story()
    {
        string path = Application.persistentDataPath + "/Story_save.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        Set_StoryTeller_txt(reader.ReadToEnd());
        reader.Close();
    }*/

}
