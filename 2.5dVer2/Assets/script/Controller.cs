using UnityEngine;
using UnityEngine.InputSystem;

public class Controller : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float speed=5f;
    [SerializeField] private float jumpHeight=2f;
    [SerializeField] private float oxygenCapacity = 1000000f;
    [SerializeField] private float oxygenConsumptionRate =1f;
    [SerializeField] private float oxygenJetConsumptionRate = 2;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private bool shouldFaceMoveDirection = false;
 

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");

    }
    public void OnJump
        (InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {controller.isGrounded}");
        if (context.performed)
        {
            Debug.Log("We are supposed to jump!");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        //oxygen consumption
        Debug.Log($"Oxygen Level: {oxygenCapacity}");
        if (oxygenCapacity >= 0)
        {
            oxygenCapacity -= oxygenConsumptionRate *Time.deltaTime;
        }
        else
        {
            Debug.Log($"Out of oxygen! You died");
        }
        if (oxygenCapacity>=0 && Input.GetKeyDown(KeyCode.Space))
        {
            oxygenCapacity -= oxygenJetConsumptionRate;
        }

        //player movement
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        controller.Move(moveDirection * speed * Time.deltaTime);

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

        Vector3 move = new Vector3(0, moveInput.y, 0);
        controller.Move(move *speed * Time.deltaTime);  

        //jump
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
