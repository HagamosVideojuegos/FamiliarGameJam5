using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(Button))]
public abstract class InteractableObjectUI : InteractableObject, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }
}
