﻿public class Box : InteractableObjectCollider
{   
    protected override void Interact()
    {
        if(isInteractable)
        {
            GameManager.Instance.player.interacting = (transform.parent == null);
            if (GameManager.Instance.player.interacting)
            {
                transform.parent = GameManager.Instance.player.transform;
            } else {
                transform.parent = null;
            }
        }
    }
}
