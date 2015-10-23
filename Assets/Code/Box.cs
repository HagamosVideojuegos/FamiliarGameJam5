using UnityEngine;

public class Box : MonoBehaviour
{
	public bool Attached;
	
	void Awake()
    {
        InputManager.OnBoxAttach += GetAttached;
    }

    private void GetAttached(Box box)
    {
        if(box == this)
		{
			//TODO: Implement...
		}
    }
}
