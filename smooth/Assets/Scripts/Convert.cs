using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Convert : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Collect")
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            other.gameObject.transform.GetChild(1).GetComponent<SphereCollider>().enabled= true;
            other.gameObject.transform.GetChild(1).GetComponent<MeshRenderer>().enabled = true;
        }
    }
}
