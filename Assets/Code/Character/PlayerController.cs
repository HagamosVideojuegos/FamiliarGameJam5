using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
	[Serializable]
	public class Pieces
	{
		public GameObject LeftLeg;
		public GameObject RightLeg;
		public GameObject LeftArm;
		public GameObject RightArm;
		public GameObject Head;
		public int legs
		{
			get
			{
				var active = 0;
				if (LeftLeg.activeSelf)
					active ++;
				if (RightLeg.activeSelf)
					active ++;	 
				return active ;
			}
		}
		public int arms
		{
			get
			{
				var active = 0;
				if (LeftArm.activeSelf)
					active ++;
				if (RightArm.activeSelf)
					active ++;	 
				return active ;
			}
		}
		public bool head
		{
			get
			{
				return Head.activeSelf;
			}
		}
	}
	
	public float MoveForce;
	public float MoveOnAirForce;
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
			animator.SetBool("grounded", true);
		}
	}
	
	private void HandleMove(float direction)
	{
		if (pieces.legs == 0)
			return;
		
		animator.SetFloat("speed", Mathf.Abs(direction));
		
		if(direction != 0)
		{
			transform.localScale = new Vector3(Mathf.Sign(direction) * ((canJump) ? 1f : MoveOnAirForce), 1f, 1f);
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
			animator.SetBool("grounded", false);
		}
	}
	
	private void HandlePieceIn(Piece piece)
	{
		switch(piece.pieceType)
		{
			case Piece.PieceType.Arm:
			switch(pieces.arms)
			{
				case 0:
				//TODO: Activate right arm
				break;
				case 1:
				//TODO: Activate left arm
				break;
			}
			break;
			case Piece.PieceType.Head:
			//TODO: Activate head
			break;
			case Piece.PieceType.Leg:
			switch(pieces.arms)
			{
				case 0:
				//TODO: Activate right leg
				break;
				case 1:
				//TODO: Activate left leg
				break;
			}
			break;
		}
	}
	
	private void HandlePieceOut(Piece piece)
	{
		
	}
}
