using UnityEngine;
using System.Collections;

public class hahmo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		movement();
	}

	// Update is called once per frame
	float directionX = 0.3F;
	float directionY = 0.3F;
	bool moving = true;
	float speedFactor = 3.0F;
	float randomBoolean = Random.Range(0.1F,7.0F);

	void Update () {
		if (!moving) {

		} else {
			transform.Translate((directionX * speedFactor * Time.deltaTime), (directionY * speedFactor * Time.deltaTime), (directionY * -1 * speedFactor * Time.deltaTime));
		}
	}
	void changeDirection() {
		randomBoolean = Random.Range(0.0F,10.0F);
		if(randomBoolean < 5.0F ) {
			moving = false;
		} else {
			moving = true;
			directionY = Random.Range(-0.3F,0.3F);
			directionX = Random.Range(-0.3F,0.3F);
			if (directionX > 0.0F) {
    			//facingRight = false;
    			transform.localRotation = Quaternion.Euler(0, 0, 0);
    		} else {
    			//facingRight = true;
				transform.localRotation = Quaternion.Euler(0, -180, 0);
				directionX = directionX * -1;
			}
		}
	}
	void movement() {
		InvokeRepeating("changeDirection", 0, (randomBoolean / speedFactor));
	}
	void OnCollisionEnter2D(Collision2D coll) {
		directionY = 0.0F;
		directionX = 0.0F;

    }

}
