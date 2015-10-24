using UnityEngine;

public abstract class InteractableObjectCollider : InteractableObject
{
	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag.Equals("Player"))
		{
			_interactable = true;
			uiInteractable.enabled = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D collider)
	{
		if(collider.gameObject.tag.Equals("Player"))
		{
			_interactable = false;
			uiInteractable.enabled = false;
		}
	}
}
