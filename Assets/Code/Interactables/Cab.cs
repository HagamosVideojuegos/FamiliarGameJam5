using UnityEngine;

public class Cab : InteractableObjectTrigger
{
	public AudioClip nextLevelAudio,errorLevelAudio;

	private GameObject sound;

    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.head)
		{
			//TODO: SFX Next Level
			AudioManager.Instance.PlaySound(nextLevelAudio);
			Invoke("NextLevel", 2f);
		} else {
			GameManager.Instance.player.NoPiece(PieceType.Head);
			//TODO: SFX Error
			AudioManager.Instance.PlaySound(errorLevelAudio);
		}
    }
	
	protected void NextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
