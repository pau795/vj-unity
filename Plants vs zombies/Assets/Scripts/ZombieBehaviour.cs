using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    float speed, attack, rateOfFire;
    Animator animator;
    SkinnedMeshRenderer rend;
    public GameObject damageText;

    public GameObject spawnPS;

    int walkingHash = Animator.StringToHash("Base Layer.Zombie Walking");
    int IdleHash = Animator.StringToHash("Base Layer.Zombie Idle");

    private GameObject target;
    bool dead;
    bool attacking;
    bool once;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawnPS, transform.position - new Vector3(0f, -0.8f, 0f), spawnPS.transform.rotation);
        speed = GetComponent<ObjectStats>().speed;
        attack = GetComponent<ObjectStats>().attack;
        rateOfFire = GetComponent<ObjectStats>().rateOfFire;
        animator = GetComponent<Animator>();
        rend = transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>();
        attacking = false;
        once = true;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
        if (state.fullPathHash == walkingHash)
        {
            speed = GetComponent<ObjectStats>().speed;
            transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0.0f, 0.0f);
        }
        if (state.fullPathHash == IdleHash)
        {
            if (!dead && attacking && once)
            {
                rateOfFire = GetComponent<ObjectStats>().rateOfFire;
                int randomNumber = Random.Range(1, 4);
                animator.SetTrigger("attack" + randomNumber);
                animator.SetFloat("rateOfFire", rateOfFire);
                once = false;
            }
            else
            {
                animator.SetTrigger("move");
                animator.SetFloat("speed", speed);
            }
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (!dead && once && other.gameObject.layer == 10)
        {
            Physics.IgnoreCollision(other.gameObject.GetComponent<Collider>(), GetComponent<Collider>());
            animator.SetTrigger("stand");
            target = other.gameObject;
            attacking = true;
        }

    }

    void OnTriggerEnter(Collider other)
    {

        if (!dead && once && other.gameObject.layer == 10)
        {
            Physics.IgnoreCollision(other, GetComponent<Collider>());
            animator.SetTrigger("stand");
            target = other.gameObject;
            attacking = true;
        }

    }

    public void die()
    {
        SoundManager.PlaySound("zombieDeath");
        speed = 0;
        dead = true;
        GetComponent<Collider>().enabled = false;
        animator.SetTrigger("dead");
    }

    void disappear()
    {
        StartCoroutine("fadeOut");
        SceneElements sc = transform.parent.gameObject.GetComponent<SceneElements>();
        sc.zombieDead();
    }

    IEnumerator fadeOut()
    {
        changeMaterialRender();
        for(float i = 1.0f; i > 0.0f; i -= Time.deltaTime/3)
        {
            Color c = rend.material.color;
            c.a = i;
            rend.material.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }

    void changeMaterialRender()
    {
        rend.material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
        rend.material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        rend.material.SetInt("_ZWrite", 0);
        rend.material.DisableKeyword("_ALPHATEST_ON");
        rend.material.EnableKeyword("_ALPHABLEND_ON");
        rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
        rend.material.renderQueue = 3000;
    }

    void doDamage()
    {
        if (target != null)
        {
            attack = GetComponent<ObjectStats>().attack;
            target.GetComponent<ObjectStats>().HP -= attack;
            target.GetComponent<ObjectStats>().updateOverlay();
            GameObject dt = (GameObject)Instantiate(damageText, target.transform.position, damageText.transform.rotation);
            dt.GetComponent<TextMesh>().text = attack.ToString();
            if (target.GetComponent<ObjectStats>().HP <= 0)
            {
                attacking = false;
                target.GetComponent<ObjectStats>().HP = 0;
            }
            once = true;
        }

    }
}
