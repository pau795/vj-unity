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

    public TextAsset levelData;

    Level level;

    public class Level
    {
        public int numRounds;
        Round[] rounds;

        public Round getRound(int i) { return rounds[i]; }
        public void setNumRounds(int n)
        {
            numRounds = n;
            rounds = new Round[n];
        }

        public void setRound (int i, Round r) { rounds[i] = r; }
    }

    public class Round
    {
        public int difEnemies;
        int[] numEnemies;
        int[] enemyType;
        public int enemyAmount(int i) {return numEnemies[i];}
        public int enemyKind(int i) {return enemyType[i];}
        public void setDifEnemies(int n)
        {
            difEnemies = n;
            numEnemies = new int[n];
            enemyType = new int[n];
        }
        public void setEnemy(int i, int amount, int kind)
        {
            numEnemies[i] = amount;
            enemyType[i] = kind;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        updateSunScore();
        for (int i=0; i<5; ++i){
            Instantiate(mower, transform.position + new Vector3(-5, 0, i*5), mower.transform.rotation);
            Instantiate(standardZombie, transform.position + new Vector3(25.0f, -0.15f, (float)(i * 5)), standardZombie.transform.rotation);
        }
        Instantiate(fence, transform.position + new Vector3(4.5f, 0.0f, 24.0f), fence.transform.rotation);
        InvokeRepeating("generateSuns", 1.0f, 1.0f);
        //loadLevel(0);
        //zombieSpawn();
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

    void loadLevel(int lvl)
    {
        level = new Level();
        string[] lines = levelData.text.Split('\n');
        for (int i1 = 0; i1< lines.Length; ++i1)
        {
            if (i1 == lvl)
            {
                string l = lines[i1];
                string[] rounds = l.Split(',');
                level.setNumRounds(rounds.Length);
                for (int i = 0; i < rounds.Length; ++i)
                {
                    string s = rounds[i];
                    s = s.Substring(1, s.Length - 1);
                    Round r = new Round();
                    string[] p = s.Split(' ');
                    r.setDifEnemies(p.Length);
                    for (int j = 0; j < p.Length; ++j)
                    {
                        string z = p[j];
                        string[] values = z.Split('-');
                        r.setEnemy(j, int.Parse(values[0]), int.Parse(values[1]));
                    }
                    level.setRound(i, r);
                }
            }
        }

    }

    void zombieSpawn()
    {
        int n = level.numRounds;
        for (int i = 0; i < n; ++i)
        {
            Round r = level.getRound(i);
            int k = r.difEnemies;
            for (int j = 0; j < k; ++j)
            {
                int num = r.enemyAmount(j);
                int type = r.enemyKind(j);
                string s = string.Concat(num.ToString(), type.ToString());
                print(s);
            }
        }
    }
}
