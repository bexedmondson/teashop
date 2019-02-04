using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeHandler : MonoBehaviour
{
	public enum SwipeDirection
	{
		Up,
		Down,
		Right,
		Left
	}

	/*private const float swipeSensitivity = 10f;

	private bool swiping = false;
	private bool eventSent = false;
	private Vector2 lastPosition;

	private Camera mainCamera;

	private void Start()
	{
		mainCamera = Camera.main;
	}

	/*void Update()
	{
		if (Input.touchCount == 0)
			return;
        else if (ShouldDiscardSwipe(Input.GetTouch(0)))      
			return;

		if (Input.GetTouch(0).deltaPosition.sqrMagnitude >= swipeSensitivity)
		{         
			if (swiping == false)
			{
				swiping = true;
				lastPosition = Input.GetTouch(0).position;
				return;
			}
			else
			{
				if (!eventSent)
				{
					Vector2 direction = Input.GetTouch(0).position - lastPosition;

					if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
					{
						if (direction.x > 0)
							Swipe(SwipeDirection.Right);
						else
							Swipe(SwipeDirection.Left);
					}
					else
					{
						if (direction.y > 0)
							Swipe(SwipeDirection.Up);
						else
							Swipe(SwipeDirection.Down);
					}

					eventSent = true;
				}
			}
		}
		else
		{
			swiping = false;
			eventSent = false;
		}
	}

	private void Swipe(SwipeDirection direction)
	{
		if (direction == SwipeDirection.Up)
			EventManager.TriggerEvent(EventManager.SwipeUp);
		else if (direction == SwipeDirection.Down)
			EventManager.TriggerEvent(EventManager.SwipeDown);
	}


	private bool ShouldDiscardSwipe(Touch touch)
    {
        /*List<RaycastResult> hits = new List<RaycastResult>();
        
		mainCamera.ScreenPointToRay(touch.position);
        
        EventSystem.current.RaycastAll(touch, hits);
        return (hits.Count > 0); // discard swipe if an UI element is beneath*/


		// Check if there is a touch
        /*if (touch.phase == TouchPhase.Began)
        {
            // Check if finger is over a UI element
            if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
            {
                Debug.Log("Touched the UI");
				return true;
            }
        }
		return false;
    }*/
}