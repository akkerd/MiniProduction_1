using UnityEngine;
public class Helper_TouchController : MonoBehaviour, ITouchable
{
	/*public virtual Touch readTouchInput(){
		if (Input.touchCount != 0)
		{
			Touch currentTouch = Input.GetTouch(0);
			return currentTouch;
		} 
	}*/

	public virtual void FirstTouch(Touch currentTouch)
	{
		if (currentTouch.phase == TouchPhase.Began)
		{
			Debug.Log("Touched");
			return;
		}
	}

	public virtual void Drag(Touch touchStart)
	{

	}

	public virtual void Drop(Touch touchEnd)
	{

	}

	void FindChildrenWithname(string name)
	{
		//foreach (GameObject go in GetComponentInChildren(Transform, true))
		{

		}
	}
}

