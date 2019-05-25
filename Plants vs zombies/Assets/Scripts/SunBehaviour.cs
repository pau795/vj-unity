using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SunBehaviour : MonoBehaviour
{
    public GameObject sunClickText;
    public GameObject pso;
    public int sunProfit;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) {
            int layermask = LayerMask.GetMask("Sun");
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100, layermask))
            {
                if (hit.collider.gameObject == gameObject) {
                    //Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow, 3);
                    SoundManager.PlaySound("coin");
                    GameObject pt = (GameObject) Instantiate(sunClickText, transform.position, sunClickText.transform.rotation);
                    pt.GetComponent<TextMesh>().text = "+ " + sunProfit.ToString() + " suns";
                    Instantiate(pso, transform.position, pso.transform.rotation);
                    SceneElements.sunCount += sunProfit;
                    SceneElements.change = true;
                    Destroy(gameObject);
                }
            } 
            //else Debug.DrawRay(ray.origin, ray.direction * 100, Color.green,3);

        }
    }

}
