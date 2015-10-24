using UnityEngine;

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
		var piece = collider.GetComponent<Piece>();
		var player = collider.GetComponent<PlayerController>();
		var box = collider.GetComponent<Box>();
		
		if(piece)
		{
			currentWeight += piece.Weight;
		} else if (player) {
			currentWeight += player.FullWeight;
		} else if (box && box.GetComponent<Rigidbody2D>() != null) {
			currentWeight += box.Weight;
		} else {
			return;
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
		var piece = collider.GetComponent<Piece>();
		var player = collider.GetComponent<PlayerController>();
		var box = collider.GetComponent<Box>();
		
		if(piece)
		{
			currentWeight -= piece.Weight;
		} else if (player) {
			currentWeight -= player.FullWeight;
		} else if (box) {
			currentWeight -= box.Weight;
		} else {
			return;
		}
		
		if(Activated && currentWeight < weightNeeded)
		{
			Activated = false;
			if(OnDeactivate != null)
				OnDeactivate(this);
		}
	}
}
