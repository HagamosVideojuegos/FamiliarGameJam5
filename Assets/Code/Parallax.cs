using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	public SpriteRenderer fondo;
	private Vector3 lastPosition,currentPosition,deltaPosition;

	// Use this for initialization
	void Start () {
		if(fondo==null){
			fondo=GameObject.Find("Background").GetComponent<SpriteRenderer>();
		}
		this.lastPosition=this.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		currentPosition=this.transform.position;
		deltaPosition=lastPosition-currentPosition;
		lastPosition=currentPosition;
		fondo.transform.Translate(deltaPosition * 0.1f);
	}
}
