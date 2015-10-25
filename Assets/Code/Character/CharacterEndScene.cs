using UnityEngine;

public class CharacterEndScene : MonoBehaviour
{
	private Animator animator;

	// Use this for initialization
	void Awake () {
		animator = GetComponentInChildren<Animator>();
		animator.SetInteger("legs", 0);
	}
}
