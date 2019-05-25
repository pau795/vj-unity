using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeaBehaviour : MonoBehaviour
{
    public GameObject bullet;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        /*Component[] a = GetComponents(typeof(Component));
        foreach (Component e in a) print(e.ToString());*/
    }

    // Update is called once per frame
    void Update()
    {
        int layermask = LayerMask.GetMask("Zombies");
        if (Physics.Raycast(transform.position + new Vector3(0, 3, 0), transform.right, 20, layermask))
        {
            //Debug.DrawRay(transform.position + new Vector3(0, 3, 0), transform.right * 20, Color.yellow);
            animator.SetFloat("rateOfFire", GetComponent<ObjectStats>().rateOfFire);
            animator.SetTrigger("attack");
        }
        //else { Debug.DrawRay(transform.position + new Vector3(0, 3, 0), transform.right * 25, Color.green);         
    }

    public void die()
    {

        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("dead");
    }

    void disappear()
    {
        Destroy(gameObject);
        GetComponent<ObjectStats>().tile.GetComponent<PlantSpawner>().used = false;
    }

    void shoot(){
        GameObject g = (GameObject) Instantiate(bullet, transform.position + new Vector3(1.0f, 2.2f, 0.0f), transform.rotation);
        g.GetComponent<ShotMovement>().attack = GetComponent<ObjectStats>().attack;
        SoundManager.PlaySound("pop");
    }
   

}
