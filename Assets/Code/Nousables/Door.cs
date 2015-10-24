using UnityEngine;

public class Door : MonoBehaviour
{
	public Button buttonAsociated;
	public Vector3 movementToOpen;
	public float time;
	public LeanTweenType openCloseEffect;
	
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
		LeanTween.moveLocal(gameObject, movementToOpen, time).setEase( openCloseEffect );
		//TODO: SFX Open
	}
	
	private void HandleOnDectivate(Button button)
	{
		LeanTween.cancel(gameObject);
		LeanTween.moveLocal(gameObject, initialPosition, time).setEase( openCloseEffect );
		//TODO: SFX Close 
	}
}
