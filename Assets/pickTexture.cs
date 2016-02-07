using UnityEngine;
using System.Collections;

public class pickTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int randomInt = Random.Range(1,4);
		//Detect which slot we're changing
		Debug.Log(randomInt);
	}

	// Update is called once per frame
	void Update () {

	}
}
