using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ObjectStats : MonoBehaviour
{
    public float maxHP, HP, attack, speed, rateOfFire;
    public Text displayText;
    public Text displayText2;
    public Text displayText3;
    public Text displayText4;
    public RawImage displayRawImage;
    public GameObject tile;
    bool xx;
    bool xx2;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        HP = maxHP;
        dead = false;
        xx = true;
        xx2 = true;
        displayText.gameObject.SetActive(false);
        displayText2.gameObject.SetActive(false);
        displayText3.gameObject.SetActive(false);
        displayText4.gameObject.SetActive(false);
        displayRawImage.gameObject.SetActive(false);
    }



    // Update is called once per frame
    void Update()
    {
        if (HP <= 0 && !dead)
        {
            GetComponent<Collider>().enabled = false;
            GetComponent<Animator>().SetTrigger("dead");
            dead = true;
        }
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            int layermask2 = LayerMask.GetMask("Plants");
            int layermask3 = LayerMask.GetMask("Zombies");
            RaycastHit hit2;
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out hit2, 100, layermask2))
            {
                if (hit2.collider.gameObject == gameObject)
                {
                    if (xx)
                    {
                        xx = false;
                        displayText.gameObject.SetActive(true);
                        displayText2.gameObject.SetActive(true);
                        displayText3.gameObject.SetActive(true);
                        displayText4.gameObject.SetActive(true);
                        displayRawImage.gameObject.SetActive(true);
                        displayText.text = "Vida:" + HP.ToString() + "/" + maxHP.ToString();
                        displayText2.text = "Daño:" + attack.ToString();
                        displayText3.text = "Velocidad de ataque:" + speed.ToString();
                        displayText4.text = "Cadencia de ataque:" + rateOfFire.ToString();
                    }
                    else if (!xx)
                    {
                        xx = true;
                        displayText.gameObject.SetActive(false);
                        displayText2.gameObject.SetActive(false);
                        displayText3.gameObject.SetActive(false);
                        displayText4.gameObject.SetActive(false);
                        displayRawImage.gameObject.SetActive(false);
                        displayText.text = "Vida:" + HP.ToString() + "/" + maxHP.ToString();
                        displayText2.text = "Daño:" + attack.ToString();
                        displayText3.text = "Velocidad de ataque:" + speed.ToString();
                        displayText4.text = "Cadencia de ataque:" + rateOfFire.ToString();
                    }
                }
            }
            else if (Physics.Raycast(ray2, out hit2, 100, layermask3))
            {
                if (hit2.collider.gameObject == gameObject)
                {
                    if (xx2)
                    {
                        xx2 = false;
                        displayText.gameObject.SetActive(true);
                        displayText2.gameObject.SetActive(true);
                        displayText3.gameObject.SetActive(true);
                        displayText4.gameObject.SetActive(true);
                        displayRawImage.gameObject.SetActive(true);
                        displayText.text = "Vida:" + HP.ToString() + "/" + maxHP.ToString();
                        displayText2.text = "Daño:" + attack.ToString();
                        displayText3.text = "Velocidad de ataque:" + speed.ToString();
                        displayText4.text = "Cadencia de ataque:" + rateOfFire.ToString();
                    }
                    else if (!xx2)
                    {
                        xx2 = true;
                        displayText.gameObject.SetActive(false);
                        displayText2.gameObject.SetActive(false);
                        displayText3.gameObject.SetActive(false);
                        displayText4.gameObject.SetActive(false);
                        displayRawImage.gameObject.SetActive(false);
                        displayText.text = "Vida:" + HP.ToString() + "/" + maxHP.ToString();
                        displayText2.text = "Daño:" + attack.ToString();
                        displayText3.text = "Velocidad de ataque:" + speed.ToString();
                        displayText4.text = "Cadencia de ataque:" + rateOfFire.ToString();
                    }
                }
            }
            else
            {
                xx = true;
                xx2 = true;
                displayText.gameObject.SetActive(false);
                displayText2.gameObject.SetActive(false);
                displayText3.gameObject.SetActive(false);
                displayText4.gameObject.SetActive(false);
                displayRawImage.gameObject.SetActive(false);
            }
        }
    }
}
