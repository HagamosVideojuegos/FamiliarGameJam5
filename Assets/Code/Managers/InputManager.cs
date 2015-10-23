using UnityEngine;

public class InputManager : Singleton<MonoBehaviour>
{
	#region Events
	public static event Move OnMove;
	public static event Jump OnJump;
	public static event PieceOut OnPieceOut;
	public static event PieceIn OnPieceIn;
	public static event Interact OnInteract;
	#endregion
	
	#region Delegates
	public delegate void Move(float direction);
	public delegate void Jump();
	public delegate void PieceOut(Piece piece);
	public delegate void PieceIn(Piece piece);
	public delegate void Interact(InteractableObject interactableObject);
	#endregion
	
	private Ray pulse;
 	private RaycastHit colision;
	
	void Update ()
	{		
		if(Input.GetMouseButton(0))
		{	
			pulse=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(pulse,out colision))
			{
				var piece = colision.collider.gameObject.GetComponent<Piece>();
				var interactable = colision.collider.gameObject.GetComponent<InteractableObject>();
				
				if(piece && piece.tag.Equals("Player") && OnPieceOut != null)
					OnPieceOut(piece);
					
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
