using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    // Declaration of private reference variables

    // Declaration of private misc variables
    private int maxHealth;

    // Declaration of public reference variables
    public AnimationClip run;
    public AnimationClip idle;
    public AnimationClip attack;

    // Declaration of public misc variables
    public int health;
    public int damage;
    public float range;

    // Declaration of public static variables
    public static float speed = 5.0f;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        maxHealth = 100;
        health = maxHealth;
        damage = 25;
        range = 1.25f;
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (health < 0) health = 0;
	}

    // OnMouseOver is called every frame while the mouse is over the GUIElement or Collider
    public void OnMouseOver()
    {
        PlayerController.opponent = gameObject;
    }
}