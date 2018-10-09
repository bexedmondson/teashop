using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraManager : MonoBehaviour 
{   
	public static CameraManager instance = null;

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
    
	private readonly Vector3 bowlViewPosition = new Vector3(0f, 0f, -10f);
	private readonly Vector3 cabinetViewPosition = new Vector3(0f, -8.5f, -10f);
    
	private const float cameraMoveTime = 1f;
    
	public void StartMoveUp()
    {
		StartCoroutine(MoveCamera(cabinetViewPosition, bowlViewPosition, cameraMoveTime));
	}

    public void StartMoveDown()
    {
		StartCoroutine(MoveCamera(bowlViewPosition, cabinetViewPosition, cameraMoveTime));
    }
    
	private IEnumerator MoveCamera(Vector3 origin, Vector3 target, float duration)
	{
		float journey = 0f;
        while (journey <= duration)
        {
            journey = journey + Time.deltaTime;
            float percent = Mathf.Clamp01(journey / duration);

			float curvePercent = cameraMoveCurve.Evaluate(percent);
            transform.position = Vector3.Lerp(origin, target, curvePercent);

            yield return null;
        }
	}
}
