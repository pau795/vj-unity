using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnMouseDown()
    {
        SceneElements.sunCount += 10;
        SceneElements.change = true;
        Destroy(gameObject);

    }
}
