﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehaviour : MonoBehaviour
{
    float speed, attack, rateOfFire;
    Animator animator;
    SkinnedMeshRenderer rend;

    int walkingHash = Animator.StringToHash("Base Layer.Zombie Walking");
    int IdleHash = Animator.StringToHash("Base Layer.Zombie Idle");

    private GameObject target;
    bool attacking;
    bool once;

    // Start is called before the first frame update
    void Start()
    {
        speed = GetComponent<ObjectStats>().speed;
        attack = GetComponent<ObjectStats>().attack;
        rateOfFire = GetComponent<ObjectStats>().rateOfFire;
        animator = GetComponent<Animator>();
        rend = transform.GetChild(1).gameObject.GetComponent<SkinnedMeshRenderer>();
        attacking = false;
        once = true;

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
            if (attacking && once)
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
        if (once && other.gameObject.layer == 10)
        {
            animator.SetTrigger("stand");
            target = other.gameObject;
            attacking = true;
        }
    }

    public void die()
    {
        speed = 0;
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
        attack = GetComponent<ObjectStats>().attack;
        target.GetComponent<ObjectStats>().HP -= attack;
        if (target.GetComponent<ObjectStats>().HP <= 0)
        {
            attacking = false;
            target.GetComponent<ObjectStats>().HP = 0;
        }
        once = true;

    }
}
