public class Piece : InteractableObjectTrigger
{
	public bool mounted;
	public int Weight;

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
