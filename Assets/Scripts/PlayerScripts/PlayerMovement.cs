using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    [SerializeField] private PlayerInputManager playerInputManager;

    private float turnSmoothVelocity;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        playerInputManager = GetComponent<PlayerInputManager>();
    }

    public void Movement(float playerSpeed, float rotationSpeed)
    {
        var moveDirection = new Vector3(playerInputManager.HozirontalXInput(), 0, playerInputManager.VerticalYInput()).normalized;
        if (moveDirection.magnitude >= 0.1f)
        {
            float characterAngle = Mathf.Atan2(moveDirection.x, moveDirection.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, characterAngle, ref turnSmoothVelocity, rotationSpeed);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(moveDirection * playerSpeed * Time.deltaTime); 
        }
    }
}
