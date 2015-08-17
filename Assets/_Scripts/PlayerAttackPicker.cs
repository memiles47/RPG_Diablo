using UnityEngine;
using System.Collections;

public class PlayerAttackPicker : MonoBehaviour
{
    // Declaration of private reference variables
    private PlayerAttack playerAttack;

    // Declaration of private misc variables

    // Declaration of public reference variables

    // Declaration of public misc variables

    // Declaration of public static variables
    public static bool specialAttack;

    // Use this for initialization of reference variables that do not change during game play
    void Awake()
    {
        playerAttack = GameObject.FindGameObjectWithTag("CombatController").GetComponent<PlayerAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerController.dead) PickAttack();
    }

    public void PickAttack()
    {
        if (Input.GetKey(KeyCode.Space)) playerAttack.Attack();

        if (Input.GetKey(KeyCode.Alpha1)) Debug.Log("You tried a double damage attack");

        if (Input.GetKey(KeyCode.Alpha2)) Debug.Log("You tried to stun the opponent");

        if (Input.GetKey(KeyCode.Alpha3)) Debug.Log("You tried to throw a projectile");
    }
}