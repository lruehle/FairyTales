using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Item_Interaction : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI gold_purse;
    private int coin_counter = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Item"))
        {
            Destroy(collision.gameObject);
            coin_counter ++;
            gold_purse.text = "Gold: " + coin_counter;
        }
    }

}
