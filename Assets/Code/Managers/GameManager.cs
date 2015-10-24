using UnityEngine;

public class GameManager : Singleton<GameManager>
{
	[HideInInspector]
	public PlayerController player;

	void Awake(){
		GameObject.DontDestroyOnLoad(GameManager.Instance);
	}

	public void ResetLevel()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
}
