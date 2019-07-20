using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class procration : MonoBehaviour {
    public GameObject Prefabik;
    private GameObject ParentOfGen;
    public float age;
    private float birthTime;
    private SpawnControll[] spawns;
    public float reproductionAge;
    public float libidoTreshold;
    public float birthMortalityRate;
    

    void OnCollisionEnter(Collision col)
    {
        age = Time.time - birthTime;
        if (age > reproductionAge)
        {
            if (!col.gameObject.name.Equals(this.gameObject.name) && !col.gameObject.CompareTag("Floor") && !col.gameObject.CompareTag("Player"))
            {
                if (Random.Range(0f, 1f) < libidoTreshold)
                {
                    GameObject newPartner = col.gameObject;
                    Reproduce(newPartner);
                }
            }
        }
    }
 

    private void Reproduce(GameObject newPartner)
    {
        DNA newDNA;        
        
        float mass1 = newPartner.gameObject.GetComponent<Rigidbody>().mass;
        float mass2 = this.gameObject.GetComponent<Rigidbody>().mass;
        Color collor1 = newPartner.gameObject.GetComponent<Renderer>().material.color;
        Color collor2 = this.gameObject.GetComponent<Renderer>().material.color;
        float massAvrg = (mass1 + mass2) / 2;
        Color collorAvrg = (collor1 + collor2) / 2;
        int generation;

        newDNA = new DNA(massAvrg, collorAvrg);

        if (massAvrg > 1000)
        {
            generation = 4;
        }else if(massAvrg > 100)
        {
            generation = 3;
        }else if(massAvrg > 10)
        {
            generation = 2;
        }
        else
        {
            generation = 1;
        }

        spawns[generation-1].AddAchild(newDNA);
        if (Random.Range(0f, 1f) < birthMortalityRate)
        {
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
        ParentOfGen = GameObject.FindGameObjectWithTag("Spawns");
        //transforms = ParentOfGen.GetComponentsInChildren<Transform>();
        spawns = GameObject.FindGameObjectWithTag("Spawns").GetComponentsInChildren<SpawnControll>();
        //foreach (SpawnControll script in spawns) { Debug.Log("scriptParent : " + script.GetComponentInParent<Transform>().name); };
         //   GetComponentsInChildrens<SpawnControll>();
        birthTime = Time.time;
        float thisMass = this.GetComponent<Rigidbody>().mass;
        reproductionAge = 18 * (1 + Random.Range(thisMass / 10000, thisMass / 1000));
        libidoTreshold = 0.5f;
    }
	
	// Update is called once per frame
	void Update () {
        age = Time.time - birthTime;
        float sigmoidOfAge = 0.2f / (0.1f + Mathf.Exp(-age*0.1f));
        this.gameObject.transform.localScale = new Vector3(sigmoidOfAge, sigmoidOfAge, sigmoidOfAge); 
    }
}
