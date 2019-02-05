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

	[SerializeField] private Animator logoAnimator;

	[SerializeField] private GameObject speechBubbleObject;
    
	[SerializeField] private Text speechBubbleText;

	[SerializeField] private Image teaBag;
    
	[SerializeField] private Button moveButton;

	[SerializeField] private CurrentCustomer currentCustomer;   
    
	[SerializeField] private GameObject button1;
	[SerializeField] private GameObject button2;
	[SerializeField] private GameObject nextCustomerButton;

	[SerializeField] private Text button1Text;
	[SerializeField] private Text button2Text;

	[SerializeField] private StateProcessFlag conversationCompleteFlag;
	[SerializeField] private StateProcessFlag teaMixedFlag;
	[SerializeField] private StateProcessFlag goodbyeSelectedFlag;

	private Animator speechBubbleAnimator;

	private void OnEnable()
	{
		EventManager.StartListening(EventManager.SwipeUp, OnMoveButtonClicked);
		EventManager.StartListening(EventManager.SwipeDown, OnMoveButtonClicked);
	}

	void Start()
	{
		speechBubbleObject.SetActive(false);
		speechBubbleAnimator = speechBubbleObject.GetComponent<Animator>();

		teaBag.gameObject.SetActive(false);
	}

	public void AnimateTitleOut()
	{
		logoAnimator.SetTrigger("Outro");
	}

	public void ShowSpeechBubble()
	{
		speechBubbleObject.SetActive(true);      
	}
    
	public void ShowFirstEnquiry()
	{
		button1.SetActive(true);
        button2.SetActive(true);
        nextCustomerButton.SetActive(false);

		speechBubbleText.text = currentCustomer.customer.FirstEnquiry;

        button1Text.text = currentCustomer.customer.FirstEnquiryResponse1;
        button2Text.text = currentCustomer.customer.FirstEnquiryResponse2;
	}

	public void MoveToSecondEnquiry() //TODO fiiiiiix this because wow
	{
		if (speechBubbleText.text == currentCustomer.customer.SecondEnquiry)
		{
			HideSpeechBubble();
			conversationCompleteFlag.SetFinished();
		}
		else
		{
			speechBubbleText.text = currentCustomer.customer.SecondEnquiry;

			button1Text.text = currentCustomer.customer.SecondEnquiryResponse1;
			button2Text.text = currentCustomer.customer.SecondEnquiryResponse2;
		}
	}

	public void HideSpeechBubble()
	{
		speechBubbleObject.SetActive(false);
	}
    
	public void OnTeaMixed()
	{
		teaBag.gameObject.SetActive(true);
	}

	public void OnGoodbyeStarted()
	{
		teaMixedFlag.SetFinished();

		teaBag.gameObject.SetActive(false);      

        ShowSpeechBubble();
        speechBubbleText.text = currentCustomer.customer.ThankYou;

        button1.SetActive(false);
        button2.SetActive(false);
        nextCustomerButton.SetActive(true);
	}

    public void OnGoodbyeSelected()
    {
        goodbyeSelectedFlag.SetFinished();
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
