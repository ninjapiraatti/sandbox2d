﻿using UnityEngine;
using System.Collections;

public class pickTexture : MonoBehaviour {

	// Use this for initialization
	public Sprite texturehair01;
	public Sprite texturehair02;
	public Sprite texturehair03;
	public Sprite texturehead01;
	public Sprite texturehead02;
	public Sprite texturehead03;
	public Sprite texturebody01;
	public Sprite texturebody02;
	public Sprite texturebody03;
	public Sprite texturelegs01;
	public Sprite texturelegs02;
	public Sprite texturelegs03;
	public Sprite texturefeet01;
	public Sprite texturefeet02;
	public Sprite texturefeet03;
	public Sprite chosenTexture;
	public int spriteOrder = 0;
	private Rigidbody2D myScriptsRigidbody2D;
	public bool Frozen = false;
	public bool Exploded = false;

	void Start () {
		int randomInt = Random.Range(1,4);
		string bodyPart = "";
		string textureName = "";
		//Detect which slot we're changing
		if (this.gameObject.name == "hair") {
			if (randomInt == 1) {
				chosenTexture = texturehair01;
			} else if (randomInt == 2) {
				chosenTexture = texturehair02;
			} else {
				chosenTexture = texturehair03;
			}
			spriteOrder = 1;
		}
		else if (this.gameObject.name == "head") {
			if (randomInt == 1) {
				chosenTexture = texturehead01;
			} else if (randomInt == 2) {
				chosenTexture = texturehead02;
			} else {
				chosenTexture = texturehead03;
			}
		}
		else if (this.gameObject.name == "body") {
			if (randomInt == 1) {
				chosenTexture = texturebody01;
			} else if (randomInt == 2) {
				chosenTexture = texturebody02;
			} else {
				chosenTexture = texturebody03;
			}
			spriteOrder = 1;
		}
		else if (this.gameObject.name == "legs") {
			if (randomInt == 1) {
				chosenTexture = texturelegs01;
			} else if (randomInt == 2) {
				chosenTexture = texturelegs02;
			} else {
				chosenTexture = texturelegs03;
			}
		}
		else {
			if (randomInt == 1) {
				chosenTexture = texturefeet01;
			} else if (randomInt == 2) {
				chosenTexture = texturefeet02;
			} else {
				chosenTexture = texturefeet03;
			}
			spriteOrder = 1;
		}
		textureName = bodyPart + "_0" + randomInt;
		gameObject.GetComponent<SpriteRenderer>().sprite = chosenTexture;
	}

	public SpriteRenderer tempRend;  //allows to adjust for sorting within the unit layer, for visuals
	void Awake(){
		tempRend = gameObject.GetComponent<SpriteRenderer>();
	}
	void LateUpdate(){
		tempRend.sortingOrder = spriteOrder + (int)Camera.main.WorldToScreenPoint(tempRend.bounds.min).y * -10;
	}
	void freezeBodyPart() {
		Frozen = true;
		myScriptsRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
		myScriptsRigidbody2D.isKinematic = true;
		gameObject.GetComponent<Collider2D>().isTrigger = true;
	}

	// Update is called once per frame
	void Update () {

	}
	void OnCollisionEnter2D(Collision2D coll) {
		if((Exploded == true) && (Frozen == false) && (coll.gameObject.tag == "WakeOnAction")) {
			freezeBodyPart();
			//Debug.Log("Bodypart Collision2D");
		}
	}
}
