using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour 
{
	public static UIManager instance = null;

    private void Awake()
    {
        //singleton time!
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

	[SerializeField] private GameObject speechBubbleObject;
    
	[SerializeField] private Text speechBubbleText;

	[SerializeField] private Image teaBag;

	[SerializeField] private Button moveButton;

	void Start()
	{
		speechBubbleObject.SetActive(false);
	}

	public void ShowSpeechBubble(string text)
	{
		speechBubbleObject.SetActive(true);
		speechBubbleText.text = text;
	}

	public void HideSpeechBubble()
	{
		speechBubbleObject.SetActive(false);
	}

	public void OnTeaMixed()
	{
		teaBag.gameObject.SetActive(true);
		Animator anim = teaBag.GetComponent<Animator>();
		if (anim != null)
		{
			anim.Play("Animate");
		}
	}

	public void OnTeaBagClicked()
	{
		teaBag.gameObject.SetActive(false);
	}

	public void OnMoveButtonClicked()
	{
		CameraManager manager = CameraManager.instance;

		if (manager.currentPosition == CameraManager.CameraPosition.BowlView)
		{
			manager.StartMoveCamera(CameraManager.CameraPosition.CabinetView);
			moveButton.gameObject.transform.Rotate(new Vector3(0, 0, 180));
		}
		else if (manager.currentPosition == CameraManager.CameraPosition.CabinetView)
		{
			manager.StartMoveCamera(CameraManager.CameraPosition.BowlView);
			moveButton.gameObject.transform.Rotate(new Vector3(0, 0, 180));
		}
	}
}
