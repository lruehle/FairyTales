using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{
    [SerializeField] private Transform player_Character;
    private Vector2 camera_offset = new Vector2(2.0f, 0.3f);
    
    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(player_Character.position.x - camera_offset.x, player_Character.position.y-camera_offset.y, transform.position.z);
    }
}
