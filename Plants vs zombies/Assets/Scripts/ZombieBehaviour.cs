using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    enum ZombieStates
    {
        IDLE, MOVE, ATTACK, ATTACKING, DYING, DEATH
    };

    public float HP, speed, attack, rateOfFire;
    Animator animator;
    ZombieStates state;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        state = ZombieStates.MOVE;
        
        animator.SetTrigger("move");
        animator.SetFloat("speed", speed);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == ZombieStates.MOVE)
        {
            transform.position = transform.position + new Vector3(-speed*Time.deltaTime, 0.0f, 0.0f);
        }
        if (state == ZombieStates.ATTACK)
        {           
            int randomNumber = Random.Range(1, 3);

            animator.SetTrigger("attack" + randomNumber);
            animator.SetFloat("rateOfFire", rateOfFire);
            state = ZombieStates.ATTACKING;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if ( state != ZombieStates.ATTACK && state != ZombieStates.ATTACKING && other.gameObject.tag == "Plant")
        {
            state = ZombieStates.ATTACK;
        }
    }

    void onAttackFisnish()
    {
        state = ZombieStates.ATTACK;
    }
}
