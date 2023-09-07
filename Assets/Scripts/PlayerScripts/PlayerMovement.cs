using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 movement;
    [SerializeField] private CharacterController characterController;
    
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private float rotationSpeed = 0.1f;
    private float turnSmoothVelocity;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float horizontal_X = Input.GetAxisRaw("Horizontal");
        float vertical_Z = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontal_X, 0, vertical_Z).normalized;

        if(movement.magnitude >= 0.1f)
        {
            float characterAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterAngle, ref turnSmoothVelocity, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(movement * movementSpeed * Time.deltaTime); 
        }
    }
   
}
