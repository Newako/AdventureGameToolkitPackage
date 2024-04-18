using UnityEngine;
using UnityEngine.InputSystem;

//automatically assigns charactercontroller when script is assigned
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //reference variables
    [SerializeField]
    private InputActionReference movementControl;
    [SerializeField] 
    private InputActionReference jumpControl;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    [SerializeField]
    private float rotationSpeed = 4f;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private Transform cameraMainTransform;

    //Function is called when the object becomes enabled and active
    private void OnEnable()
    {
        movementControl.action.Enable(); //Enables movement controls
        jumpControl.action.Enable(); //Enables jump controls
    }

    //Function is called when the object becomes disabled and inactive
    private void OnDisable()
    {
        movementControl.action.Disable(); //Disables movement controls
        jumpControl.action.Disable(); //Disables jump controls
    }

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        cameraMainTransform = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; //Cursor visibiltiy is false, so that cursor only shows up during certain events.
    }

    void Update()
    {
        //Checks if player is grounded, if is grounded then sets velocity to 0
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = movementControl.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = cameraMainTransform.forward * move.z + cameraMainTransform.right * move.x; //Handles camera direction
        move.y = 0f;
        controller.Move(move * Time.deltaTime * playerSpeed);


        //Changes the height position of the player, in otherwords handles the jumping
        if (jumpControl.action.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        //Handles gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //Handles character rotation
        if (movement != Vector2.zero)
        {
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cameraMainTransform.eulerAngles.y;
            Quaternion rotation = Quaternion.Euler(0f, targetAngle, 0f);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }

    }
}