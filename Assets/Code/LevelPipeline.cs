using UnityEngine;
using System.Collections;

public class LevelPipeline : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Application.LoadLevel(Application.loadedLevel+1);
	}

}
