using UnityEngine;

public class Cab : InteractableObjectTrigger
{
    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.head)
		{
			//TODO: SFX Next Level
			Invoke("NextLevel", 2f);
		} else {
			GameManager.Instance.player.NoPiece(PieceType.Head);
			//TODO: SFX Error
		}
    }
	
	protected void NextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
