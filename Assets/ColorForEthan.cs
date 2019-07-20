using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorForEthan : MonoBehaviour {
    

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Floor"))
        {
            GetComponentInChildren<Renderer>().material.color = collision.gameObject.GetComponent<Renderer>().material.color ;
        }
        else
        {
            Debug.Log(2);
        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
