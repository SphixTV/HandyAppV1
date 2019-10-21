using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Moving : MonoBehaviour
{



    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public float jumpCount = 0.0f;
    float maxJump = 2.0f;
    public bool WallJump = false;
    
    public Maneger maneger;
    public Joystick joystick;
    private float Horizontal;
    private float Vertical;
    private Vector3 moveDirection = Vector3.zero;
    private Animator Animator;
    [SerializeField] private bool hasVertical;
    public bool NoMove;
    float rotation;
    private void Start()
    {
        
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        moveDirection.y -= gravity * Time.deltaTime;
    }
    void Update()
    {

        CharacterController controller = GetComponent<CharacterController>();

        controller.Move(moveDirection * Time.deltaTime);

        
       
        if (maneger.joystickmode)
        {
            Horizontal = joystick.Horizontal;
        }
        else
        {
            Horizontal = Input.GetAxis("Horizontal");
        }
        if (hasVertical)
        {
            if (maneger.joystickmode)
            {
                Vertical = joystick.Vertical;
            }
            else
            {
                Vertical = Input.GetAxis("Vertical");
            }
            
        }
        else
        {
            Vertical = 0;
        }
        if (!controller.isGrounded)
        {

            moveDirection.x = Horizontal * speed;
        }
        //if (NoMove)
        //{
        //    Horizontal = 0;
        //}
        
        else
        {
            moveDirection = new Vector3(Horizontal * speed, 0.0f, Vertical * speed) ;

            jumpCount = 0.0f;
            WallJump = false;

        }
        if (Horizontal > 0)
        {
            transform.eulerAngles = new Vector3(0, 90, 0); // Normal
            rotation = 90;

        }
        else if (Horizontal < 0)
        {
            transform.eulerAngles = new Vector3(0, -90, 0);
            rotation = -90;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, rotation, 0);
        }
        if(Horizontal < 0)
        {
            Animator.SetFloat("walk", Horizontal * -1);
        }
        else
        {
            Animator.SetFloat("walk", Horizontal);
        }


        if (jumpCount < maxJump)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }
            }
        
        

        if (controller.collisionFlags == CollisionFlags.Sides && maneger.doublejump && WallJump == false)
        {
            WallJump = true;
            jumpCount = 0.0f;
        }
    }
    void Flip()
    {
        
    }
    public void Jump()
    {
        
            
                moveDirection.y = jumpSpeed;
        if (maneger.doublejump)
        {
            jumpCount++;
        }
        else
        {
            jumpCount = maxJump;
        }
                
            
        
    }
    public void JumpTrigger()
    {
        if (jumpCount < maxJump)
        {

            Jump();

        }
    }

}