﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawScore : MonoBehaviour {
    public int number{ get; set; }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GetComponentInChildren<TextMesh>().text = number.ToString();
    }
}
