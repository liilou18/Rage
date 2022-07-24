
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

//create variables
//attackCooldown indicates how long after a first attack the player can attack again
[SerializeField] private float attackCooldown;
private Animator anim;
private PlayerMovement playerMovement;

// value is a big number to avoid that the game starts with cooldownTimer = 0 which would not let the player attack straight away
private float cooldownTimer = Mathf.Infinity;

//create methods
private void Awake()
{
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
}

private void Update()
{
    //cooldownTimer is bigger than the timethat has passed since the last shot
    //canAttack makes sure that the player is in a state from which an attack is possible
    if(Input.GetMouseButton(0) && cooldownTimer > attackCooldown)
        Attack();
    
    //incrementing it to every frame
    cooldownTimer += Time.deltaTime;
}

private void Attack()
{
    //set  up the animation for the attack
        anim.SetTrigger("attack");

    //when we attack, the cooldownTimer will be reset to zero
        cooldownTimer = 0;
}
}
