using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSite : MonoBehaviour
{

    public Material productMat;

    public void Start()
    {
        Debug.Log("Test");
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key"))
        {
            Debug.Log("Connected");
            //other.transform.root.parent = transform.root;
            other.transform.root.GetComponent<Renderer>().material = productMat;
            Spawner.products++;
            Spawner.substrates--;
            other.transform.tag = "Untagged";
        }

    }
}
