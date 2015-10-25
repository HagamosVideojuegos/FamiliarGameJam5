using UnityEngine;

public class AudioManager : Singleton<MonoBehaviour>
{
	private GameObject g;
	
	void Start ()
	{
		g = new GameObject();
		g.AddComponent<AudioSource>();
	}
	
	public void PlaySound(AudioClip audio)
	{
		GameObject.Instantiate(g).GetComponent<AudioSource>().clip = audio;
	}
}
