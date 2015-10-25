using UnityEngine;
using System.Collections;

public class UIFunctions : MonoBehaviour {

	private GameObject controlsDescriptionPanel;

	// Use this for initialization
	void Start () {
		controlsDescriptionPanel=GameObject.Find("ControlsPopUp");
		if(controlsDescriptionPanel!=null)controlsDescriptionPanel.SetActive(false);
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

	public void GoToTwitter(string url){
		Application.OpenURL(url);
	}

	public void AutoDestruction(){
		GameManager.Instance.player.SelfDestruct();
	}

	public void PlayAgain(){
		Application.LoadLevel(0);
	}
}
