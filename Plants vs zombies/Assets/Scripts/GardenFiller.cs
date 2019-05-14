using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenFiller : MonoBehaviour
{
    public bool reset;
    public GameObject peaShooter;
    public GameObject sunFlower;
    public GameObject snowPea;
    public GameObject potatoMine;
    public GameObject chomper;
    // Start is called before the first frame update
    void Start()
    {
        reset = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (reset)
        {

            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = false;
                }
            }
            reset = false;
        }

    }

    public void selectPeaShooter()
    {
        for (int i=0;i < transform.childCount; ++i) {
            Transform row = transform.GetChild(i);
            for (int j = 0; j < row.childCount; ++j) {
                GameObject tile = row.GetChild(j).gameObject;
                tile.GetComponent<PlantSpawner>().ready = true;
                tile.GetComponent<PlantSpawner>().plant = peaShooter;
                Vector3 v = new Vector3(0, 0, 0);
                tile.GetComponent<PlantSpawner>().positionOffset = v;
            }
        }

    }

    public void selectPotatoMine()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform row = transform.GetChild(i);
            for (int j = 0; j < row.childCount; ++j)
            {
                GameObject tile = row.GetChild(j).gameObject;
                tile.GetComponent<PlantSpawner>().ready = true;
                tile.GetComponent<PlantSpawner>().plant = potatoMine;
                Vector3 v = new Vector3(0, 0, 3);
                tile.GetComponent<PlantSpawner>().positionOffset = v;
            }
        }
    }

    public void selectChomper()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform row = transform.GetChild(i);
            for (int j = 0; j < row.childCount; ++j)
            {
                GameObject tile = row.GetChild(j).gameObject;
                tile.GetComponent<PlantSpawner>().ready = true;
                tile.GetComponent<PlantSpawner>().plant = chomper;
                Vector3 v = new Vector3(-2.0f, 0.0f, -0.5f);
                tile.GetComponent<PlantSpawner>().positionOffset = v;
            }
        }

    }

    public void selectSnowPea()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            Transform row = transform.GetChild(i);
            for (int j = 0; j < row.childCount; ++j)
            {
                GameObject tile = row.GetChild(j).gameObject;
                tile.GetComponent<PlantSpawner>().ready = true;
                tile.GetComponent<PlantSpawner>().plant = snowPea;
                Vector3 v = new Vector3(0, 0, 0);
                tile.GetComponent<PlantSpawner>().positionOffset = v;
            }
        }

    }

    public void selectSunflower()
    {
        for (int i = 0; i < transform.childCount; ++i) {
            Transform row = transform.GetChild(i);
            for (int j = 0; j < row.childCount; ++j) {
                GameObject tile = row.GetChild(j).gameObject;
                tile.GetComponent<PlantSpawner>().ready = true;
                tile.GetComponent<PlantSpawner>().plant = sunFlower;
                Vector3 v= new Vector3(-1.5f, 0, -1.5f);                    
                tile.GetComponent<PlantSpawner>().positionOffset = v;
            }
        }
    }
}
