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
	public int FullWeight;
	
	private Rigidbody2D rigidBody;
	private Animator animator;
	private bool canJump;
	public bool interacting
	{
		get
		{
			animator.SetBool("box", _interacting);
			return _interacting;
		}
		set
		{
			_interacting = value;
		}
	}
	
	private bool _interacting;

    public void Die()
    {
        animator.SetTrigger("die");
		OnDestroy();
		GameManager.Instance.Invoke("ResetLevel", 2f);
    }
	
	public void SelfDestruct()
    {
        animator.SetTrigger("selfDestruct");
		OnDestroy();
		GameManager.Instance.Invoke("ResetLevel", 2f);
    }
	
	public void OnLeverUse(Lever lever)
	{
		animator.SetTrigger("useLever");
		interacting = true;
		InputManager.OnMove -= HandleMove;
		lever.Invoke("UserLever", 0.7f);
	}
	
	public void OnLeverExit()
	{
		interacting = false;
		InputManager.OnMove += HandleMove;
	}
	
	void Awake ()
	{
		InputManager.OnMove += HandleMove;
		InputManager.OnJump += HandleJump;
		
		rigidBody = GetComponent<Rigidbody2D>();
		animator = GetComponentInChildren<Animator>();
		GameManager.Instance.player = this;
	}
	
	void OnDestroy ()
	{
		InputManager.OnMove -= HandleMove;
		InputManager.OnJump -= HandleJump;
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
			animator.SetBool("walkRight", (direction > 0) ? true : false);
			if(!interacting)
				transform.localScale = new Vector3(1f *  Mathf.Sign(direction) , 1f, 1f);
		}
		rigidBody.velocity = new Vector2(direction *  ((canJump || !interacting) ? MoveForce : MoveOnAirForce), rigidBody.velocity.y);
	}
	
	private void HandleJump()
	{
		if (canJump && !interacting && pieces.legs == 2) 
		{
			rigidBody.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
			canJump = false;
			animator.SetBool("grounded", false);
		}
	}
	
	public void ActivatePiece(PieceType piece)
	{
		switch(piece)
		{
			case PieceType.Arm:
			switch(pieces.arms)
			{
				case 0:
				pieces.RightArm.SetActive(true);
				break;
				case 1:
				pieces.LeftArm.SetActive(true);
				break;
			}
			break;
			case PieceType.Head:
			pieces.Head.SetActive(true);
			break;
			case PieceType.Leg:
				switch(pieces.arms)
				{
					case 0:
						pieces.RightLeg.SetActive(true);
						break;
					case 1:
						pieces.LeftLeg.SetActive(true);
						break;
				}
				animator.SetInteger("legs",pieces.legs);
				break;
		}
	}

	/// <summary>
	/// Deactivates the piece.
	/// </summary>
	/// <returns><c>true</c>, if piece was deactivated, <c>false</c> otherwise.</returns>
	/// <param name="piece">Piece.</param>
	public bool DeactivatePiece(PieceType piece)
	{
		switch(piece)
		{
			case PieceType.Arm:
				switch(pieces.arms)
				{
					case 1:
						pieces.RightArm.SetActive(false);
						return true;
					case 2:
						pieces.LeftArm.SetActive(false);
						return true;
					default:
						return false;
				}
			case PieceType.Head:
				if(pieces.head){
					pieces.Head.SetActive(false);
					return true;
				}else{
					return false;
				}
			case PieceType.Leg:
				switch(pieces.legs)
				{
					case 1:
						pieces.RightLeg.SetActive(false);
						animator.SetInteger("legs",pieces.legs);
						return true;
					case 2:
						pieces.LeftLeg.SetActive(false);
						animator.SetInteger("legs",pieces.legs);
						return true;
					default:
						return false;
				}
		}
		return false;
	}
}
