using UnityEngine;

public interface ITouchable
{
	//Touch readTouchInput();
	void FirstTouch(Touch currentTouch);

	void Drag(Touch touchStart);

	void Drop(Touch touchEnd);
}