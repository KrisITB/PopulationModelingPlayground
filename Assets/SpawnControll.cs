using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnControll : MonoBehaviour {
    public GameObject Gen1;
    private int i = 0;
    public int population = 0;
    public int TotalPopulation;
    public float minMass;
    public float maxMass;
    private float massAvrg;
    public float AvrageMass;
    public float TotalMass;
    private LinkedList <DNA> newKidsLList;
    public int environmentCaryingCapacity;
    public int rotationRate;
    public float forceMx;
    // Use this for initialization
    void Start () {
        massAvrg = (maxMass + minMass)/2;
        newKidsLList = new LinkedList<DNA>();
    }
	
	// Update is called once per frame
	void Update () {
        RotateAround();
        if (i%3 == 0)
        {
            spawn();
        }
        i++;
        population = transform.childCount;
        
    }

    public void AddAchild(DNA newKid) {
        newKidsLList.AddLast(newKid);
    }

    private void spawn()
    {
        float newForce = 0;

        if (newKidsLList.Count > 0)
        {
            GameObject newObject = Instantiate(Gen1, this.gameObject.transform);

            DNA dnaToSpawn = newKidsLList.First.Value;
            newKidsLList.RemoveFirst();

            newObject.GetComponent<Renderer>().material.color = dnaToSpawn.getColor();
            newObject.GetComponent<Rigidbody>().mass = dnaToSpawn.getMass();

            newForce = Random.Range(minMass, maxMass);
            newObject.GetComponent<move>().moveForce = newForce* forceMx;
        }
        else if (environmentCaryingCapacity > population)
        {
            float newMass = Random.Range(minMass, maxMass);
            newForce = Random.Range(minMass, maxMass);
            GameObject newObject = Instantiate(Gen1, this.gameObject.transform);
            newObject.gameObject.name = Gen1.name;
            newObject.GetComponent<Rigidbody>().mass = newMass;
            TotalMass += newMass;
            AvrageMass = TotalMass / population;
            newObject.GetComponent<move>().moveForce = newForce* forceMx;
        }

        TotalPopulation += 1;
    }

    private void RotateAround()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * rotationRate);
    }
}
