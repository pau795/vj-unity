using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoMineBehaviour : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void die()
    {
        Destroy(gameObject);
        GetComponent<ObjectStats>().tile.GetComponent<PlantSpawner>().used = false;
    }

    IEnumerator die1()
    {
        yield return new WaitForSeconds(0.5f);
        die();
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 11)
        {
            Instantiate(explosion, transform.position + new Vector3(0.0f,0.0f,-3.0f), explosion.transform.rotation);
            StartCoroutine("die1");
        }
    }
}
