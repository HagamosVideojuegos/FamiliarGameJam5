using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[HideInInspector]
	public PlayerController player;
	
	public void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
