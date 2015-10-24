
using UnityEngine;

public class Lever : InteractableObjectCollider
{
	public static event Activate OnActivate;
	
	public delegate void Activate(Lever lever);

    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.arms > 0)
        {
            GameManager.Instance.player.OnLeverUse(this);
            if(OnActivate != null)
                OnActivate(this);
            
            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
            this.enabled = false;
        }
    }
}
