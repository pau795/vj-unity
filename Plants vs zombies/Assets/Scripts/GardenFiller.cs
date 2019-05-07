using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GardenFiller : MonoBehaviour
{
    public bool reset;
    public GameObject peaShooter;
    public GameObject sunFlower;
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
            }
        }
    }
}
