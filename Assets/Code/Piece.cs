using System;

public class Piece : InteractableObject
{
	public bool mounted;
	public int Weight;
	
	void Awake()
	{
		InputManager.OnPieceSelected += HandleOnPieceSelected;
	}
	
	void OnDestroy ()
	{
		InputManager.OnPieceSelected -= HandleOnPieceSelected;
	}
	
	void HandleOnPieceSelected(Piece piece)
	{
		//TODO: brightness
	}

    protected override void Interact()
    {
        if (mounted)
		{
			//TODO: Make a new clone piece and put out
		} else {
			//TODO: Destroy this and activate the equal piece in the player
		}
    }
}
