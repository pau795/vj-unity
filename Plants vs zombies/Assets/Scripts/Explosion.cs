using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject damageText;
    public GameObject expl;
    float radius;
    float inc;
    // Start is called before the first frame update
    void Start()
    {
        SoundManager.PlaySound("explosion");
        radius = 0.1f;
        inc = 0.15f;
        Instantiate(expl, transform.position, expl.transform.rotation);
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

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 11)
        {
            other.gameObject.GetComponent<ZombieBehaviour>().die();
            GameObject dt = (GameObject)Instantiate(damageText, other.gameObject.transform.position, damageText.transform.rotation);
            dt.GetComponent<TextMesh>().text = other.gameObject.GetComponent<ObjectStats>().maxHP.ToString();
            other.gameObject.GetComponent<ObjectStats>().updateOverlay();
        }
    }
}
