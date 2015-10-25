using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
	public static event Activate OnActivate;
	public static event Deactivate OnDeactivate;
	
	public delegate void Activate(Button button);
	public delegate void Deactivate(Button button);
	
	List<GameObject> weightObjects = new List<GameObject>();
	
	public int weightNeeded;
	public int currentWeight;
	public bool Activated;
    public bool Crash;
	
    void OnTriggerEnter2D(Collider2D collider)
	{
		var g = collider.gameObject;
		
		if(g.GetComponent<Piece>() != null || g.GetComponent<Box>() != null || g.GetComponent<PlayerController>() != null)
		{
			if(!weightObjects.Find((findObject) => findObject == g))
				weightObjects.Add(g);
		} else {
			return;
		}
		
		CalculateWeight();
		
		if(!Activated && currentWeight >= weightNeeded)
		{
			Activated = true;
			if(OnActivate != null)
				OnActivate(this);
		}

        if (Crash)
        {
            Destroy(this.gameObject);
        }
	}
	
	void OnTriggerExit2D(Collider2D collider)
	{
		var g = collider.gameObject;
		
		if(g.GetComponent<Piece>() != null || g.GetComponent<Box>() != null || g.GetComponent<PlayerController>() != null)
		{
			weightObjects.Remove(g);
		} else {
			return;
		}
		
		CalculateWeight();
		
		if(Activated && currentWeight < weightNeeded)
		{
			Activated = false;
			if(OnDeactivate != null)
				OnDeactivate(this);
		}
	}
	
	private void CalculateWeight()
	{
		currentWeight = 0;
		
		weightObjects.RemoveAll(item => item == null);
		
		foreach(GameObject go in weightObjects)
		{
			if(go != null)
			{
				if(go.GetComponent<Piece>() != null)
				{
					currentWeight += go.GetComponent<Piece>().Weight;
				}
				else if (go.GetComponent<PlayerController>() != null)
				{
					currentWeight += go.GetComponent<PlayerController>().FullWeight;
				}
				else if (go.GetComponent<Box>() != null)
				{
					currentWeight += go.GetComponent<Box>().Weight;
				}
			}
		}
		
		currentWeight = Mathf.Clamp(currentWeight, 0, int.MaxValue);
	}
}
