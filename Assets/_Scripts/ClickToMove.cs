using UnityEngine;
using System.Collections;

public class ClickToMove : MonoBehaviour
{
    // Declaration of private reference variables
    private CharacterController characterController;
    private GameObject gameController;
    private Vector3 clickedPosition;
    private LocateMouse locateMouse;
    private AnimationClip playerRun;
    private AnimationClip playerIdle;
    private PlayerController playerController;

    // Declaration of public reference variables
	
    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        gameController = GameObject.FindGameObjectWithTag("GameController");
        clickedPosition = transform.position;
        locateMouse = gameController.GetComponent<LocateMouse>();
        playerController = GetComponent<PlayerController>();
        playerRun = playerController.playerRun;
        playerIdle = playerController.playerIdle;
    }
    
	// Update is called once per frame
	void Update ()
    {
        if (!PlayerAttack.attackPlaying && !playerController.dead)
        {
            if (Input.GetMouseButton(0))
            {
                // Locate clicked position
                clickedPosition = locateMouse.LocatePosition();
                RotateToClickedPosition(); // Rotate toward the clicked position
            }

            // GameObject is running
            if (Vector3.Distance(clickedPosition, transform.position) > 0.50f)
            {
                MoveToClickedPosition(); // Move toward the clicked position
                GetComponent<Animation>().CrossFade(playerRun.name);
            }
            // GameObject is not running
            else
            {
                if (!playerController.dead)
                {
                	GetComponent<Animation>().CrossFade(playerIdle.name);
                }
            }
        }
	}

    void RotateToClickedPosition()
    {
        // Obtain new rotation based on the clicked position
        Quaternion newRotation = Quaternion.LookRotation(clickedPosition - transform.position);

        // Disable rotation on x and z axis
        newRotation.x = 0;
        newRotation.z = 0;

        // Rotate smoothly to the new rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 100);
    }

    void MoveToClickedPosition()
    {
        // Using the character controller and simple move, move to the clicked position.
        characterController.SimpleMove(transform.forward * playerController.speed);
    }
}