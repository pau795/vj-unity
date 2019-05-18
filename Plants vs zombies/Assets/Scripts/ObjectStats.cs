using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public float maxHP, HP, attack, speed, rateOfFire;
    public GameObject tile;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        dead = false;
    }



    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !dead)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().SetTrigger("dead");
            dead = true;
        }
    }
}
