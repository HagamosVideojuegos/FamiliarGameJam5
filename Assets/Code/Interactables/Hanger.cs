using UnityEngine;
using System.Collections;

public class Hanger : MonoBehaviour {

	public GameObject invisiblePlatform;

	// Use this for initialization
	void Start () {
		invisiblePlatform.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag.Equals("Player")){
			if(GameManager.Instance.player.pieces.arms==2){
				invisiblePlatform.SetActive(true);
				GameManager.Instance.player.HandleHang(true);
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag.Equals("Player")){
			invisiblePlatform.SetActive(false);
			GameManager.Instance.player.HandleHang(false);
		}
	}
}
