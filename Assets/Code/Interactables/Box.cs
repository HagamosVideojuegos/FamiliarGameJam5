using UnityEngine;

public class Box : InteractableObjectCollider
{
    public int Weight;
    
    private Rigidbody2D rigidBody;
    
    protected override void Awake()
    {
        base.Awake();
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    protected override void Interact()
    {
        if(isInteractable)
        {
            GameManager.Instance.player.interacting = (transform.parent == null);
            if (GameManager.Instance.player.interacting)
            {
                transform.parent = GameManager.Instance.player.transform;
                Destroy(rigidBody);
            } else {
                transform.parent = null;
                rigidBody = gameObject.AddComponent<Rigidbody2D>();
                rigidBody.isKinematic = true;
            }
        }
    }
}
