
public class Lever : InteractableObjectCollider
{
	public static event Activate OnActivate;
	
	public delegate void Activate(Lever lever);

    protected override void Interact()
    {
        if(OnActivate != null)
			OnActivate(this);
    }
}
