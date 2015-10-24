using UnityEngine;

public class Door : MonoBehaviour
{
	public Button buttonAsociated;
	public Vector3 movementToOpen;
	public float time;
	
	private Vector3 initialPosition;
	
	void Awake()
	{
		Button.OnActivate += HandleOnActivate;
		Button.OnDeactivate += HandleOnDectivate;
		initialPosition = transform.localPosition;
	}
	
	void OnDestroy()
	{
		Button.OnActivate -= HandleOnActivate;
		Button.OnDeactivate -= HandleOnDectivate;
	}
	
	private void HandleOnActivate(Button button)
	{
		LeanTween.cancel(gameObject);
		LeanTween.moveLocal(gameObject, movementToOpen, time).setEase( LeanTweenType.easeInQuad );
		//TODO: SFX Open
	}
	
	private void HandleOnDectivate(Button button)
	{
		LeanTween.cancel(gameObject);
		LeanTween.moveLocal(gameObject, initialPosition, time).setEase( LeanTweenType.easeInQuad );
		//TODO: SFX Close 
	}
}
