﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Enable()
    {
        GetComponent<Collider>().enabled = true;
    }

    public void Disable()
    {
        GetComponent<Collider>().enabled = false;
    }
}
