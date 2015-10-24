using UnityEngine;

public class InputManager : Singleton<InputManager>
{
	#region Events
	public static event Move OnMove;
	public static event Jump OnJump;
	public static event PieceOut OnPieceOut;
	public static event PieceIn OnPieceIn;
	public static event PieceIn OnPieceSelected;
	public static event Interact OnInteract;
	public static event Interact OnInteractableSelected;
	#endregion
	
	#region Delegates
	public delegate void Move(float direction);
	public delegate void Jump();
	public delegate void PieceOut(Piece piece);
	public delegate void PieceIn(Piece piece);
	public delegate void PieceSelected(Piece piece);
	public delegate void Interact(InteractableObject interactableObject);
	public delegate void InteractableSelected(InteractableObject interactableObject);
	#endregion
	
	private Ray2D pulse;
 	private RaycastHit2D colision;
	
	void LateUpdate ()
	{		
		var worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		colision = Physics2D.Raycast(worldPoint, Vector2.right, 1f, LayerMask.NameToLayer("Player"), 0);
		if(colision.collider != null)
		{
			var piece = colision.collider.gameObject.GetComponent<Piece>();
			var interactable = colision.collider.gameObject.GetComponent<InteractableObject>();
			
			if(Input.GetMouseButtonDown(0))
			{
				if(piece && piece.tag.Equals("Player") && OnPieceOut != null)
					OnPieceOut(piece);	
					
				if(interactable && OnInteract != null)
					OnInteract(interactable);
			} else {
				if(piece && OnPieceSelected != null)
					OnPieceSelected(piece);	
					
				if(interactable && OnInteractableSelected != null)
					OnInteractableSelected(interactable);
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
