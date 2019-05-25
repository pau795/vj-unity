using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperBehaviour : MonoBehaviour
{
    Animator animator;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int layermask = LayerMask.GetMask("Zombies");
        if (Physics.Raycast(transform.position + new Vector3(3, 3, 0), -transform.up, 3.5f, layermask))
        {
            //Debug.DrawRay(transform.position + new Vector3(3, 3, 0), -transform.up * 3.5f, Color.yellow);
            animator.SetFloat("rateOfFire", GetComponent<ObjectStats>().rateOfFire);
            animator.SetTrigger("attack");
        }
        //else { Debug.DrawRay(transform.position + new Vector3(3, 3, 0), -transform.up * 3.5f, Color.green); }
    }

    public void die()
    {

        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("dead");
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
        }
    }

    public void doDamage()
    {
        SoundManager.PlaySound("chomperAttack");
        GameObject g = (GameObject)Instantiate(bullet, transform.position + new Vector3(7f, 2.2f, 0.5f), transform.rotation);
        g.GetComponent<ChomperDamage>().attack = GetComponent<ObjectStats>().attack;
    }

    void disappear()
    {
        Destroy(gameObject);
        GetComponent<ObjectStats>().tile.GetComponent<PlantSpawner>().used = false;
    }
}
