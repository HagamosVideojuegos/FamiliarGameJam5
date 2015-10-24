public class Box : InteractableObjectCollider
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
}
