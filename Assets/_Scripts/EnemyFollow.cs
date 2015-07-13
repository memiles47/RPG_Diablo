using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    // Declaration of private reference variables
    private CharacterController characterController;
    private Transform playerTransform;
    private AnimationClip run;
    private AnimationClip idle;
    private EnemyController enemyController;

    // Declaration of private misc variables

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        characterController =  GetComponent<CharacterController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyController = GetComponent<EnemyController>();
        run = enemyController.run;
        idle = enemyController.idle;
    }
   
	// Update is called once per frame
	void Update ()
    {
        if (!InRange())
        {
            Chase();
        }
        else
        {
            GetComponent<Animation>().CrossFade(idle.name);
        }
	}

    bool InRange()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) < enemyController.range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Chase()
    {
        transform.LookAt(playerTransform.position);
        characterController.SimpleMove(transform.forward * EnemyController.speed);
        GetComponent<Animation>().CrossFade(run.name);
    }
}