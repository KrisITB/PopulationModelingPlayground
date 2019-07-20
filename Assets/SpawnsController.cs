using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnsController : MonoBehaviour {
    private SpawnControll[] childrenSpawns;
    // Use this for initialization
    public int Gen1_num;
    public int Gen2_num;
    public int Gen3_num;
    public int Gen4_num;

    public float Gen1_mass;
    public float Gen2_mass;
    public float Gen3_mass;
    public float Gen4_mass;

    public float Gen1_avrgMass;
    public float Gen2_avrgMass;
    public float Gen3_avrgMass;
    public float Gen4_avrgMass;

    [HeaderAttribute("%")]
    public float Gen1_percent;
    public float Gen2_percent;
    public float Gen3_percent;
    public float Gen4_percent;

    [HeaderAttribute("Total")]
    public int Total_num;
    public float Total_mass;
    public float Total_avrgMass;

    void Start () {
        childrenSpawns = GetComponentsInChildren<SpawnControll>();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < childrenSpawns.Length; i++)
        {
            if (i == 0)
            {
                Gen1_num = childrenSpawns[i].population;
                Gen1_mass = childrenSpawns[i].TotalMass;
                Gen1_avrgMass = childrenSpawns[i].AvrageMass;
            }
            else if (i == 1)
            {
                Gen2_num = childrenSpawns[i].population;
                Gen2_mass = childrenSpawns[i].TotalMass;
                Gen2_avrgMass = childrenSpawns[i].AvrageMass;
            }
            else if (i == 2)
            {
                Gen3_num = childrenSpawns[i].population;
                Gen3_mass = childrenSpawns[i].TotalMass;
                Gen3_avrgMass = childrenSpawns[i].AvrageMass;
            }
            else if (i == 3)
            {
                Gen4_num = childrenSpawns[i].population;
                Gen4_mass = childrenSpawns[i].TotalMass;
                Gen4_avrgMass = childrenSpawns[i].AvrageMass;
            } 
        }
        Total_num = Gen1_num + Gen2_num + Gen3_num + Gen4_num;
        Total_mass = Gen1_mass + Gen2_mass + Gen3_mass + Gen4_mass;
        Total_avrgMass = Gen1_avrgMass + Gen2_avrgMass + Gen3_avrgMass + Gen4_avrgMass;
        Gen1_percent = Gen1_num / (Total_num*1f) * 100f;
        Gen2_percent = Gen2_num / (Total_num * 1f) * 100f;
        Gen3_percent = Gen3_num / (Total_num * 1f) * 100f;
        Gen4_percent = Gen4_num / (Total_num * 1f) * 100f;
    }
   
}
