public class Piece : InteractableObjectTrigger
{
	public int Weight;
	public PieceType pieceType;

    protected override void Interact()
    {
        GameManager.Instance.player.FullWeight += Weight;
		GameManager.Instance.player.ActivatePiece(pieceType);
		Destroy(gameObject);
    }
}
