using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[Serializable]
	public class Pieces
	{
		public int legs;
		public int arms;
		public bool head;
		public bool body;
	}
	
	public float MoveForce;
	public float JumpForce;
	
	public Pieces pieces;
	
	[HideInInspector]
	public int Weight;
	
	private Rigidbody2D rigidBody;
	private Animator animator;
	private bool canJump;
	
	void Awake ()
	{
		InputManager.OnMove += HandleMove;
		InputManager.OnJump += HandleJump;
		InputManager.OnPieceIn += HandlePieceIn;
		InputManager.OnPieceOut += HandlePieceOut;
		
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		GameManager.Instance.player = this;
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
		if (pieces.legs == 0)
			return;
		
		animator.SetFloat("speed", Mathf.Abs(direction));
		
		if(direction != 0)
		{
			transform.localScale = new Vector3(1f * Mathf.Sign(direction), 1f, 1f);
			animator.SetBool("walkRight", (direction > 0) ? true : false);
		}
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
