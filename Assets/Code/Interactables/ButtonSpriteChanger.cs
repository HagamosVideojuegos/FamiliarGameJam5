using UnityEngine;
using System.Collections;

public class ButtonSpriteChanger : MonoBehaviour {

	public Sprite activated,deactivated;

	private SpriteRenderer spriterender;
	private Button selfInstance;

	// Use this for initialization
	void Start () {
		spriterender=this.GetComponent<SpriteRenderer>();
		selfInstance=this.GetComponent<Button>();
		Button.OnActivate+=Activate;
		Button.OnDeactivate+=Deactivate;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void Activate (Button button)
	{
		if(button==this.selfInstance){
			spriterender.sprite=activated;
		}
	}

	void Deactivate (Button button)
	{
		if(button==this.selfInstance){
			spriterender.sprite=deactivated;
		}
	}
}
