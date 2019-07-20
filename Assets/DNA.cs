using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA {

    private float Mass;
    private Color AvrColor;

    // Use this for initialization
    public DNA (float mass, Color c) {
        Mass = mass;
        AvrColor = c;
	}
	
	public float getMass()
    {
        return Mass;
    }

    public Color getColor()
    {
        return AvrColor;
    }

}
