using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    // Declaration of private reference variables
    private Death opponentDead;

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
    public float range;

    // Declaration of public static variables
    public static float speed = 5.0f;
    public static bool dead;
    public static bool dying;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        opponentDead = GameObject.FindGameObjectWithTag("CombatController").GetComponent<Death>();
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
            opponentDead.OpponentDeath();
            dead = true;
            Destroy(gameObject, 4.0f);
        }
	}

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider
    public void OnMouseOver()
    {
        PlayerController.opponent = gameObject;
    }
}