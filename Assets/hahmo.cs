using UnityEngine;
using System.Collections;

public class hahmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log ("Hahmo luotu");
		movement();
	}

	// Update is called once per frame
	float directionX = 0.3F;
	float directionY = 0.3F;
	bool moving = true;
	float randomBoolean = Random.Range(0.1F,7.0F);

	void Update () {
		if (!moving) {

		} else {
			transform.Translate((directionX * Time.deltaTime), (directionY * Time.deltaTime),0);
		}
	}
	void changeDirection() {
		Debug.Log (randomBoolean);
		randomBoolean = Random.Range(0.0F,10.0F);
		if(randomBoolean < 5.0F) {
			moving = false;
		} else {
			moving = true;
			directionY = Random.Range(-0.3F,0.3F);
			directionX = Random.Range(-0.3F,0.3F);
		}
	}
	void movement() {
		InvokeRepeating("changeDirection", 0, randomBoolean);
	}

}
