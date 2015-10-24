using UnityEngine;

public class Door : MonoBehaviour
{
	public Button buttonAsociated;
	public Vector3 movementToOpen;
	public float time;
	
	public bool test;
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
	
	void OnValidate()
	{
		if(test)
			HandleOnActivate(null);
		else
			HandleOnDectivate(null);
	}
	
	private void HandleOnActivate(Button button)
	{
		LeanTween.cancel(gameObject);
		LeanTween.moveLocal(gameObject, movementToOpen, time);
		//TODO: SFX Open
	}
	
	private void HandleOnDectivate(Button button)
	{
		LeanTween.cancel(gameObject);
		LeanTween.move(gameObject, initialPosition, time);
		//TODO: SFX Close 
	}
}
