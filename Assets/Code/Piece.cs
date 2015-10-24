public class Piece : InteractableObjectTrigger
{
	public int Weight;
	public PieceType pieceType;
	
	public enum PieceType
	{
		Arm,
		Head,
		Leg
	} 


    protected override void Interact()
    {
        GameManager.Instance.player.Weight += Weight;
		switch (pieceType)
		{
			case PieceType.Arm:
			switch(GameManager.Instance.player.pieces.arms)
			{
				case 0:
				GameManager.Instance.player.pieces.RightArm.SetActive(true);
				break;
				case 1:
				GameManager.Instance.player.pieces.LeftArm.SetActive(true);
				break;
			}
			break;
			case PieceType.Head:
			GameManager.Instance.player.pieces.Head.SetActive(true);
			break;
			case PieceType.Leg:
			switch(GameManager.Instance.player.pieces.legs)
			{
				case 0:
				GameManager.Instance.player.pieces.RightLeg.SetActive(true);
				break;
				case 1:
				GameManager.Instance.player.pieces.LeftLeg.SetActive(true);
				break;
			}
			break;
		}
		
		Destroy(gameObject);
    }
}
