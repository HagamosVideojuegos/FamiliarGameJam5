using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	public bool isInteractable
	{
		get
		{
			return (transform.parent == GameManager.Instance.player.transform) ? true : _interactable;	
		}
	}
	
	public SpriteRenderer uiInteractable;
	
	protected bool _interactable = false;
	protected virtual void Awake()
	{
		InputManager.OnInteract += HandleOnInteract;
	}
	
	void OnDestroy()
	{
		InputManager.OnInteract -= HandleOnInteract;
	}
	
	private void HandleOnInteract(InteractableObject interactableObject)
	{
		if(interactableObject == this)
		{
			Interact();
		}
	}
	
	protected abstract void Interact();
}
