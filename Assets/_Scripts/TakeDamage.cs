using UnityEngine;
using System.Collections;

public class TakeDamage : MonoBehaviour 
{
    // Declaration of private reference variables
    private PlayerController playerController;

    // Declaration of private misc variables

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Declaration of public static variables

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    public void PlayerHit(int damage, int damageModifier)
    {
        playerController.health -= damage * damageModifier;
    }

    public void EnemyHit(int damage, int damageModifier)
    {
        PlayerController.opponent.GetComponent<EnemyController>().health -= damage * damageModifier;
    }
}
