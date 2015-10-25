using UnityEngine;

public class Door : MonoBehaviour
{
	public Button[] buttonAsociated;
	public Lever leverAsicoated;
	public Vector3 movementToOpen;
	public float time;
	public LeanTweenType openCloseEffect;
	
	private Vector3 initialPosition;
	
	private int actives;
	
	void Awake()
	{
		if(buttonAsociated.Length > 0)
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
		foreach(Button g in buttonAsociated)
		{
			if(g == button)
			{
				actives ++;
				LeanTween.cancel(gameObject);
				LeanTween.moveLocal(gameObject, movementToOpen, time).setEase( openCloseEffect );
				//TODO: SFX Open
				break;
			}
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
		
		foreach(Button g in buttonAsociated)
		{
			if(g == button)
			{
				actives--;
				if(actives == 0)
				{
					LeanTween.cancel(gameObject);
					LeanTween.moveLocal(gameObject, initialPosition, time).setEase( openCloseEffect );
					//TODO: SFX Open
				}
				break;
			}
		} 
	}
}
