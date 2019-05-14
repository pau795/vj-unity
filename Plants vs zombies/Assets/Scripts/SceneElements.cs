using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneElements : MonoBehaviour
{
    public abstract class Character
    {
        public int HP, attack, rateOfFire;
        public abstract bool shouldCollide();
    }

    public class Plant : Character
    {
        public override bool shouldCollide()
        {
            return true;
        }
    }

    public class Zombie : Character
    {
        public int speed;

        public override bool shouldCollide()
        {
            return false;
        }

    }


    public GameObject mower;
    public GameObject fence;

    public GameObject standardZombie;
    public GameObject bucketZombie;
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

    void zombieSpawn()
    {

    }
}
