using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PuzzleButton : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    [SerializeField] CinemachineVirtualCamera puzzleCam;
    [SerializeField] private InputActionReference movementControl;
    [SerializeField] private InputActionReference jumpControl;
    

    public string InteractionPrompt => _prompt;

    void Start()
    {
        puzzleCam.m_Priority = 0;

        GameObject physicsMaze = GameObject.Find("Maze");
        physicsMaze.GetComponent<MazeController>().enabled = false;
    }

    public bool Interact(Interactor interactor)
    {
        movementControl.action.Disable();
        jumpControl.action.Disable();

        GameObject physicsMaze = GameObject.Find("Maze");
        physicsMaze.GetComponent<MazeController>().enabled = true;

        puzzleCam.m_Priority = 100;
        return true;
    }
}

