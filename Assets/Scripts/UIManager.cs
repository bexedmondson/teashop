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
}
