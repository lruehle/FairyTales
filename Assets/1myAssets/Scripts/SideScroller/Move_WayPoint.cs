using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_WayPoint : MonoBehaviour
{
    public GameObject[] waypoints;
    [SerializeField] private float speed = 2f;
    private Transform current_position;
    private int wp_index = 0;
    
    void Start()
    {
        current_position = waypoints[1].transform;
    }
   
    void Update()
    { // distance between agent/plattform etc and waypoint
        Vector2 point = current_position.position - transform.position;
        if (Vector2.Distance(waypoints[wp_index].transform.position,transform.position) < 0.25f)
        {
            wp_index ++;
            if(wp_index >= waypoints.Length)wp_index = 0;
        }
        transform.position= Vector2.MoveTowards(transform.position, waypoints[wp_index].transform.position, Time.deltaTime * speed);
    }

    /*
    private void Draw_patrol()
    {
        Gizmos.DrawWireSphere(waypoints[0].transform.position, 0.5f);
        Gizmos.DrawWireSphere(waypoints[1].transform.position, 0.5f);
        Gizmos.DrawLine(waypoints[0].transform.position, waypoints[1].transform.position);
    }*/
    
}
