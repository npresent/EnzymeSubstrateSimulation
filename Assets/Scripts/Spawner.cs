using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Spawner : MonoBehaviour
{
    public int population, generation,gen,maxGen, mutation, best;
    public int numOfEnzymes, numOfSubstrates;
    public static float properTemp, properPh;
    public static int currTemp, currPh;
    public float timeScale;

    public GameObject enzymePrefab, substratePrefab;

    public float cellWallLength;
    public float minForce = 1, maxForce = 50;

    public static int substrates, products;

    public TMPro.TextMeshProUGUI productsText, substratesText, currTempText, currPhText, properTempText, properPhText, generationText,timeText;

    public float totalTime = 0f;
    private int minute = 0;
    private int second = 0;
    private int tic = 0;

    public Dictionary<int, Generation> genDict;
    public Generation currGeneration;

    void Start()
    {
        Spawn();
        generation = 1;
        gen = 1;
        substrates = numOfSubstrates;
        products = 0;
        properTemp = 35;
        properPh = 7;
        currTemp = 35;
        currPh = 7;
        //currTemp = Random.Range(20, 40);
        //currPh = Random.Range(1, 9);
        currGeneration = new Generation(currTemp, currPh, generation, gen, 0);
        genDict = new Dictionary<int, Generation>();
        genDict.Add(0, currGeneration);
    }

    void SpawnEnzyme()
    {
        GameObject enzyme = Instantiate(enzymePrefab, 
            new Vector3(Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1)), 
                Random.rotation);
        
        float force = Random.Range(minForce, maxForce);
        enzyme.GetComponent<Rigidbody>().AddForce(enzyme.transform.forward * force * Time.deltaTime * 100);
    }
    void SpawnSubstrate()
    {
        GameObject substrate = Instantiate(substratePrefab,
            new Vector3(Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1), Random.Range(-(cellWallLength / 2 - 1), cellWallLength / 2 - 1)),
                Random.rotation);

        float force = Random.Range(minForce, maxForce);
        substrate.GetComponent<Rigidbody>().AddForce(substrate.transform.forward * force * Time.deltaTime * 100);
    }
    void Spawn()
    {
        for (int i = 0; i < numOfEnzymes; i++)
        {
            SpawnEnzyme();
        }

        for (int i = 0; i < numOfSubstrates; i++)
        {
            SpawnSubstrate();
        }
    }

    void Update()
    {
        if (substrates != 0 && substrates !=1)
            totalTime += Time.deltaTime;
        Time.timeScale = timeScale;
        substratesText.text = "Substrates: " + (substrates);
        productsText.text = "Products: " + (products);
        currTempText.text = "currTemp: " + (currTemp);
        currPhText.text = "currPh: " + (currPh);
        properTempText.text = "properTemp: " + (properTemp);
        properPhText.text = "properPh: " + (properPh);
        timeText.text = "Time : " + TimerCalc();
        generationText.text = "Generation : " + generation + " - " + gen;
        if (substrates == 0 || substrates == 1)
        {
            //initialize();
        }
    }
    void initialize()
    {
        DestroyImmediate(GameObject.Find("Enzyme(Clone)"));
        DestroyImmediate(GameObject.Find("Substrate(Clone)"));
        Debug.Log(genDict);
        if (gen != population)
        {
            gen += 1;
            substrates = numOfSubstrates;
            products = 0;
            properTemp = 35;
            properPh = 7;
            currTemp = Random.Range(20, 40);
            currPh = Random.Range(1, 9);
        }
        else
        {
            if (generation != maxGen)
            {
                generation += 1;
                gen = 0;

            }
        }
    }
    void mutate()
    {

    }
    private string TimerCalc()
    {
        tic = (int)((totalTime % 1) * 100);

        second = (int)totalTime % 60;

        minute = (int)totalTime / 60;

        return minute + " : " + second + " : " + tic;
    }
}
