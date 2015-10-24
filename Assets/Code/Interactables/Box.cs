public class Box : InteractableObject
{
    protected override void Interact()
    {
        if(isInteractable)
        {
            if (transform.parent == null)
            {
                transform.parent = GameManager.Instance.player.transform;
            } else {
                transform.parent = null;
            }
        }
    }
    /*
    protected override void UnInteract()
    {
        transform.parent = null;
    }
    */
}
