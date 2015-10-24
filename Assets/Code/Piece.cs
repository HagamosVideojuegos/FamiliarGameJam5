public class Piece : InteractableObjectTrigger
{
	public int Weight;

    protected override void Interact()
    {
        GameManager.Instance.player.Weight += Weight;
    }
}
