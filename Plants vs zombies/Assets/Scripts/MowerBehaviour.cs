using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerBehaviour : MonoBehaviour
{
    bool move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        move = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            transform.position = transform.position - (transform.forward * speed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            if (!move)
            {
                transform.position = transform.position + (transform.forward*2);
                move = true;
            }
            else
            {
                other.gameObject.GetComponent<ZombieBehaviour>().die();
            }
        }
    }
}
