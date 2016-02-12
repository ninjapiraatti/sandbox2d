using UnityEngine;
using System.Collections;

public class hahmo : MonoBehaviour {

	public Transform target;
	public float floor;
	float directionX = 0.3F;
	float directionY = 0.3F;
	private bool allowMovement = true;
	bool moving = true;
	bool targeting = false;
	float speedFactor = 3.0F;
	float randomBoolean = Random.Range(0.1F,7.0F);
	private Rigidbody2D myScriptsRigidbody2D;
	private Collider2D myScriptsCollider2D;
	public pickTexture targetedBodyPart;

	// Use this for initialization
	void Start () {
		movement();
		target = GameObject.Find("Waypoint").transform;
	}

	// Update is called once per frame
	void Update () {
		if(allowMovement == true) {
			if (!moving) {

			} else {
				transform.Translate((directionX * speedFactor * Time.deltaTime), (directionY * speedFactor * Time.deltaTime), (directionY * -1 * speedFactor * Time.deltaTime));
			}

			if (targeting) {
				transform.position = Vector3.MoveTowards(transform.position, target.position, (speedFactor / 200));
			}
		}
	}
	void changeDirection() {
		if(allowMovement == true) {
			randomBoolean = Random.Range(0.0F,10.0F);
			if(randomBoolean < 3.0F) {
				moving = false;
				targeting = false;
			} else if(randomBoolean < 8.0F) {
				moving = true;
				targeting = false;
				directionY = Random.Range(-0.3F,0.3F);
				directionX = Random.Range(-0.3F,0.3F);
				if (directionX > 0.0F) {
	    			transform.localRotation = Quaternion.Euler(0, 0, 0);
	    		} else {
					transform.localRotation = Quaternion.Euler(0, -180, 0);
					directionX = directionX * -1;
				}
			}
			else {
				targeting = true;
				float oldPos; //This is used to detect X direction
				float oldPos2; //This is used to detect X direction
				oldPos = transform.position.x;
				transform.position = Vector3.MoveTowards(transform.position, target.position, (speedFactor / 200));
				oldPos2 = transform.position.x;
				if (oldPos2 > oldPos) {
					transform.localRotation = Quaternion.Euler(0, 0, 0);
				} else {
					transform.localRotation = Quaternion.Euler(0, -180, 0);
				}
			}
		} else {

		}
	}
	void movement() {
		InvokeRepeating("changeDirection", 0, (randomBoolean / speedFactor));
	}
	void OnTriggerEnter2D(Collider2D coll) {
		if ((coll.gameObject.tag != "Bodypart") && (coll.gameObject.tag != "WakeOnAction")) {
			floor = transform.position.y;
			directionY = 0.0F;
			directionX = 0.0F;
			explode();
			gameObject.GetComponent<Collider2D>().isTrigger = true;
		}
    }
	void explode() {
		foreach (Transform child in transform) {
			if(child.gameObject.tag == "Bodypart"){

				targetedBodyPart = child.gameObject.GetComponent<pickTexture>();

				myScriptsRigidbody2D = child.gameObject.GetComponent<Rigidbody2D>();
				myScriptsRigidbody2D.isKinematic = false;
				float randomX = Random.Range(-1.5F,1.5F);
				float randomY = Random.Range(1F,3.0F);
				myScriptsRigidbody2D.AddForce(new Vector2(randomX, randomY), ForceMode2D.Impulse);
				allowMovement = false;
				targetedBodyPart.Exploded = true;

     		}
			if(child.gameObject.tag == "WakeOnAction"){
				myScriptsCollider2D = child.gameObject.GetComponent<Collider2D>();
				myScriptsCollider2D.isTrigger = false;
			}
		}
	}

}
