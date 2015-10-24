using UnityEngine;

public class UIPiece : InteractableObjectUI
{
	public int Weight;
	public Piece piece;
    protected override void Interact()
    {
        GameManager.Instance.player.Weight += Weight;
		switch (piece.pieceType)
		{
			case PieceType.Arm:
			switch(GameManager.Instance.player.pieces.arms)
			{
				case 0:
				//TODO: Fail button sound
				return;
				case 1:
				GameManager.Instance.player.pieces.RightArm.SetActive(false);
				break;
				case 2:
				GameManager.Instance.player.pieces.LeftArm.SetActive(false);
				break;
			}
			break;
			case PieceType.Head:
			GameManager.Instance.player.pieces.Head.SetActive(false);
			break;
			case PieceType.Leg:
			switch(GameManager.Instance.player.pieces.legs)
			{
				case 0:
				//TODO: Fail button sound
				return;
				case 1:
				GameManager.Instance.player.pieces.RightLeg.SetActive(false);
				break;
				case 2:
				GameManager.Instance.player.pieces.LeftLeg.SetActive(false);
				break;
			}
			break;
		}
		GameManager.Instance.player.DeactivatePiece(piece.pieceType);
		Instantiate(piece, GameManager.Instance.player.transform.position, new Quaternion(0, 0, 0 ,0));
		//TODO: Button OK Sound
    }
}
