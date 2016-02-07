using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject hahmo;
	// Use this for initialization
	void Start () {
        for (int y = 1; y < 5; y++) {
            for (int x = -2; x < 2; x++) {
                //Instantiate(hahmo, new Vector2 (x, y), Quaternion.identity);
				GameObject hahmoInstance = (GameObject)Instantiate(hahmo, new Vector2 (x, y), Quaternion.identity);
            }
        }
	}

	// Update is called once per frame
	void Update () {

	}
}
