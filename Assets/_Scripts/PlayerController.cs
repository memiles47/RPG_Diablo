using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Declaration of private reference variables
    private Death playerDead;

    // Declaration of private misc variables
    private int maxHealth;

    // Declaration of public reference variables
    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip attack;
    public AnimationClip death;

    // Declaration of public misc variables
    public int health;
    public int damage;

    // Declaration of public static variables
    public float speed;
    public static GameObject opponent;
    public static float range;
    public bool dead;

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        playerDead = GameObject.FindGameObjectWithTag("CombatController").GetComponent<Death>();
        speed = 7.0f;
        maxHealth = 500;
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
            playerDead.PlayerDeath();
        }
	}
}
