using UnityEngine;
using System.Collections;

public class hahmo : MonoBehaviour {

	public Transform target;
	float directionX = 0.3F;
	float directionY = 0.3F;
	bool moving = true;
	bool targeting = false;
	float speedFactor = 3.0F;
	float randomBoolean = Random.Range(0.1F,7.0F);

	// Use this for initialization
	void Start () {
		movement();
		target = GameObject.Find("Waypoint").transform;
	}

	// Update is called once per frame
	void Update () {
		if (!moving) {

		} else {
			transform.Translate((directionX * speedFactor * Time.deltaTime), (directionY * speedFactor * Time.deltaTime), (directionY * -1 * speedFactor * Time.deltaTime));
		}

		if (targeting) {
			transform.position = Vector3.MoveTowards(transform.position, target.position, (speedFactor / 200));
		}
	}
	void changeDirection() {
		randomBoolean = Random.Range(0.0F,10.0F);
		if(randomBoolean < 3.0F ) {
			moving = false;
			targeting = false;
		} else if(randomBoolean < 8.0F ) {
			moving = true;
			targeting = false;
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
		else {
			targeting = true;

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
