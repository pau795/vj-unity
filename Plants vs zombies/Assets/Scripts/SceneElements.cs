using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneElements : MonoBehaviour
{
    public int sunSpawnChance;
    public GameObject mower;
    public GameObject fence;
    public GameObject sun;

    public GameObject standardZombie;
    public GameObject bucketZombie;

    public static int sunCount;
    public static bool change = false;

    public Text sunScore;

    // Start is called before the first frame update
    void Start()
    {
        updateSunScore();
        for (int i=0; i<5; ++i){
            Instantiate(mower, transform.position + new Vector3(-5, 0, i*5), mower.transform.rotation);
            Instantiate(standardZombie, transform.position + new Vector3(25, 0, i * 5), standardZombie.transform.rotation);
        }
        Instantiate(fence, transform.position + new Vector3(4.5f, 0.0f, 24.0f), fence.transform.rotation);
        InvokeRepeating("generateSuns", 1.0f, 1.0f);
        
    }
    
    public void updateSunScore()
    {
        sunScore.text = sunCount.ToString();
    }

    void generateSuns()
    {
        int randomNumber = Random.Range(0, 100/sunSpawnChance);
        if (randomNumber == 0)
        {
            int x = Random.Range(0, 20);
            int z = Random.Range(0, 20);
            Instantiate(sun, new Vector3(x, 25, z), sun.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (change) {
            updateSunScore();
            change = false;
        }
    }

    void zombieSpawn()
    {

    }
}
