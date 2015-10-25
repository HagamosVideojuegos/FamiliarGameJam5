using UnityEngine;

public class UIPiece : InteractableObjectUI
{
	public int Weight;
	public Piece piece;
	public AudioClip okSound,failSound;
    protected override void Interact()
    {
		if(GameManager.Instance.player.DeactivatePiece(piece.pieceType))
		{
			Instantiate(piece, GameManager.Instance.player.transform.position, new Quaternion(0, 0, 0 ,0));
			if(okSound!=null)AudioManager.Instance.PlaySound(okSound);
		} else {
			if(failSound!=null)AudioManager.Instance.PlaySound(failSound);
		}
			
    }
}
