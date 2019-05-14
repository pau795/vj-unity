using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    public int HP, speed, attack, rateOfFire;
    public SceneElements.Zombie p;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        p.HP = HP;
        p.speed = speed;
        p.attack = attack;
        p.rateOfFire = rateOfFire;
        animator = GetComponent<Animator>();
        animator.SetTrigger("move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
