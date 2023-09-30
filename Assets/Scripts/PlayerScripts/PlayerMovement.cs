using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    
    private float turnSmoothVelocity;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    public void Movement(float playerSpeed, float rotationSpeed, Vector3 playerPos)
    {
        if(playerPos.magnitude >= 0.1f)
        {
            float characterAngle = Mathf.Atan2(playerPos.x, playerPos.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterAngle, ref turnSmoothVelocity, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(playerPos * playerSpeed * Time.deltaTime); 
        }
    }
}
