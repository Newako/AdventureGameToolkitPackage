using UnityEngine;

public class MazeController : MonoBehaviour
{
    public float rotationSpeed = 15f;
    private float rotationLimit = 45f;
    private float currentXRotation = 0f;
    private float currentZRotation = 0f;

    public void Update()
    {
        // Keyboard input for maze rotation
        float xInput = Input.GetAxis("Vertical"); // Up and down
        float zInput = Input.GetAxis("Horizontal"); // Left and right

        // Calculate the new rotation angles
        currentXRotation += -xInput * rotationSpeed * Time.deltaTime;
        currentZRotation += -zInput * rotationSpeed * Time.deltaTime;

        // Clamp the rotation angles within limits
        currentXRotation = Mathf.Clamp(currentXRotation, -rotationLimit, rotationLimit);
        currentZRotation = Mathf.Clamp(currentZRotation, -rotationLimit, rotationLimit);

        // Apply the updated rotation
        transform.rotation = Quaternion.Euler(currentXRotation, 0f, currentZRotation);
    }
}
