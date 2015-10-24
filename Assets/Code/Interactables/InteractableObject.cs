using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	public bool isInteractable
	{
		get
		{
			return (transform.parent == null) ? _interactable : true;	
		}
	}
	
	public SpriteRenderer uiInteractable;
	
	protected bool _interactable;
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
