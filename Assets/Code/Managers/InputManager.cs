using UnityEngine;

public class InputManager : Singleton<MonoBehaviour>
{
	#region Events
	public static event MoveRight OnMoveLeft;
	public static event MoveLeft OnMoveRight;
	public static event Jump OnJump;
	public static event PieceOut OnPieceOut;
	public static event PieceIn OnPieceIn;
	public static event BoxAttach OnBoxAttach;
	#endregion
	
	#region Delegates
	public delegate void MoveRight();
	public delegate void MoveLeft();
	public delegate void Jump();
	public delegate void PieceOut(Piece piece);
	public delegate void PieceIn(Piece piece);
	public delegate void BoxAttach(Box box);
	#endregion
	
	private Ray pulsacion;
 	private RaycastHit colision;
	
	void LateUpdate ()
	{
		if(Input.GetAxis("Horizontal") == 1)
		{
			if(OnMoveRight != null)
				OnMoveRight();
		}
		else if(Input.GetAxis("Horizontal") == -1)
		{
			if(OnMoveLeft != null)
				OnMoveLeft();
		}
		
		if (Input.GetButtonDown("Jump"))
			if(OnJump != null)
				OnJump();
				
		if(Input.GetMouseButton(0))
		{
			var pulse = new Ray();
			var colision = new RaycastHit();
			
			pulse=Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(pulse,out colision))
			{
				var piece = colision.collider.gameObject.GetComponent<Piece>();
				 if(piece && piece.tag.Equals("Player") && OnPieceOut != null)
					OnPieceOut(piece);
			}
		}
	}
}
