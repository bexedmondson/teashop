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
    
	private const float bowlViewPositionY = 0f;
	private const float cabinetViewPositionY = -8.5f;
    
	private const float cameraMoveSpeed = 0.1f;

	private Coroutine runningCoroutine;
    
	public void StartMoveUp()
    {
		if (runningCoroutine != null)
			StopCoroutine(runningCoroutine);
		
		runningCoroutine = StartCoroutine(MoveUp());
    }

	private IEnumerator MoveUp()
	{
		while (transform.position.y < bowlViewPositionY)
        {
            this.transform.position -= new Vector3(0f, cameraMoveSpeed * -1, 0f);
            yield return null;
        }

        runningCoroutine = null;
	}

	public void StartMoveDown()
	{
		if (runningCoroutine != null)
            StopCoroutine(runningCoroutine);
        
		runningCoroutine = StartCoroutine(MoveDown());
	}

	private IEnumerator MoveDown()
    {
		while (transform.position.y > cabinetViewPositionY)
        {
            this.transform.position -= new Vector3(0f, cameraMoveSpeed, 0f);
            yield return null;
        }

        runningCoroutine = null;
    }
}
