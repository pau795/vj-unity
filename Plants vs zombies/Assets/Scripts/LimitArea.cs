using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitArea : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            SceneElements.zombieOut();
        }
    }
}
