using UnityEngine;
using System.Collections;

public class EnemyFollow : MonoBehaviour
{
    // Declaration of private reference variables
    private CharacterController characterController;
    private PlayerController playerController;
    private Transform playerTransform;
    private AnimationClip enemyRun;
    //private AnimationClip enemyIdle;
    private AnimationClip enemyAttack;
    private Animation enemyAnimation;
    private EnemyController enemyController;
    private TakeDamage takeDamage;
    private bool impacted;

    // Declaration of private misc variables

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Declaration of public static variables
    public static bool attackPlaying;

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        characterController =  GetComponent<CharacterController>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        enemyController = GetComponent<EnemyController>();
        takeDamage = GameObject.FindGameObjectWithTag("CombatController").GetComponent<TakeDamage>();
        enemyAnimation = GetComponent<Animation>();
        enemyRun = enemyController.enemyRun;
        //enemyIdle = enemyController.idle;
        enemyAttack = enemyController.enemyAttack;
    }
   
	// Update is called once per frame
	void Update ()
    {
        if (!enemyAnimation.IsPlaying(enemyAttack.name))
        {
            attackPlaying = false;
            impacted = false;
        }
        if(!InRange() && !GetComponent<EnemyController>().dead)
        {
            Chase();
        }
        else
        {
            if(!enemyController.dead)
            {
                //GetComponent<Animation>().CrossFade(idle.name);
                Attack();
            }

            if (!impacted && !enemyController.dead)
            {
                impacted = true;
                StartCoroutine("AnimationWait");
            }
        }
	}

    private bool InRange()
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

    private void Chase()
    {
        transform.LookAt(playerTransform.position);
        characterController.SimpleMove(transform.forward * EnemyController.speed);
        GetComponent<Animation>().CrossFade(enemyRun.name);
    }

    private void Attack()
    {
        if (!playerController.dead)
        {
            GetComponent<Animation>().CrossFade(enemyAttack.name);
            attackPlaying = true;
        }
    }

    private IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(0.36f);
        takeDamage.PlayerHit(GetComponent<EnemyController>().damage, 1);
    }
}