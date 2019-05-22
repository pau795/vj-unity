using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChomperDamage : MonoBehaviour
{
    public float attack;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("die");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator die()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            other.gameObject.GetComponent<ObjectStats>().HP -= attack;
        }
    }
}
