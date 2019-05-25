using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GardenFiller : MonoBehaviour
{
    public bool reset;

    public GameObject peaShooter, sunFlower, snowPea, potatoMine, chomper, wallNut;

    public int sunFlowerCost, peaShooterCost, snowPeaCost, potatoMineCost,chomperCost, wallNutCost;

    public Text sunFlowerCostText, peaShooterCostText, snowPeaCostText, potatoMineCostText, chomperCostText, wallNutCostText;
    // Start is called before the first frame update
    void Start()
    {
        reset = false;
        sunFlowerCostText.text = sunFlowerCost.ToString();
        peaShooterCostText.text = peaShooterCost.ToString();
        snowPeaCostText.text = snowPeaCost.ToString();
        potatoMineCostText.text = potatoMineCost.ToString();
        chomperCostText.text = chomperCost.ToString();
        wallNutCostText.text = wallNutCost.ToString();

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
        if (SceneElements.sunCount >= peaShooterCost)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = peaShooter;
                    tile.GetComponent<PlantSpawner>().sunCost = peaShooterCost;
                    Vector3 v = new Vector3(0, 0, 0);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }
        }
        else SoundManager.PlaySound("error");

    }

    public void selectPotatoMine()
    {
        if (SceneElements.sunCount >= potatoMineCost)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = potatoMine;
                    tile.GetComponent<PlantSpawner>().sunCost = potatoMineCost;
                    Vector3 v = new Vector3(0.0f, 0.5f, 3.0f);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }
        }
        else SoundManager.PlaySound("error");
    }

    public void selectChomper()
    {
        if (SceneElements.sunCount >= chomperCost)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = chomper;
                    tile.GetComponent<PlantSpawner>().sunCost = chomperCost;
                    Vector3 v = new Vector3(-2.0f, 0.0f, -0.5f);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }
        }
        else SoundManager.PlaySound("error");
    }

    public void selectWallNut()
    {
        if (SceneElements.sunCount >= wallNutCost)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = wallNut;
                    tile.GetComponent<PlantSpawner>().sunCost = wallNutCost;
                    Vector3 v = new Vector3(-1.0f, 0.0f, 0.5f);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }
        }
        else SoundManager.PlaySound("error");

    }

    public void selectSnowPea()
    {
        if (SceneElements.sunCount >= snowPeaCost) {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = snowPea;
                    tile.GetComponent<PlantSpawner>().sunCost = snowPeaCost;
                    Vector3 v = new Vector3(0, 0, 0);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }
        }
        else SoundManager.PlaySound("error");


    }

    public void selectSunflower()
    {
        if (SceneElements.sunCount >= sunFlowerCost)
        {
            for (int i = 0; i < transform.childCount; ++i)
            {
                Transform row = transform.GetChild(i);
                for (int j = 0; j < row.childCount; ++j)
                {
                    GameObject tile = row.GetChild(j).gameObject;
                    tile.GetComponent<PlantSpawner>().ready = true;
                    tile.GetComponent<PlantSpawner>().plant = sunFlower;
                    tile.GetComponent<PlantSpawner>().sunCost = sunFlowerCost;
                    Vector3 v = new Vector3(-1.5f, 0, -1.5f);
                    tile.GetComponent<PlantSpawner>().positionOffset = v;
                }
            }

        }
        else SoundManager.PlaySound("error");
    }
}
