using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public int numOfEnzymes, numOfSubstrates;
    public float timeScale;

    public GameObject enzymePrefab, substratePrefab;

    public float cellWallLength;
    public float minForce = 1, maxForce = 50;

    public static int substrates, products;

    public TMPro.TextMeshProUGUI productsText, substratesText;
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < numOfEnzymes; i++)
        {
            SpawnEnzyme();
        }

        for (int i = 0; i < numOfSubstrates; i++)
        {
            SpawnSubstrate();
        }

        substrates = numOfSubstrates;
        products = 0;
    }

    void SpawnEnzyme()
    {
        GameObject enzyme = Instantiate(enzymePrefab, 
            new Vector3(Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1)), 
                Random.rotation);
        
        //float force = Random.Range(minForce, maxForce);
        //enzyme.GetComponent<Rigidbody>().AddForce(enzyme.transform.forward * force * Time.deltaTime * 100);
    }

    void SpawnSubstrate()
    {
        GameObject substrate = Instantiate(substratePrefab,
            new Vector3(Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1)),
                Random.rotation);

        //float force = Random.Range(minForce, maxForce);
        //substrate.GetComponent<Rigidbody>().AddForce(substrate.transform.forward * force * Time.deltaTime * 100);
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = timeScale;
        substratesText.text = "Substrates: " + substrates;
        productsText.text = "Products: " + products;

    }
}
