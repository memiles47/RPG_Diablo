using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Declaration of private reference variables

    // Declaration of private misc variables
    private int maxHealth;


    // Declaration of public reference variables
    public AnimationClip playerRun;
    public AnimationClip playerIdle;
    public AnimationClip playerAttack;
    public AnimationClip playerDeath;

    // Declaration of public misc variables
    public int health;
    public int damage;
    public float speed;

    // Declaration of public static variables
    public static GameObject opponent;
    public static float range;
    public static bool dead;

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        speed = 7.0f;
        maxHealth = 100;
        health = maxHealth;
        damage = 50;
        range = 1.25f;
        dead = false;
        
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(health <= 0 && !dead)
        {
            health = 0;
            dead = true;
            Death();
        }
	}

    private void Death()
    {
        GetComponent<Animation>().Play(GetComponent<PlayerController>().playerDeath.name);
        PlayerController.dead = true;
    }
}
