using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip error;
    public static AudioClip pop;
    public static AudioClip explosion;
    public static AudioClip zombieDeath;
    public static AudioClip chomperAttack;
    public static AudioClip freeze;
    public static AudioClip coin;
    public static AudioClip falling;
    public static AudioClip hit;
    public static AudioClip plantSpawn;
    public static AudioClip win;
    public static AudioClip lose;
    public static AudioSource src;


    

    // Start is called before the first frame update
    void Start()
    {
        error = Resources.Load<AudioClip>("error");
        pop = Resources.Load<AudioClip>("pop");
        explosion = Resources.Load<AudioClip>("explosion");
        zombieDeath = Resources.Load<AudioClip>("zombieDeath");
        chomperAttack = Resources.Load<AudioClip>("chomperAttack");
        freeze = Resources.Load<AudioClip>("freeze");
        coin = Resources.Load<AudioClip>("coin");
        falling = Resources.Load<AudioClip>("falling");
        hit = Resources.Load<AudioClip>("hit");
        plantSpawn = Resources.Load<AudioClip>("plantSpawn");
        win = Resources.Load<AudioClip>("win");
        lose = Resources.Load<AudioClip>("lose");
        src = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    public static void PlaySound(string sound)
    {
        switch (sound){
            case "error":
                src.PlayOneShot(error, 0.5f);
                break;
            case "pop":
                src.PlayOneShot(pop);
                break;
            case "explosion":
                src.PlayOneShot(explosion);
                break;
            case "zombieDeath":
                src.PlayOneShot(zombieDeath, 0.5f);
                break;
            case "chomperAttack":
                src.PlayOneShot(chomperAttack, 0.5f);
                break;
            case "freeze":
                src.PlayOneShot(freeze, 0.5f);
                break;
            case "coin":
                src.PlayOneShot(coin);
                break;
            case "falling":
                src.PlayOneShot(falling);
                break;
            case "hit":
                src.PlayOneShot(hit);
                break;
            case "plantSpawn":
                src.PlayOneShot(plantSpawn);
                break;
            case "win":
                src.PlayOneShot(win);
                break;
            case "lose":
                src.PlayOneShot(lose);
                break;
            default:
                break;
        }
        
    }

}
