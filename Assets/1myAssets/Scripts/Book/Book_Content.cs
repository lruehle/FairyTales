using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//based on Christina Creates Games Script https://github.com/Maraakis/ChristinaCreatesGames/tree/main/Interactive%20Book%20with%20TextMeshPro
public class Book_Content : MonoBehaviour
{
    [TextArea(10,20)]
    [SerializeField] private string content;
    [SerializeField] private TMP_Text left_side;
    [SerializeField] private TMP_Text left_pagination;
    [SerializeField] private TMP_Text right_side;
    [SerializeField] private TMP_Text right_pagination;

    
    private void Awake()
    {
        Setup_Content();
        Update_Pagination();
    }

    private void On_Validatio()
    {
        Update_Pagination();
        if(left_side.text == content) return;
        Setup_Content();
    }


    private void Setup_Content()
    {
        left_side.text = content;
        right_side.text = content;
    }

    private void Update_Pagination()
    {
        left_pagination.text = left_side.pageToDisplay.ToString();
        right_pagination.text = right_side.pageToDisplay.ToString();
    }

    //each side displays only every 2nd page. Left uneven numbers, right even numbers
    public void Previous_Page()
    {
        if(left_side.pageToDisplay < 1)
        {
            left_side.pageToDisplay = 1;
            return;
        }
        if (left_side.pageToDisplay -2 > 1) left_side.pageToDisplay -= 2; 
        else  left_side.pageToDisplay = 1;

        right_side.pageToDisplay = left_side.pageToDisplay + 1;
        Update_Pagination();
    }

    public void Next_Page()
    {
        if(right_side.pageToDisplay >= right_side.textInfo.pageCount) return;
        if(left_side.pageToDisplay >= left_side.textInfo.pageCount -1)
        {
            left_side.pageToDisplay = left_side.textInfo.pageCount -1;
            right_side.pageToDisplay = left_side.pageToDisplay +1;
        }
        else
        {
            left_side.pageToDisplay += 2;
            right_side.pageToDisplay = left_side.pageToDisplay +1;
        }
        Update_Pagination();
    }
}
