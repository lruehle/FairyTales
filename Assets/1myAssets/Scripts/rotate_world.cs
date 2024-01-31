using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate_world : MonoBehaviour
{
    /*CircleCollider2D circle_collider;
    //public int angle;//also direction -/+
    float angle = 0f;
    float rotation_radius = 2f, speed = 50f;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        //circle_collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //float radius = circle_collider.radius;
        if(Input.GetKey(KeyCode.T)){
            this.transform.Rotate(Vector3.forward, speed *Time.deltaTime);
            /*float new_x= transform.position.x + Mathf.Cos(angle) * rotation_radius;
            float new_y= transform.position.y + Mathf.Sin(angle) * rotation_radius;
            transform.position = new Vector2(new_x, new_y); 
            angle = angle + Time.deltaTime * speed;*/
/*        }
        if(Input.GetKey(KeyCode.Z)){
            this.transform.Rotate(Vector3.forward, -speed * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.L)){
            var rot = transform.rotation;
            transform.RotateAround(target.transform.position, Vector3.forward, 20 * Time.deltaTime);
            transform.rotation = rot;
        }
        //if(angle >360f) angle =0f;

    }*/

}
