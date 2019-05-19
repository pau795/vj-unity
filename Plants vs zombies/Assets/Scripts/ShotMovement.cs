using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public float speedPenalty;
    public float speed;
    public float attack;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0.0f, 0.0f);   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie") {
            other.gameObject.GetComponent<ObjectStats>().HP -= attack;
            if(gameObject.tag == "SnowPea") other.gameObject.GetComponent<ObjectStats>().speed *= speedPenalty;
            Destroy(gameObject);
        }
    }
}
