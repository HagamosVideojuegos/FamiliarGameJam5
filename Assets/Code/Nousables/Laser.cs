using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Laser : MonoBehaviour
{
	private SpriteRenderer sprite;
	
	void Awake()
	{
		sprite = GetComponent<SpriteRenderer>();
	}
	
	void OnTriggerStay2D(Collider2D collider)
	{
		if (sprite.enabled && collider.gameObject == GameManager.Instance.player.gameObject)
			GameManager.Instance.player.Die();
	}
}
