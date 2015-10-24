
public class Lever : InteractableObjectCollider
{
	public static event Activate OnActivate;
	
	public delegate void Activate(Lever lever);

    protected override void Interact()
    {
        if(GameManager.Instance.player.pieces.arms > 0)
            GameManager.Instance.player.OnLeverUse(this);
    }
    
    public void UserLever()
    {
        if(OnActivate != null)
            OnActivate(this);
    }
}
