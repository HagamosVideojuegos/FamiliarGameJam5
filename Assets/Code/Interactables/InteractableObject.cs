using UnityEngine;

public abstract class InteractableObject : MonoBehaviour
{
	void Awake()
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
