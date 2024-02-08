using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Princess_tower : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject sleep_sprite;
    private Animator princess_anim;
    void Start()
    {
        princess_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
         if(other.CompareTag("Player"))
         {
            StartCoroutine(Wake_Up_Princess(0.2f));
         }
    }

    private IEnumerator Wake_Up_Princess(float seconds_to_wait)
    {
        yield return new WaitForSeconds(seconds_to_wait);
        princess_anim.SetBool("is_idle", false);
        sleep_sprite.SetActive(false);
    }
}
