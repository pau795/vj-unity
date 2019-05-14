using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantAttack : MonoBehaviour
{
    public GameObject bullet;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            animator.SetTrigger("attack");
        }
        
    }

    void shoot(){
       Instantiate(bullet, transform.position + new Vector3(1.0f, 2.2f, 0.0f), transform.rotation);
    }
   

}
