using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDrawSetup : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponentInChildren<MeshRenderer>().sortingLayerName = "Foreground";
        GetComponentInChildren<MeshRenderer>().sortingOrder = 30;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
