using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    public float maxHP, HP, attack, speed, rateOfFire;
    public GameObject tile;

    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
            if (tag == "Plant") tile.GetComponent<PlantSpawner>().used=false;
        }
    }
}
