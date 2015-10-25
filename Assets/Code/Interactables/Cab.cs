using UnityEngine;

public class Cab : InteractableObjectTrigger
{
	public AudioClip nextLevelAudio,errorLevelAudio;

	private GameObject soundexit,soundfail;

    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.head)
		{
			GameManager.Instance.player.OnDestroy();
			if(soundexit==null){
				soundexit=AudioManager.Instance.PlaySound(nextLevelAudio);
			}
			Invoke("NextLevel", nextLevelAudio.length);
		} else {
			GameManager.Instance.player.NoPiece(PieceType.Head);
			if(soundfail==null){
				soundfail=AudioManager.Instance.PlaySound(errorLevelAudio);
			}
		}
    }
	
	protected void NextLevel()
	{
		Application.LoadLevel(Application.loadedLevel + 1);
	}
}
