using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFlowerBehaviour : MonoBehaviour
{
    public float productionTime;
    public GameObject sun;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        changeProduction();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void changeProduction()
    {
        CancelInvoke();
        InvokeRepeating("generateSuns", productionTime, productionTime);
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

    void generateSuns()
    {
            int x = Random.Range(0, 6)-3;
            int z = Random.Range(0, 6)-3;
            Instantiate(sun, transform.position + new Vector3(x, 5.0f, z), sun.transform.rotation);
    }
}
