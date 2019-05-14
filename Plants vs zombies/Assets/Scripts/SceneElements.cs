using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElements : MonoBehaviour
{
    public GameObject mower;
    public GameObject fence;
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0; i<5; ++i){
            Instantiate(mower, transform.position + new Vector3(-5, 0, i*5), mower.transform.rotation);
        }
        Instantiate(fence, transform.position + new Vector3(4.5f, 0.0f, 24.0f), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
