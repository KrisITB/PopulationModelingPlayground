using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class countChildren : MonoBehaviour {
    public int NEW_KIDS;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        NEW_KIDS = transform.childCount - 4;
	}
}
