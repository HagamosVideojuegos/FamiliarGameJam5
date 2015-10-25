using UnityEngine;

public class AudioManager : Singleton<AudioManager>
{
	private GameObject g;
	
	void OnLevelWasLoaded(int level)
	{
		g = new GameObject();
		g.AddComponent<AudioSource>();
	}
	
	public GameObject PlaySound(AudioClip audio)
	{
		GameObject sound = GameObject.Instantiate(g);
		sound.GetComponent<AudioSource>().clip = audio;
		sound.GetComponent<AudioSource>().Play();
		Destroy(sound, audio.length);
		return sound;
	}

	public GameObject PlaySoundDelayed(AudioClip audio,float delay)
	{
		GameObject sound = GameObject.Instantiate(g);
		sound.GetComponent<AudioSource>().clip = audio;
		sound.GetComponent<AudioSource>().PlayDelayed(delay);
		Destroy(sound, audio.length);
		return sound;
	}
}
