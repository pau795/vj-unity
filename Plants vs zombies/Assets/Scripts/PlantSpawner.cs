using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSpawner : MonoBehaviour
{
    public bool ready;
    public GameObject plant;
    public bool used;
    bool blocked;
    private Color color;
    public Vector3 positionOffset;   
    void OnMouseEnter() {
        if (ready){
            color = GetComponent<Renderer>().material.color;
            if (used || blocked) GetComponent<Renderer>().material.color = Color.red;
            else GetComponent<Renderer>().material.color = Color.green;
        }
    }
    void OnMouseExit(){
       if (ready) GetComponent<Renderer>().material.color = color;
    }
    void OnMouseDown(){
        if (!used && ready && !blocked){
            GameObject obj = (GameObject)Instantiate(plant, transform.position+positionOffset, plant.transform.rotation);
            obj.GetComponent<ObjectStats>().tile = gameObject;
            transform.parent.parent.gameObject.GetComponent<GardenFiller>().reset = true;
            GetComponent<Renderer>().material.color = color;
            used = true;
        }
    }

    // Start is called before the first frame update
    void Start() {
        used = false;
        ready = false;
        blocked = false;
        positionOffset = new Vector3(0, 0, 0);
    }

    private int getRow()
    {
        string s = transform.parent.gameObject.name;
        char r = s[s.Length - 1];
        return r - '0';
    }
    private int getColumn()
    {
        char r = name[name.Length - 1];
        return r - '0';
    }


    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position - new Vector3(2.5f, -3.0f,0.0f), transform.right, 5)){
            blocked = true;
        }
        else
        {
            blocked = false;
        }
    }
}
