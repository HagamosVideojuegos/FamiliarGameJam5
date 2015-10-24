using UnityEngine;
using System.Collections;

public class UIFunctions : MonoBehaviour {

	private GameObject controlsDescriptionPanel;

	// Use this for initialization
	void Start () {
		controlsDescriptionPanel=GameObject.Find("ControlsPopUp");
		controlsDescriptionPanel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void OpenControlsDescription(){
		controlsDescriptionPanel.SetActive(true);
	}

	public void CloseControlsDEscription(){
		controlsDescriptionPanel.SetActive(false);
	}

	public void StartGame(){
		Application.LoadLevel(2);
	}
}
