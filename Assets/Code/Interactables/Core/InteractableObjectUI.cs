using UnityEngine;
using UnityEngine.EventSystems;

public abstract class InteractableObjectUI : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Interact();
    }
    
    protected abstract void Interact();
}
