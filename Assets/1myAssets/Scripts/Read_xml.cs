using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Xml;
using System.Linq;
using Unity.VisualScripting;
using System.Text.RegularExpressions;

public class Read_xml : MonoBehaviour
{
    //private XmlElement root;
    private XmlDocument file_data;
    private XmlNode ore_proxy;
    public string item_creator;
    private XmlNamespaceManager nsmgr;
    //private string f_name = "Museu_ProvidedCHO_Stadtgeschichtliches_Museum_Leipzig_Z0016673";

   private void Awake()
   {
        //needs to stay for namspacemanager
        TextAsset xml_text = Resources.Load<TextAsset>("Museu_ProvidedCHO_Stadtgeschichtliches_Museum_Leipzig_Z0016673");
        file_data = new XmlDocument();
        file_data.LoadXml(xml_text.text);
        //create xmlNamespaceanager to resolve the default namespace
        nsmgr = new XmlNamespaceManager(file_data.NameTable);
        nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
        nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");
        nsmgr.AddNamespace("dcterms", "http://purl.org/dc/terms/");
        nsmgr.AddNamespace("gs84_pos", "http://www.w3.org/2003/01/geo/wgs84_pos#");
        nsmgr.AddNamespace("skos", "http://www.w3.org/2004/02/skos/core#");
        nsmgr.AddNamespace("ore", "http://www.openarchives.org/ore/terms/");
        nsmgr.AddNamespace("edm", "http://www.europeana.eu/schemas/edm/");
        //find element
        //root = file_data.DocumentElement;
        //ore_proxy = root.SelectSingleNode("descendant::ore:Proxy", nsmgr);
   }
    // Start is called before the first frame update
    void Start()
    {
        /*Debug.Log(ore_proxy.InnerXml);
        Debug.Log("innerxml single" + ore_proxy.SelectSingleNode("descendant::dc:description", nsmgr).InnerXml);
        //Debug.Log("innerxml multipl" + root.SelectNodes("descendant::dc:description", nsmgr));
        XmlNodeList ore = Get_Ore_Proxys(f_name);
        Get_Nodes_by_Name(root, "descendant::dc:description");
        //Get_Ore_Child_Element_text(ore, "search");
        */
    }


    public XmlNodeList Get_Ore_Proxys(string filename)
    {
        XmlElement root = Get_File_Root(filename);
        XmlNodeList ore_proxys = root.SelectNodes("descendant::ore:Proxy", nsmgr);
        return ore_proxys;
    }

    public XmlElement Get_File_Root(string filename)
    {   
        //add try / catch
        TextAsset xml_text = Resources.Load<TextAsset>(filename);
        file_data = new XmlDocument();
        file_data.LoadXml(xml_text.text);
        /*nsmgr = new XmlNamespaceManager(file_data.NameTable);
        nsmgr.AddNamespace("rdf", "http://www.w3.org/1999/02/22-rdf-syntax-ns#");
        nsmgr.AddNamespace("ore", "http://www.openarchives.org/ore/terms/");
        nsmgr.AddNamespace("dc", "http://purl.org/dc/elements/1.1/");*/
        return file_data.DocumentElement;
    }

    public List<string> Get_Nodes_by_Name(XmlElement root, string node_name)
    {
        XmlNodeList selected_children = root.SelectNodes(node_name, nsmgr);
        List<string> children_list = new List<string>();
        string replacement;
        foreach(XmlNode i in selected_children)
        {
            if(i.InnerText.Length>0) 
            {
                //Debug.Log("child_elem:"+i.InnerXml);
                replacement = Regex.Replace(i.InnerText, @"\t|\n|\r|\s+"," ");
                children_list.Add(replacement);
            }
        }
        //return selected_children;
        return children_list;
    }

    public string Get_a_Node_by_Name(XmlElement root, string node_name)
    { //returns empty if not available
        XmlNode selected_child = root.SelectSingleNode(node_name, nsmgr);
        if(selected_child!=null) return selected_child.InnerXml;
        else return "";
    }


    public string Element_to_String(XmlElement element)
    {
        return element.InnerText;
    }
    
    /*public void Get_Ore_Child_Element_text(XmlNodeList ore, string searched_child)
    {
        XmlNodeList s_childs;
        foreach(XmlNode i in ore)
        //node ist die gesamte ore_node mit allen childs etc.
        {
            if (i.InnerText.Length>0) 
            { 
                //Debug.Log("elem:"+i.InnerXml);
                s_childs = i.SelectNodes("searched_child", nsmgr);
            }
            //XmlNodeList children = ore[i].SelectNodes(searched_child);
        }
       
    }*/
}
