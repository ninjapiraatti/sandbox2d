using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject hahmo;
	// Use this for initialization
	void Start () {
		Debug.Log ("Hello World!");
        for (int y = -2; y < 1; y++) {
            for (int x = -2; x < 1; x++) {
                //Instantiate(hahmo, new Vector2 (x, y), Quaternion.identity);
				GameObject hahmoInstance = (GameObject)Instantiate(hahmo, new Vector2 (x, y), Quaternion.identity);
            }
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
