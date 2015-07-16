using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    // Declaration of private reference variables
    //private PlayerController playerController;

    // Declaration of private misc variables
    private int maxHealth;

    // Declaration of public reference variables
    public AnimationClip enemyRun;
    public AnimationClip enemyIdle;
    public AnimationClip enemyAttack;
    public AnimationClip enemyDeath;

    // Declaration of public misc variables
    public int health;
    public int damage;
    public float range;

    // Declaration of public static variables
    public static float speed;
    public bool dead;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        speed = 5.0f;
        maxHealth = 100;
        health = maxHealth;
        damage = 25;
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
        if (health <= 0 && !dead)
        {
            health = 0;
            Death();
        }
	}

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider
    public void OnMouseOver()
    {
        PlayerController.opponent = gameObject;
    }

    private void Death()
    {
        if (PlayerController.opponent != null)
        {
            GetComponent<Animation>().Play(GetComponent<EnemyController>().enemyDeath.name);
            GetComponent<EnemyController>().dead = true;
            Destroy(PlayerController.opponent, 4.0f);
        }
        else
        {
            return;
        }
    }
}