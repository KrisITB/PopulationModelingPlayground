using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour {
   
    public float moveForce;

    private void StartToMove()
    {
       this.gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(moveForce, 0, 0));
    }

    public void MoveOnVector(Vector3 moveForceVector)
    {
        this.gameObject.GetComponent<Rigidbody>().AddForce(moveForceVector);
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
    }

	// Use this for initialization
	void Start () {
        StartToMove();

    }
	
	// Update is called once per frame
	void Update () {
    }
}
