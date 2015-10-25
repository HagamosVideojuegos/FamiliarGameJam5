using UnityEngine;
using UnityEngine.EventSystems;

public class UIRestartGame : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Application.LoadLevel(1);
    }
}
