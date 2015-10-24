using UnityEngine;

public class UIPiece : InteractableObjectUI
{
	public int Weight;
	public Piece piece;
    protected override void Interact()
    {
        GameManager.Instance.player.FullWeight += Weight;
		bool deactivated=GameManager.Instance.player.DeactivatePiece(piece.pieceType);
		if(deactivated){
			Instantiate(piece, GameManager.Instance.player.transform.position, new Quaternion(0, 0, 0 ,0));
		}
		//TODO: Button OK Sound
    }
}
