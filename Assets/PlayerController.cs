using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rigidb;

	// Use this for initialization
	void Awake () {
		rigidb=this.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Jumping(){
		rigidb.velocity=new Vector2(rigidb.velocity.x,100);
	}
}
