using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
public class MovePlayer : MonoBehaviour
{

    private CharacterController controller;

    public float speed = 1.0F;
    public float jumpSpeed = 1.0F;
    public float gravity = 1.0F;
    public float groundSpeed;
    public float midairSpeed;
    public Joystick joystick;
   
    private float horizontalFloat;
    private bool jump = false;
    public Maneger maneger;

    private Vector3 jumpVelocity = Vector3.zero;
    void Update()
    {
        CharacterController controller = GetComponent<CharacterController>();

        if (maneger.joystickmode)
        {
            horizontalFloat = joystick.Horizontal;
        }
        else
        {
            horizontalFloat = Input.GetAxis("Horizontal");
        }



        Vector3 moveDirection = new Vector3(horizontalFloat, 0, 0);
        
        
           
        

        moveDirection = transform.TransformDirection(moveDirection);
        if (controller.isGrounded)
        {
            moveDirection *= groundSpeed;
            if (jump|| Input.GetKeyDown(KeyCode.Space))
            {
                
                jumpVelocity = moveDirection;
                jumpVelocity.y = jumpSpeed;
                jump = false;
            }
            else
            {
                jumpVelocity = Vector3.zero;
            }
        }
        else
        {
            moveDirection *= midairSpeed;
            jumpVelocity.y -= gravity * Time.deltaTime;
        }
        controller.Move((moveDirection + jumpVelocity) * Time.deltaTime);
       
    }
    public void Jump()
    {
        
            jump = true;
        
            
    }
}