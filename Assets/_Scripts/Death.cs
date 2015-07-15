using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour 
{
    // Declaration of private reference variables
    private PlayerController playerController;
    //private Animation opponentAnimation;
    private Animation playerAnimation;
    //private AnimationClip opponentDeath;
    private AnimationClip playerDeath;

    // Declaration of private misc variables

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Declaration of public static variables

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
        //playerDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().death;
        playerDeath = playerController.death;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlayerDeath()
    {
        Debug.Log("Made it this far: Death PlayerDeath()");
        playerAnimation.Play(playerDeath.name);
        playerController.dead = true;
    }

    public void OpponentDeath()
    {
        PlayerController.opponent.GetComponent<Animation>().Play(PlayerController.opponent.GetComponent<EnemyController>().death.name);
        EnemyController.dead = true;
        Destroy(PlayerController.opponent, 4.0f);
    }
}
