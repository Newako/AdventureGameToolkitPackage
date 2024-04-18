using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
public class GoalScript : MonoBehaviour
{
    [SerializeField] GameObject key;
    [SerializeField] CinemachineVirtualCamera puzzleCam;
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;
    [SerializeField] GameObject door;

    public UnityEvent onUnlock;

    public void UnlockEventTriggered()
    {
        onUnlock.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == key)
        {
            UnlockEventTriggered();
        }
    }

    public void TestUnlock()
    {
        Debug.Log("GOAL!");
        puzzleCam.m_Priority = 0;
        door.transform.position += new Vector3(0, 4, 0);

        movementControl.action.Enable();
        jumpControl.action.Enable();

        GameObject physicsMaze = GameObject.Find("Maze");
        physicsMaze.GetComponent<MazeController>().enabled = false;
    }
}