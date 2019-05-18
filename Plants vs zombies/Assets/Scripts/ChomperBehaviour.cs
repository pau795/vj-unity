using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperBehaviour : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

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
}
