﻿using UnityEngine;

public class Button : MonoBehaviour
{
	public static event Activate OnActivate;
	public static event Deactivate OnDeactivate;
	
	public delegate void Activate(Button button);
	public delegate void Deactivate(Button button);
	
	
	public int weightNeeded;
	public int currentWeight;
	public bool Activated;
	
    void OnTriggerEnter2D(Collider2D collider)
	{
		Piece piece = collider.GetComponent<Piece>();
		
		if(piece)
		{
			currentWeight += currentWeight;
		}
		
		if(!Activated && currentWeight >= weightNeeded)
		{
			Activated = true;
			if(OnActivate != null)
				OnActivate(this);
		}
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		Piece piece = collider.GetComponent<Piece>();
		
		if(piece)
		{
			currentWeight -= currentWeight;
		}
		
		if(Activated && currentWeight <= weightNeeded)
		{
			Activated = false;
			if(OnDeactivate != null)
				OnDeactivate(this);
		}
	}
}
