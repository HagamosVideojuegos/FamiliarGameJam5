using UnityEngine;

public class Door : MonoBehaviour
{
	public Button buttonAsociated;
	public Lever leverAsicoated;
	public Vector3 movementToOpen;
	public float time;
	public LeanTweenType openCloseEffect;
	
	private Vector3 initialPosition;
	
	void Awake()
	{
		if(buttonAsociated)
		{
			Button.OnActivate += HandleOnActivate;
			Button.OnDeactivate += HandleOnDectivate;
		}
		
		if(leverAsicoated)
		{
			Lever.OnActivate += HandleOnActivate;
		}
		initialPosition = transform.localPosition;
	}
	
	void OnDestroy()
	{
		Button.OnActivate -= HandleOnActivate;
		Button.OnDeactivate -= HandleOnDectivate;
	}
	
	private void HandleOnActivate(Button button)
	{
		if(button == buttonAsociated)
		{
			LeanTween.cancel(gameObject);
			LeanTween.moveLocal(gameObject, movementToOpen, time).setEase( openCloseEffect );
			//TODO: SFX Open
		}
	}
	
	private void HandleOnActivate(Lever lever)
	{
		if(lever == leverAsicoated)
		{
			LeanTween.cancel(gameObject);
			LeanTween.moveLocal(gameObject, movementToOpen, time).setEase( openCloseEffect );
			//TODO: SFX Open
		}
	}
	
	private void HandleOnDectivate(Button button)
	{
		if(button == buttonAsociated)
		{
			LeanTween.cancel(gameObject);
			LeanTween.moveLocal(gameObject, initialPosition, time).setEase( openCloseEffect );
			//TODO: SFX Close
		} 
	}
}
