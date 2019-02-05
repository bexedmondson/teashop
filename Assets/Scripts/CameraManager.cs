using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour 
{   
	public static CameraManager instance = null;

	public enum CameraPosition
	{
		BowlView,
        CabinetView,
        ShopView,
	}

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
    
	[SerializeField] private AnimationCurve cameraMoveCurve;

	[SerializeField] private StateProcessFlag cameraIntroMoveDoneFlag;
    
	public CameraPosition currentPosition = CameraPosition.ShopView;

	public readonly Vector3 shopViewPosition = new Vector3(0f, 11.23f, -10f);
	public readonly Vector3 bowlViewPosition = new Vector3(0f, 0f, -10f);
	public readonly Vector3 cabinetViewPosition = new Vector3(0f, -5.47f, -10f);
    
	private const float cameraMoveTime = 1f;

	public void IntroCamera()
	{
		StartMoveCamera(CameraPosition.BowlView);
	}

	public void StartMoveCamera(CameraPosition targetPosition)
    {
		if (targetPosition == currentPosition)
		{
			Debug.LogWarning("target position is same as current position! not moving the camera.");
			return;
		}

		switch (targetPosition)
		{
			case CameraPosition.BowlView:
			{
				StartCoroutine(MoveCamera(bowlViewPosition));
				break;
			}
			case CameraPosition.CabinetView:
			{
				StartCoroutine(MoveCamera(cabinetViewPosition));
				break;
			}
		}
        
        currentPosition = targetPosition;
    }
    
	public IEnumerator MoveCamera(Vector3 target)
	{
		Vector3 origin = new Vector3(transform.position.x, transform.position.y, transform.position.z);

		float journey = 0f;
		while (journey <= cameraMoveTime)
        {
            journey = journey + Time.deltaTime;
			float percent = Mathf.Clamp01(journey / cameraMoveTime);

			float curvePercent = cameraMoveCurve.Evaluate(percent);
            transform.position = Vector3.Lerp(origin, target, curvePercent);

            yield return null;
        }

		cameraIntroMoveDoneFlag.SetFinished();
	}
}
