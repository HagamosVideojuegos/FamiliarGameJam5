using UnityEngine;

public class Piece : InteractableObjectTrigger
{
	public int Weight;
	public PieceType pieceType;

    protected override void Interact()
    {
		if(GetComponent<BoxCollider2D>().IsTouching(GameManager.Instance.player.PickRange))
		{
			GameManager.Instance.player.FullWeight += Weight;
			GameManager.Instance.player.ActivatePiece(pieceType);
			Destroy(gameObject);
		}
    }
}
