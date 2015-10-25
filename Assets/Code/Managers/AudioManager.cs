using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	private GameObject g;
	
	void Start ()
	{
		g = new GameObject();
		g.AddComponent<AudioSource>();
	}
	
	public void PlaySound(AudioClip audio)
	{
		GameObject sound = GameObject.Instantiate(g);
		sound.GetComponent<AudioSource>().clip = audio;
		Destroy(sound, audio.length);
	}
}
