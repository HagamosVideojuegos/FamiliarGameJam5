using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Bocadillo : MonoBehaviour {

	public string text;

	// Use this for initialization
	void Start () {
		//text=this.GetComponentInChildren<Text>().text;
		if(text!=""){
			this.CambiarTexto(text);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void CambiarTexto(string nuevotexto){
		this.GetComponentInChildren<Text>().text=nuevotexto;
	}
}
