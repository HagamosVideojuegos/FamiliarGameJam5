using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	#region Events
	public static event Move OnMove;
	public static event Jump OnJump;
	public static event Interact OnInteract;
	#endregion
	
	#region Delegates
	public delegate void Move(float direction);
	public delegate void Jump();
	public delegate void Interact(InteractableObject interactableObject);
	#endregion
	
	private Ray2D pulse;
 	private RaycastHit2D colision;
	
	void LateUpdate ()
	{		
		var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		colision = Physics2D.Raycast(worldPoint, Vector2.right, 1f, LayerMask.NameToLayer("Player"), 0);
		if(colision.collider != null)
		{
			var interactable = colision.collider.gameObject.GetComponent<InteractableObject>();
			
			if(Input.GetMouseButtonDown(0))
			{		
				Debug.Log(interactable.name);
				if(interactable && OnInteract != null)
					OnInteract(interactable);
			}
		}
	}
	
	void FixedUpdate()
	{
		if(OnMove != null)
			OnMove(Input.GetAxisRaw("Horizontal"));
		
		if (Input.GetButtonDown("Jump"))
			if(OnJump != null)
				OnJump();
	}
}
