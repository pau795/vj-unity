﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public bool ready;
    public GameObject plant;
    private bool used;
    private Color color;
    void OnMouseEnter() {
        if (ready){
            color = GetComponent<Renderer>().material.color;
            if (!used) GetComponent<Renderer>().material.color = Color.green;
            else GetComponent<Renderer>().material.color = Color.red;
        }
    }
    void OnMouseExit(){
       if (ready) GetComponent<Renderer>().material.color = color;
    }
    void OnMouseDown(){
        if (!used && ready){
            GameObject obj = (GameObject)Instantiate(plant, transform.position, transform.rotation);
            transform.parent.parent.gameObject.GetComponent<GardenFiller>().reset = true;
            GetComponent<Renderer>().material.color = color;
            used = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        used = false;
        ready = false;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
