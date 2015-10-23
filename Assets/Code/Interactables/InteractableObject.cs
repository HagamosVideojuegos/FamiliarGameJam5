using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	public MonoBehaviour uiInteractable;
	public bool isInteractable
	{
		get
		{
			return _interactable;	
		}
	}
	
	private bool _interactable;
	void Awake()
	{
		InputManager.OnInteract += HandleOnInteract;
	}
	
	void OnDestroy()
	{
		InputManager.OnInteract -= HandleOnInteract;
	}
	
	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag.Equals("Player"))
		{
			_interactable = true;
			uiInteractable.enabled = true;
		}
	}
	
	void OnCollisionExit2D(Collision2D collider)
	{
		if(collider.gameObject.tag.Equals("Player"))
		{
			_interactable = false;
			uiInteractable.enabled = false;
		}
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
