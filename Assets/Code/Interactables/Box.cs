using UnityEngine;

public class Box : InteractableObjectCollider
{
    public int Weight;
    
    //private Rigidbody2D rigidBody;
    private Transform transformParent;
    
    protected override void Awake()
    {
        base.Awake();
        //rigidBody = GetComponent<Rigidbody2D>();
        transformParent = transform.parent;
    }
    
    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.arms < 2)
        {
            GameManager.Instance.player.NoPiece(PieceType.Arm);
            return;
        }
        GameManager.Instance.player.interacting = !GameManager.Instance.player.interacting;
        if (GameManager.Instance.player.interacting)
        {
            transform.parent = GameManager.Instance.player.transform;
            //Destroy(rigidBody);
        } else {
            transform.parent = transformParent;
            //rigidBody = gameObject.AddComponent<Rigidbody2D>();
            //rigidBody.isKinematic = true;
        }
    }
}
