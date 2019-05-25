using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotMovement : MonoBehaviour
{
    public GameObject damageText;
    public float speedPenalty;
    public float speed;
    public float attack;
    public GameObject pso;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(speed, 0.0f, 0.0f);   
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Zombie") {
            Physics.IgnoreCollision(other.GetComponent<Collider>(), GetComponent<Collider>());
            Instantiate(pso, transform.position, pso.transform.rotation);
            other.gameObject.GetComponent<ObjectStats>().HP -= attack;
            GameObject dt = (GameObject)Instantiate(damageText, other.gameObject.transform.position + new Vector3(-2,5,0), damageText.transform.rotation);
            dt.GetComponent<TextMesh>().text = attack.ToString();
            if (gameObject.tag == "SnowPea" && !other.gameObject.GetComponent<ObjectStats>().frozen)
            {
                other.gameObject.GetComponent<ObjectStats>().speed *= speedPenalty;
                other.gameObject.GetComponent<ObjectStats>().frozen = true;
                SoundManager.PlaySound("freeze");
            }
            else SoundManager.PlaySound("hit");
            other.gameObject.GetComponent<ObjectStats>().updateOverlay();
            Destroy(gameObject);
        }
    }
}
