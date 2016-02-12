using UnityEngine;
using System.Collections;

public class InitScript : MonoBehaviour {

	public GameObject hahmo;
	// Use this for initialization
	void Start () {
		 //Remove for now. Using mosue to spawn.
        for (int y = 2; y < 5; y++) {
            for (int x = -1; x < 2; x++) {
				GameObject hahmoInstance = (GameObject)Instantiate(hahmo, new Vector2 (x, y), Quaternion.identity);
            }
        }
	}
	void OnMouseDown() {

    }

	// Update is called once per frame
	void Update ()	{
	    if (Input.GetMouseButtonDown (0))
	    {
	        Spawner ();
	    }
	}

	void Spawner()	{
	    Vector3 mousePosition = Input.mousePosition;
	    transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);

	    //Instantiate(cube, transform.position, Quaternion.identity);
		GameObject hahmoInstance = (GameObject)Instantiate(hahmo, transform.position, Quaternion.identity);
	}
}
