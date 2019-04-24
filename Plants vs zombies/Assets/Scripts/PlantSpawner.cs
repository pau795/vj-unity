using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public GameObject plant;
    private bool used;
    private Color color;
    void OnMouseEnter()
    {
        color = GetComponent<Renderer>().material.color;
        if (!used) GetComponent<Renderer>().material.color = Color.green;
        else GetComponent<Renderer>().material.color = Color.red;
    }
    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = color;
    }
    void OnMouseDown()
    {
        if (!used)
        {
            GameObject obj = (GameObject)Instantiate(plant, transform.position, transform.rotation);
            GetComponent<Renderer>().material.color = Color.red;
            used = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        used = false;

    }

    // Update is called once per frame
    void Update()
    {
    }
}
