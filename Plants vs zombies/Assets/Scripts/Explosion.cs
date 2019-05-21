using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    ParticleSystem expl;
    float radius;
    float inc;
    // Start is called before the first frame update
    void Start()
    {
        radius = 0.1f;
        inc = 0.15f;
        expl = GetComponent<ParticleSystem>();
        expl.Play();
        Destroy(expl, expl.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        if (radius >= 7.5f) {
            Destroy(gameObject);
        }
        else
        {
            radius += inc;
            transform.localScale += new Vector3(inc, inc, inc);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == 11)
        {
            other.gameObject.GetComponent<ZombieBehaviour>().die();
        }
    }
}
