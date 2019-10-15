using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private string horizontalInputName;
    [SerializeField] private KeyCode JumpButton;
    [SerializeField] private float jumpForce;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpMultiplier;
     private float horizontalFloat;
    [SerializeField] private bool isground = true;
    [SerializeField] private bool joysickmode;
    [SerializeField] private Joystick joystick;
    private CharacterController charController;
    [SerializeField] private AnimationCurve jumpFallOff;
    // Start is called before the first frame update
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }
    private void MovePlayer()
    {
        if (joysickmode)
        {
            horizontalFloat = joystick.Horizontal;
        }
        else
        {
            horizontalFloat = Input.GetAxis(horizontalInputName);
        }
        
        Vector3 rightMovement = transform.right * horizontalFloat;
        charController.Move(Vector3.ClampMagnitude(rightMovement, 1.0f) * movementSpeed);

        if (Input.GetKeyDown(JumpButton) && isground)
        {
            StartCoroutine(JumpEvent());
            isground = false;
        }
    }
    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);
            isground = true;
        charController.slopeLimit = 45.0f;

    }
    public void Jump()
    {
        if(isground)
            StartCoroutine(JumpEvent());
    }
    
}
