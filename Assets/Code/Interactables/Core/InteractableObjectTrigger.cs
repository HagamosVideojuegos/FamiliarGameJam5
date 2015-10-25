﻿using UnityEngine;

public abstract class InteractableObjectTrigger : InteractableObject
{	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if(collider.tag.Equals("Player"))
		{
			_interactable = true;
			if(uiInteractable != null)
				uiInteractable.enabled = true;
		}
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		if(collider.gameObject.tag.Equals("Player"))
		{
			_interactable = false;
			if(uiInteractable != null)
				uiInteractable.enabled = false;
		}
	}
}
