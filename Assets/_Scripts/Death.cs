using UnityEngine;
using System.Collections;

public class Death : MonoBehaviour 
{
    // Declaration of private reference variables
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
        //opponentAnimation = PlayerController.opponent.GetComponent<Animation>();
        playerAnimation = GameObject.FindGameObjectWithTag("Player").GetComponent<Animation>();
        //opponentDeath = PlayerController.opponent.GetComponent<EnemyController>().death;
        playerDeath = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().death;
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
        playerAnimation.Play(playerDeath.name);
    }

    public void OpponentDeath()
    {
        PlayerController.opponent.GetComponent<Animation>().Play(PlayerController.opponent.GetComponent<EnemyController>().death.name);
    }
}
