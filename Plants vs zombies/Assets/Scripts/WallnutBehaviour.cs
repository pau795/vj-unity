using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallnutBehaviour : MonoBehaviour
{
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
}
