using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SceneElements : MonoBehaviour
{
    public Text LevelText;
    public Text RoundText;
    public Slider levelProgress;

    public int sunSpawnChance;
    public GameObject mower;
    public GameObject fence;
    public GameObject sun;

    public GameObject standardZombie;
    public GameObject bucketZombie;
    public GameObject runnerZombie;

    public static int sunCount;
    public static bool change;

    static int zombiesOut;
    static int maxZombiesOut;

    public Text sunScore;
    public Text ZombOutText;
    public static bool zmbout;

    public GameObject winMenu, loseMenu;

    public TextAsset levelData;

    public int numLevel;
    public static int remainingZombies;
    public int actualRound;
    public float killed = 0;
    public static bool win;
    public static bool lose;

    Level level;

    public class Level
    {
        public int numLvl;
        public int numRounds;
        public float totalLevelZombies;
        Round[] rounds;

        public Round getRound(int i) { return rounds[i]; }
        public void setNumRounds(int n)
        {
            numRounds = n;
            rounds = new Round[n];
        }

        public void setRound(int i, Round r) { rounds[i] = r; }
    }

    public class Round
    {
        public int totalEnemies;
        public int difEnemies;
        int[] numEnemies;
        int[] enemyType;
        public int enemyAmount(int i) { return numEnemies[i]; }
        public int enemyKind(int i) { return enemyType[i]; }
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

    public static void zombieOut() {
        ++zombiesOut;
        zmbout = true;
        if (zombiesOut == maxZombiesOut) lose = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        numLevel = MainMenu.level-1;
        Time.timeScale = 1f;
        updateSunScore();
        for (int i = 0; i < 5; ++i)
        {
            Instantiate(mower, transform.position + new Vector3(-6.5f, 0f,(float) i * 5), mower.transform.rotation);
        }
        sunCount = 200;
        change = true;
        zombiesOut = 0;
        zmbout = false;
        maxZombiesOut = 5;
        lose = false;
        win = false;
        Instantiate(fence, transform.position + new Vector3(4.5f, 0.0f, 24.0f), fence.transform.rotation);
        Instantiate(fence, transform.position + new Vector3(-26.5f, 0.0f, 24.0f), fence.transform.rotation);
        Instantiate(fence, transform.position + new Vector3(34.5f, 0.0f, 24.0f), fence.transform.rotation);
        InvokeRepeating("generateSuns", 1.0f, 1.0f);
        loadLevel(numLevel);
        StartCoroutine("zombieSpawn");
    }

    public void updateSunScore()
    {
        sunScore.text = sunCount.ToString();
    }

    void generateSuns()
    {
        int randomNumber = Random.Range(0, 100 / sunSpawnChance);
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
        if (lose)
        {
            SoundManager.PlaySound("lose");
            lose = false;
            Time.timeScale = 0f;
            loseMenu.SetActive(true);
        }
        if (win)
        {
            SoundManager.PlaySound("win");
            win = false;
            Time.timeScale = 0f;
            winMenu.SetActive(true);
        }

        if (change)
        {
            updateSunScore();
            change = false;
        }
        if (zmbout)
        {
            ZombOutText.text = "Zombies Escapados : " + zombiesOut.ToString() + " / " + maxZombiesOut.ToString();
            zmbout = false;
        }
        LevelText.text = "Nivel:" + (level.numLvl).ToString();
        RoundText.text = "Ronda:" + (actualRound).ToString();
        levelProgress.value = killed / level.totalLevelZombies;
    }

    void loadLevel(int lvl)
    {
        level = new Level();
        level.numLvl = lvl + 1;
        string[] lines = levelData.text.Split('\n');
        for (int i1 = 0; i1 < lines.Length; ++i1)
        {
            if (i1 == lvl)
            {
                string l = lines[i1];
                string[] rounds = l.Split(',');
                level.setNumRounds(rounds.Length - 1);
                for (int i = 0; i < rounds.Length - 1; ++i)
                {
                    string s = rounds[i];
                    s = s.Substring(1, s.Length - 2);
                    Round r = new Round();
                    int totalE = 0;
                    string[] p = s.Split(' ');
                    r.setDifEnemies(p.Length);
                    for (int j = 0; j < p.Length; ++j)
                    {
                        string z = p[j];
                        string[] values = z.Split('-');
                        totalE += int.Parse(values[0]);
                        r.setEnemy(j, int.Parse(values[0]), int.Parse(values[1]));
                    }
                    r.totalEnemies = totalE;
                    level.setRound(i, r);
                }
            }
        }
        for (int k = 0; k < level.numRounds; ++k)
        {
            level.totalLevelZombies += level.getRound(k).totalEnemies;
        }

    }

    public void zombieDead()
    {
        --remainingZombies;
        ++killed;
    }


    IEnumerator zombieSpawn()
    {
        int n = level.numRounds;
        for (int i = 0; i < n; ++i)
        {
            yield return new WaitForSeconds(10.0f);
            Round r = level.getRound(i);
            actualRound = i + 1;
            remainingZombies = r.totalEnemies;
            int k = r.difEnemies;
            for (int j = 0; j < k; ++j)
            {
                int num = r.enemyAmount(j);
                int type = r.enemyKind(j);
                GameObject zombie = standardZombie;
                if (type == 1) zombie = standardZombie;
                else if (type == 2) zombie = bucketZombie;
                else if (type == 3) zombie = runnerZombie;
                for (int zn = 0; zn < num; ++zn)
                {
                    int row = Random.Range(0, 5);
                    int d = Random.Range(0, 5);
                    GameObject zombie1 = (GameObject)Instantiate(zombie, transform.position + new Vector3((float)30 + d, -0.15f, (float)(row * 5)), zombie.transform.rotation);
                    zombie1.transform.parent = transform;
                    yield return new WaitForSeconds(2.0f);
                }
            }
            yield return new WaitUntil(() => remainingZombies == 0);

        }
        win = true;
    }
}
