using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot_at_mouse : MonoBehaviour
{
    public Vector3 mouse_pos;
    public Transform target;
    public Vector3 object_pos;
    public float angle;
 
 void Update()
    {
        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23F; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(target.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
