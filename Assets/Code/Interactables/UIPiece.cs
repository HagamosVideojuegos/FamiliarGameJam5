using UnityEngine;

public class UIPiece : InteractableObjectUI
{
	public int Weight;
	public Piece piece;
    protected override void Interact()
    {
        GameManager.Instance.player.Weight += Weight;
		GameManager.Instance.player.DeactivatePiece(piece.pieceType);
		Instantiate(piece, GameManager.Instance.player.transform.position, new Quaternion(0, 0, 0 ,0));
		//TODO: Button OK Sound
    }
}
