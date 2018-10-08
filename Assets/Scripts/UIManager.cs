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
}
