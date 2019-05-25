using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRemover : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 14) other.gameObject.GetComponent<MowerBehaviour>().src.Stop();
        if (other.gameObject.layer == 11) SceneElements.remainingZombies -= 1;
        Destroy(other.gameObject);

    }
}
