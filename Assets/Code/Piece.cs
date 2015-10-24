public class Piece : InteractableObjectTrigger
{
	public int Weight;
	public PieceType pieceType;
	
	public enum PieceType
	{
		Arm,
		Body,
		Head,
		Leg
	} 


    protected override void Interact()
    {
        GameManager.Instance.player.Weight += Weight;
		switch (pieceType)
		{
			case PieceType.Arm:
			GameManager.Instance.player.pieces.arms += 1;
			break;
			case PieceType.Body:
			GameManager.Instance.player.pieces.body = true;
			break;
			case PieceType.Head:
			GameManager.Instance.player.pieces.head = true;
			break;
			case PieceType.Leg:
			GameManager.Instance.player.pieces.legs += 1;
			break;
		}
    }
}
