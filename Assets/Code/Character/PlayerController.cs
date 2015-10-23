using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	public float MoveForce;
	public float JumpForce;
	
	private Rigidbody2D rigidBody;
	private bool canJump;
	
	void Awake ()
	{
		InputManager.OnMove += HandleMove;
		InputManager.OnJump += HandleJump;
		InputManager.OnPieceIn += HandlePieceIn;
		InputManager.OnPieceOut += HandlePieceOut;
		
		rigidBody = GetComponent<Rigidbody2D>();
	}
	
	void OnDestroy ()
	{
		InputManager.OnMove -= HandleMove;
		InputManager.OnJump -= HandleJump;
		InputManager.OnPieceIn -= HandlePieceIn;
		InputManager.OnPieceOut -= HandlePieceOut;
	}
	
	void OnCollisionEnter2D(Collision2D collider)
	{
		if(collider.gameObject.tag.Equals("Floor"))
		{
			canJump = true;
		}
	}
	
	private void HandleMove(float direction)
	{
		rigidBody.velocity = new Vector2(direction * MoveForce, rigidBody.velocity.y);
	}
	
	private void HandleJump()
	{
		if (canJump) 
		{
			rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
			canJump = false;
		}
	}
	
	private void HandlePieceIn(Piece piece)
	{
		
	}
	
	private void HandlePieceOut(Piece piece)
	{
		
	}
}
