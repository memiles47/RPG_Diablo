using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    // Declaration of private reference variables
    private GameObject player;
    private PlayerController playerController;
    private Transform playerTransform;
    private Animation playerAnimation;
    private TakeDamage takeDamage;
    private AnimationClip attack;
    private bool impacted;

    // Declaration of private misc variables
    private float rangeModifier;

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Declaration of public static variables
    public static bool attackPlaying;

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<PlayerController>();
        playerTransform = player.GetComponent<Transform>();
        playerAnimation = player.GetComponent<Animation>();
        attack = playerController.attack;
        takeDamage = GameObject.FindGameObjectWithTag("CombatController").GetComponent<TakeDamage>();
        attackPlaying = false;
        rangeModifier = 5.0f;
        impacted = false;
    }

	// Update is called once per frame
	void Update ()
    {
        if(!playerAnimation.IsPlaying(attack.name))
        {
            attackPlaying = false;
            impacted = false;
        }
	}

    public void Attack()
    {
        if (PlayerController.opponent != null && InRange(PlayerController.range * rangeModifier))
        {
            playerTransform.LookAt(PlayerController.opponent.transform);

            if (InRange(PlayerController.range))
            {
                playerAnimation.CrossFade(attack.name);
                attackPlaying = true;
            }
            else
            {
                return;
            }

            if(!impacted)
            {
                impacted = true;
                StartCoroutine("AnimationWait");
            }
        }
    }

    public bool InRange(float range)
    {
        if(Vector3.Distance(playerController.transform.position, PlayerController.opponent.transform.position) <= range)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public IEnumerator AnimationWait()
    {
        yield return new WaitForSeconds(0.36f);
        takeDamage.EnemyHit(playerController.damage, 1);
    }
}
